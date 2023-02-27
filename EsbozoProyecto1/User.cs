using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbozoProyecto1
{
    class User
    {
        private String nombre;
        private String email;
        private String password;
        private String boda;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Boda { get => boda; set => boda = value; }
    }
}
