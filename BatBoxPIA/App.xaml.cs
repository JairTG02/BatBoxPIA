using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BatBoxPIA.Vistas;
using BatBoxPIA.Database;
using BatBoxPIA.Vistas.AccessApp;
using BatBoxPIA.Data;
    

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

        static SQLiteHelper db;

        public static SQLiteHelper SQLiteDB
        {
            get 
            { 
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BatBoxPIA.db3"));
                }
                return db;
            }
        }
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
