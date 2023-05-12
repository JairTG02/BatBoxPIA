using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BatBoxPIA.Vistas;
using BatBoxPIA.Database;
using BatBoxPIA.Vistas.AccessApp;
    

namespace BatBoxPIA
{
    public partial class App : Application
    {
        #region Database
        static DatabaseQuerys database;

        public static DatabaseQuerys Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseQuerys(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBname.db"));
                }
                return database;
            }
        }
        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PaginaInicial());
            
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
