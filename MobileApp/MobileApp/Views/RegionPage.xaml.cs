using MobileApp.Models;
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
    public partial class RegionPage : ContentPage
    {
        public RegionPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                RegionCollection.ItemsSource = await App.Data.ReadRegions();
            }
            catch { }
        }

        async void ToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegionDetail());
        }

        async void SwipeItemInvokedE(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var reg = item.CommandParameter as RegionModel;
            await Navigation.PushAsync(new RegionDetail(reg));
        }

        async void SwipeItemInvokedD(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var reg = item.CommandParameter as RegionModel;
            var res = await DisplayAlert("delete", $"delete {reg.Name}", "Yes", "No");

            if (res)
            {
                await App.Data.DeleteRegion(reg);
                RegionCollection.ItemsSource = await App.Data.ReadRegions();
            }
        }
    }
}
