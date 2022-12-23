using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProviderDetail : ContentPage
	{
		ProviderModel _provider;
		public ProviderDetail ()
		{
			InitializeComponent ();
		}

        public ProviderDetail(ProviderModel provider)
        {
            InitializeComponent();
			_provider = provider;
			nameEntry.Text = provider.Name;
			phoneEntry.Text = provider.Telephone;

			nameEntry.Focus();
        }

        async void ButtonClicked(object sender, EventArgs e)
		{
			if(string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(phoneEntry.Text))
			{
				await DisplayAlert("Invalid", "No text", "OK");
			}
			else if(_provider != null)
			{
				EditProvider();
			}
			else
			{
				AddNewProvider();
			}
		}

		async void AddNewProvider()
		{
			await App.Data.CreateProvider(new ProviderModel { Name = nameEntry.Text, Telephone = phoneEntry.Text });
			await Navigation.PopAsync();
		}

		async void EditProvider()
		{
			_provider.Name = nameEntry.Text;
			_provider.Telephone = phoneEntry.Text;
			await App.Data.UpdateProvider(_provider);
			await Navigation.PopAsync();
		}
	}
}