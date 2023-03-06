using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsbozoProyecto1
{
    class Proveedor
    {
        private String empresa;
        private String boda;
        private String servicio;
        private Double coste;

        public string Empresa { get => empresa; set => empresa = value; }
        public string Boda { get => boda; set => boda = value; }
        public string Servicio { get => servicio; set => servicio = value; }
        public double Coste { get => coste; set => coste = value; }

        public string ToString () {return "Empresa:" + Empresa + " Servicio: " + Servicio + " Coste: " + Coste; }
    }
}
