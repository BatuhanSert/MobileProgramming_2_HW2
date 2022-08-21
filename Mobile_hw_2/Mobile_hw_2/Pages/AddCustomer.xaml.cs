using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_hw_2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCustomer : ContentPage
    {
        private const string Format = "d/MMM/yyyy";

        public AddCustomer()
        {
            InitializeComponent();

            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            if (_Name.Text == null || _Credit.Text == null)
            {
                DependencyService.Get<Toast>().Show("Not Allowed Blank Area");
            }
            else
            {
                await App.CustomerRepo.AddCustomer(
                    _Name.Text,
                    _Date.Date.ToString(Format),
                    _Credit.Text
                    );
                await Navigation.PopAsync();
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _Name.Text = "";
            _Credit.Text = "";
        }
    }
}