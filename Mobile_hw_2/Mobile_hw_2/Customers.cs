using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile_hw_2
{
    [Table("customer")]
    public class Customers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Credit { get; set; }
    }
}
