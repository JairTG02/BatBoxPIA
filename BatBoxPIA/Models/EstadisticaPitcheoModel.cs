using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace BatBoxPIA.Models
{
    public class EstadisticaPitcheoModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdJugador { get; set; }
        [MaxLength(50)]

        [DisplayName("Nombre del pitcher")]
        public string NombreJugador { get; set; }
        [MaxLength(50)]

        [DisplayName("Entradas lanzadas")]
        public double EntradasLanzadas { get; set; }
        [DisplayName("Hits permitidos")]
        public int Hits { get; set; }
        [DisplayName("Carreras permitidas")]
        public int CarrerasPermitidas { get; set; }
        [DisplayName("Base por bola permitidas")]
        public double BasePorBolas { get; set; }
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
