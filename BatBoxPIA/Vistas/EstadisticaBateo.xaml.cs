using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatBoxPIA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatBoxPIA.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstadisticaBateo : ContentPage
    {
        public EstadisticaBateo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            
                if (string.IsNullOrEmpty(
                    txtNombreJugador.Text.Trim()) ||
                    txtVecesAlBat.Text == "" ||
                    txtHits.Text == "" ||
                    txtDobletes.Text == "" ||
                    txtTripletes.Text == "" ||
                    txtHR.Text == "" ||
                    txtBB.Text == "" ||
                    txtHBP.Text == "" ||
                    txtSAC.Text == "")

                {
                    DisplayAlert("Alert", "Es necesrio esten todos los valores", "Ok");
                }
                else
                {
                    
                    double VecesAlBat = Convert.ToDouble(txtVecesAlBat.Text);
                    double Hits = Convert.ToDouble(txtHits.Text);
                    double Dobles = Convert.ToDouble(txtDobletes.Text);
                    double Triples = Convert.ToDouble(txtTripletes.Text);
                    double HR = Convert.ToDouble(txtHR.Text);
                    double Bolas = Convert.ToDouble(txtBB.Text);
                    double Golpe = Convert.ToDouble(txtHBP.Text);
                    double SF = Convert.ToDouble(txtSAC.Text);

                    double resultadoAVG = Hits / VecesAlBat;
                    txtAVG.Text = Math.Round(resultadoAVG, 3).ToString();

                    double resultadoOBP = (Hits + Bolas + Golpe) / (VecesAlBat + Bolas + Golpe + SF);
                    txtOBP.Text = Math.Round(resultadoOBP, 3).ToString();

                    double DobletesSlug = Dobles;
                    double TripletesSlug = Triples * 2;
                    double HRSlug = HR * 3;
                    double TotalSlug = Hits + DobletesSlug + TripletesSlug + HRSlug;

                    double resultadoSlug = TotalSlug / VecesAlBat;
                    txtSlugging.Text = Math.Round(resultadoSlug, 3).ToString();

                    double resultadoOPS = resultadoSlug + resultadoOBP;
                    txtOPS.Text = Math.Round(resultadoOPS, 3).ToString();


                }
        }
    }

}