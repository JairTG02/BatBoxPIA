using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BatBoxPIA.Models
{
    public class EstadisticaPitcheoModel
    {
        [DisplayName("Nombre del pitcher")]
        public string NombrePitcher { get; set; }
        [DisplayName("Entradas lanzadas")]
        public double EntradasLanzadas { get; set; }
        [DisplayName("Hits permitidos")]
        public int HitsPermitidos { get; set; }
        [DisplayName("Carreras permitidas")]
        public int CarrerasPerm { get; set; }
        [DisplayName("Base por bola permitidas")]
        public int BasePorBolaPerm { get; set; }
        public double ERA { get; set; }
        [DisplayName("ERA")]
        public string ERAStr
        {
            get { return string.Format("{0:0.000}", ERA); }
        }
        public double WHIP { get; set; }
        [DisplayName("WHIP")]
        public string WHIPStr
        {
            get { return string.Format("{0:0.000}", WHIP); }
        }
    }
}
