using MobileApp.Models;
using MobileApp.Views;
using MobileApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TariffPage : ContentPage
    {
        public TariffPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                TariffCollecion.ItemsSource = await App.Data.ReadTariffs();
            }
            catch { }
        }

        async void ToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TariffDetail());
        }

        async void SwipeItemInvokedE(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var trff = item.CommandParameter as TariffModel;
            await Navigation.PushAsync(new TariffDetail(trff));
        }

        async void SwipeItemInvokedD(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var tariff = item.CommandParameter as TariffModel;
            var res = await DisplayAlert("delete", $"delete {tariff.TariffId}", "Yes", "No");

            if (res)
            {
                await App.Data.DeleteTariff(tariff);
                TariffCollecion.ItemsSource = await App.Data.ReadTariffs();
            }
        }
    }
}
