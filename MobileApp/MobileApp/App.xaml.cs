using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp;
using System;

namespace MobileApp
{
    public partial class App : Application
    {

        private static SqlData db;

        public static SqlData Data
        {
            get
            {
                if (db == null)
                {
                    db = new SqlData();
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
