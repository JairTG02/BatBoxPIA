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
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnBateo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EstadisticaBateo());
        }

        private void btnPitcheo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EstadisticaPitcheo());

        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicial());
        }

        private void btnEstadisticasBateo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataViewBateo());
        }

        private void btnEstadisticasPitcheo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataViewPitcheo());
        }
    }
}