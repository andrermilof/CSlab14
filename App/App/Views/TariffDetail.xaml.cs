using App4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TariffDetail : ContentPage
    {
        public TariffDetail()
        {
            InitializeComponent();
        }

        TariffModel _tariff;
        public TariffDetail(TariffModel tariff)
        {
            InitializeComponent();
            _tariff = tariff;
            providEntry.Text = tariff.Provider;
            speedEntry.Text = tariff.Speed;
            costEntry.Text = tariff.Cost;

            providEntry.Focus();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(providEntry.Text) || string.IsNullOrWhiteSpace(speedEntry.Text) || string.IsNullOrWhiteSpace(costEntry.Text))
            {
                await DisplayAlert("Invalid", "No text", "OK");
            }
            else if (_tariff != null)
            {
                EditTariff();
            }
            else
            {
                AddNewTariff();
            }
        }

        async void AddNewTariff()
        {
            await App.Data.CreateTariff(new TariffModel { Provider = providEntry.Text, Speed = speedEntry.Text, Cost = costEntry.Text });
            await Navigation.PopAsync();
        }

        async void EditTariff()
        {
            _tariff.Provider = providEntry.Text;
            _tariff.Speed = speedEntry.Text;
            _tariff.Cost = costEntry.Text;

            await App.Data.UpdateTariff(_tariff);
            await Navigation.PopAsync();
        }
    }
}
