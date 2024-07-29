
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouseApp
{
    public partial class App : Application
    {
        static Models.PlantDatabase database;

        public static Models.PlantDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new Models.PlantDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PlantsSQLite.db3"));
                }
                return database;
            }
        }

        public App()
        {


            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            
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
