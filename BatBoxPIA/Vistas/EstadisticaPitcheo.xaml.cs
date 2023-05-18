using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BatBoxPIA.Models;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace BatBoxPIA.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstadisticaPitcheo : ContentPage
    {
        public EstadisticaPitcheo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreJugador.Text.Trim()) ||
                txtIP.Text == "" ||
                txtHitsPermitidos.Text == "" ||
                txtCarrerasPermitidas.Text == "" ||
                txtBBPermitidos.Text == "")

            {
                DisplayAlert("Alert", "Es necesario que esten todos los valores", "Ok");
            }
            else
            {

                int CarrerasPermitidas = Convert.ToInt32(txtCarrerasPermitidas.Text);
                double EntradasLanzadas = Convert.ToDouble(txtIP.Text);
                double BasePorBolas = Convert.ToDouble(txtBBPermitidos.Text);
                double Hits = Convert.ToDouble(txtHitsPermitidos.Text);

                double ERA = (((CarrerasPermitidas / EntradasLanzadas) * 9) * 10);
                txtERA.Text = Math.Round(ERA, 3).ToString();

                double WHIP = (((BasePorBolas + Hits) / EntradasLanzadas) * 10);
                txtWHIP.Text = Math.Round(WHIP, 3).ToString();

            }
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                EstadisticaPitcheoModel pitcheo = new EstadisticaPitcheoModel
                {
                    NombreJugador = txtNombreJugador.Text,
                    EntradasLanzadas = int.Parse(txtIP.Text),
                    Hits = int.Parse(txtHitsPermitidos.Text),
                    CarrerasPermitidas = int.Parse(txtCarrerasPermitidas.Text),
                    BasePorBolas = int.Parse(txtBBPermitidos.Text),
                    ERA = float.Parse(txtERA.Text),
                    WHIP = float.Parse(txtWHIP.Text)
                };

                await App.SQLiteDB.SavePitcheoAsync(pitcheo);

                txtNombreJugador.Text = "";
                txtIP.Text = "";
                txtHitsPermitidos.Text = "";
                txtCarrerasPermitidas.Text = "";
                txtBBPermitidos.Text = "";
                txtERA.Text = "";
                txtWHIP.Text = "";

                await DisplayAlert("Registro", "Se guardo de manera exitosa", "OK");
                var PitcheoList = await App.SQLiteDB.GetPitcheoAsync();
                if (PitcheoList != null)
                {
                    lstJugadoresPitcheo.ItemsSource = PitcheoList;
                }

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "OK");
            }
            
           
        }
        public bool ValidarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtNombreJugador.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtIP.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtHitsPermitidos.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCarrerasPermitidas.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtBBPermitidos.Text))
            {
                respuesta = false;

            }
            else 
            { 
                respuesta = true; 
            }
            return respuesta;
           
         }

        }
}
