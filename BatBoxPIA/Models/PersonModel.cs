using System;
using SQLite;

namespace BatBoxPIA.Models
{
    public class PersonModel
    {
        [PrimaryKey, AutoIncrement]
        public int PersonID { get; set; }

        [MaxLength(30)]
        public string NameField { get; set; }

        [MaxLength(2)]
        public string AgeField { get; set; }

    }
}
