using Mobile_hw_2.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Mobile_hw_2
{
    public partial class MainPage : ContentPage
    {
        public Command TouchCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            customerList.RefreshCommand = new Command(() =>
            {
                getDatas();
                customerList.IsRefreshing = false;
            });                                   
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCustomer());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            getDatas();
        }

        public async void getDatas()
        {
            List<Customers> people = (List<Customers>)await App.CustomerRepo.GetCustomers();

            if (people.Count == 0)
            {
                DependencyService.Get<Toast>().Show("No Customer Records");
            }
            customerList.ItemsSource = people;
            
        }      
        

        private async void customerList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int _id = (e.Item as Customers).Id;
            string _name = (e.Item as Customers).Name;
            string _dob = (e.Item as Customers).Dob;
            string _credit = (e.Item as Customers).Credit;
            await PopupNavigation.Instance.PushAsync(new CustomDialog(_id, _name, _dob, _credit));
        }
    }
}
