using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using BatBoxPIA.Database;
using BatBoxPIA.Vistas.AccessApp;


namespace BatBoxPIA.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        #region Database
        static DatabaseQuerys database;

        public static DatabaseQuerys Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseQuerys(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BatBox.db"));
                }
                return database;
            }
        }
        #endregion

        public PaginaInicial()
        {
            InitializeComponent();
        }
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }


    }
}