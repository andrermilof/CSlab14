using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App;
using System;

namespace App
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
                    db = new SqlData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mydb.db"));
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
