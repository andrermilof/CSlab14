using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegionDetail : ContentPage
    {
        RegionModel _region; 
        public RegionDetail()
        {
            InitializeComponent();
        }

        public RegionDetail(RegionModel reg)
        {
            InitializeComponent();
            _region = reg;
            nameEntry.Text = reg.Name;
            providEntry.Text = Convert.ToString(reg.ProviderId);

            nameEntry.Focus();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(providEntry.Text))
            {
                await DisplayAlert("Invalid", "No text", "OK");
            }
            else if (_region != null)
            {
                EditRegion();
            }
            else
            {
                AddNewRegion();
            }
        }

        async void AddNewRegion()
        {
            await App.Data.CreateRegion(new RegionModel { Name = nameEntry.Text, ProviderId = Convert.ToInt32(providEntry.Text) });
            await Navigation.PopAsync();
        }

        async void EditRegion()
        {
            _region.Name = nameEntry.Text;
            _region.ProviderId = Convert.ToInt32(providEntry.Text);
            await App.Data.UpdateRegion(_region);
            await Navigation.PopAsync();
        }
    }
}