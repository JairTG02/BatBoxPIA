using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatBoxPIA.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Menu());

            if (txtUsuario.Text == "JairTG")
            {
                if (txtPassword.Text == "1234")
                {
                    DisplayAlert("Success", "Bienvenido al sistema" + "" + txtUsuario.Text, "Continue");

                }
                else
                {
                    DisplayAlert("Alert", "Error, Contraseña incorrecta para el usuario asignado", "Ok");
                }
            }
            else
            {
                DisplayAlert("Alert", "Error, el usuario no existe o no es correcto", "Ok");
            }

            if (txtUsuario.Text == "")
            {
                DisplayAlert("Alert", "Favor de ingresar datos", "Ok");

            }
           
        }

        private void btnRegresarLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicial());
        }

    }
}