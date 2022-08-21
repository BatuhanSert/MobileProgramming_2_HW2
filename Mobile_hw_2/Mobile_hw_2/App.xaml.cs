using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_hw_2
{
    public partial class App : Application
    {
        public static CustomerService CustomerRepo { get; private set; }
        public App()
        {
            InitializeComponent();
            CustomerRepo = new CustomerService();
            MainPage = new NavigationPage(new Mobile_hw_2.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
