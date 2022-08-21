using Mobile_hw_2.Pages;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_hw_2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDialog : PopupPage
    {
        private int id; 
        private DateTime date;
        public CustomDialog(int _id, string _name, string _dob, string _credit)
        {
            InitializeComponent();
            _Name.Text = _name;
            _Credit.Text = _credit;
            date = DateTime.Parse(_dob, System.Globalization.CultureInfo.InvariantCulture);
            _Date.Date = date;
            id = _id;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await App.CustomerRepo.RemoveCustomer(id);

            await PopupNavigation.Instance.PopAsync(true);

            DependencyService.Get<Toast>().Show("Record Deleted. Please Refresh The Page.Sliding Down The Page");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (_Name.Text == null || _Credit.Text == null)
            {
                DependencyService.Get<Toast>().Show("Not Allowed Blank Area");
            }
            else
            {
                var customer = new Customers
                {
                    Id = id,
                    Name = _Name.Text,
                    Credit = _Credit.Text,
                    Dob = _Date.Date.ToString("d/MMM/yyyy")
                };
                await App.CustomerRepo.UpdateCustomer(customer);
                await PopupNavigation.Instance.PopAsync(true);
                DependencyService.Get<Toast>().Show("Records Updated. Please Refresh The Page.Sliding Down The Page");

            }

        }
    }
}