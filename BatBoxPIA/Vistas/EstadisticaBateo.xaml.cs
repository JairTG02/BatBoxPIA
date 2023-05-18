using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatBoxPIA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using BatBoxPIA.Data;
using BatBoxPIA.Database;
using System.ComponentModel;

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

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                EstadisticaBateoModel bateo = new EstadisticaBateoModel
                {
                    NombreBateador = txtNombreJugador.Text,
                    VecesAlBat = int.Parse(txtVecesAlBat.Text),
                    HR = int.Parse(txtHR.Text),
                    Hits = int.Parse(txtHits.Text),
                    BasesPorBola = int.Parse(txtBB.Text),
                    Dobletes = int.Parse(txtDobletes.Text),
                    BasesPorGolpe = int.Parse(txtHBP.Text),
                    Tripletes = int.Parse(txtTripletes.Text),
                    Sacrificios = int.Parse(txtSAC.Text),
                    AVG = float.Parse(txtAVG.Text), 
                    OBP = float.Parse(txtOBP.Text),
                    SLUG = float.Parse(txtSlugging.Text),
                    OPS = float.Parse(txtOPS.Text)
                };

                await App.SQLiteDB.SaveBateoAsync(bateo);

                txtNombreJugador.Text = "";
                txtHR.Text = "";
                txtHits.Text = "";
                txtBB.Text = "";
                txtDobletes.Text = "";
                txtHBP.Text = "";
                txtTripletes.Text = "";
                txtSAC.Text = "";
                txtAVG.Text = "";
                txtOBP.Text = "";
                txtSlugging.Text = "";
                txtOPS.Text = "";

                await DisplayAlert("Registro", "Se guardo de manera exitosa", "OK");

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
            else if (string.IsNullOrEmpty(txtVecesAlBat.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtHR.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtHits.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtBB.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDobletes.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtHBP.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTripletes.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtSAC.Text))
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