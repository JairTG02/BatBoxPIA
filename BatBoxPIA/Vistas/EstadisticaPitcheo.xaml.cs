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

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            string JsonPitcheoRuta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), @"Data\EstadisticaPitcheo.json");

            List<EstadisticaPitcheoModel> _TablaDatos = JsonConvert.DeserializeObject<List<EstadisticaPitcheoModel>>(File.ReadAllText(JsonPitcheoRuta)) ?? new List<EstadisticaPitcheoModel>();


            if (string.IsNullOrEmpty(txtNombreJugador.Text.Trim()) || txtIP.Text == "" || txtHitsPermitidos.Text == "" || txtCarrerasPermitidas.Text == "" ||
                txtBBPermitidos.Text == "")

            {
                DisplayAlert("Alert", "Es necesario que esten todos los valores", "Ok");
            }
            else
            {
                EstadisticaPitcheoModel fila = new EstadisticaPitcheoModel();
                fila.EntradasLanzadas = double.Parse(txtIP.Text);
                fila.Hits = int.Parse(txtHitsPermitidos.Text);
                fila.CarrerasPermitidas = int.Parse(txtCarrerasPermitidas.Text);
                fila.BasePorBolas = int.Parse(txtBBPermitidos.Text);
                fila.NombreJugador = txtNombreJugador.Text;
                fila.ERA = Math.Round(double.Parse(txtERA.Text), 3);
                fila.WHIP = Math.Round(double.Parse(txtWHIP.Text), 3);

                //_TablaDatos.Add(fila);
                //TablaDatosPitcher.DataSource = _TablaDatos;
                //TablaDatosPitcher.Refresh();

                var jsonSave = JsonConvert.SerializeObject(_TablaDatos);
                File.WriteAllText(JsonPitcheoRuta, jsonSave);

            }
        }
    }
}
