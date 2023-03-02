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
    /// Lógica de interacción para PaginaPrincipal.xaml
    /// </summary>
    public partial class PaginaPrincipal : Window
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void OnTabButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.Content.ToString().Substring(button.Content.ToString().Length - 1)) - 1;
            tabControl.SelectedIndex = index;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

            private void TabInvitados(object sender, RoutedEventArgs e)
        {
            ListaInvitados miClase = new ListaInvitados(); //llamada a la clase listaInvitados
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
