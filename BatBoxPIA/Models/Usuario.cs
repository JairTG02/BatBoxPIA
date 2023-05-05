using System;
using System.Collections.Generic;
using System.Text;

namespace BatBoxPIA.Models
{
    public class Usuario
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Usuario> GetUsuarios()
        {
            var list = new List<Usuario>();
            list.Add(new Usuario { UserName = "Admin", Password = "pass123" });
            list.Add(new Usuario { UserName = "Profe", Password = "pass123" });
            return list;
        }
    }
}
