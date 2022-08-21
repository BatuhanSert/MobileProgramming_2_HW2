using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Mobile_hw_2
{
    public class CustomerService
    {
        static SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public CustomerService()
        {
            conn = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyData.db"));
            conn.CreateTableAsync<Customers>().Wait();
        }

        public async Task AddCustomer(string name, string dob, string credit)
        {
            //await Init();

            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(credit))
                    throw new Exception("Valid name required");

                var customer = new Customers
                {
                    Name = name,
                    Dob = dob,
                    Credit = credit
                };
                result = await conn.InsertAsync(customer);
                
                //StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
                //Console.WriteLine(StatusMessage);
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task UpdateCustomer(Customers customer)
        {
            try
            {
                await conn.UpdateAsync(customer);
            }
            catch
            {

            }
        }

        public async Task RemoveCustomer(int id)
        {        
            await conn.DeleteAsync<Customers>(id);
        }

        public async Task<IEnumerable<Customers>> GetCustomers()
        {
            //await Init();
            try
            {
                
                var liste = await conn.Table<Customers>().ToListAsync();
                Console.WriteLine(liste);
                return liste;
     

            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                Console.WriteLine(StatusMessage);

            }
            return new List<Customers>();
            
        }


        public async Task DeleteTable()
        {
            //await Init();
            try
            {
                await conn.DeleteAllAsync<Customers>();

            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                Console.WriteLine(StatusMessage);

            }

        }
    }
}
