using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EsbozoProyecto1
{
    /// <summary>
    /// Lógica de interacción para agregarNuevaTarea.xaml
    /// </summary>
    public partial class agregarNuevaTarea : Window
    {
        public agregarNuevaTarea()
        {
            InitializeComponent();
        }

        public String nombre;
        public string Nombre { get => nombre; set => nombre = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nombre = tareaNueva.Text;
            Close();
        }
    }
}
