using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BatBoxPIA.Models;

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
                DisplayAlert("Alert", "Es necesrio esten todos los valores", "Ok");
            }
            else
            {
                
                int CarrerasPermitidas = Convert.ToInt32(txtCarrerasPermitidas.Text);
                double EntradasLanzadas = Convert.ToDouble(txtIP.Text);
                double BasePorBolas = Convert.ToDouble(txtBBPermitidos.Text);
                double Hits = Convert.ToDouble(txtHitsPermitidos.Text);

               
                
                double ERA = (((CarrerasPermitidas / EntradasLanzadas) * 9)*10);
                txtERA.Text = Math.Round(ERA, 3).ToString();

                double WHIP = (((BasePorBolas + Hits) / EntradasLanzadas)*10);
                txtWHIP.Text = Math.Round(WHIP, 3).ToString();


            }
        }
    }
}