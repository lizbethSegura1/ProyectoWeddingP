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
        public PaginaPrincipal(String boda)
        {
            InitializeComponent();
            tabControl.SelectionChanged += MyTabControl_SelectionChanged;
            this.boda = boda;

        }

        private String boda;


        private void MyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            // Obtener el TabControl
            TabControl tabControl = sender as TabControl;

            // Obtener el TabItem activo
            TabItem selectedItem = tabControl.SelectedItem as TabItem;

            // Usar una estructura switch para determinar qué pestaña se ha activado
            switch (selectedItem.Name)
            {
                case "tabInicio":
                    
                    break;
                case "tabProveedores":
                    // Agregar los controles necesarios dentro del TabItem2
                    break;
                case "tabTareas":
                    // Agregar los controles necesarios dentro del TabItem3
                    break;
                case "tabInvitados":
                    // Agregar los controles necesarios dentro del TabItem4
                    if (listBoxInvitados.Items.Count > 0)
                        break;
                    Database DB = new Database();
                    invitados = DB.getInvitados(boda);
                    listBoxInvitados.Items.Clear();
                    foreach (String s in invitados)
                        listBoxInvitados.Items.Add(s);
                    break;
        
                case "tabPresupuesto":
                    // Agregar los controles necesarios dentro del TabItem4
                    break;
                default:
                    break;
            }
        }
        /*
        private void tabControl_selecredIndexChanged(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex+
            ActualizarInterfaz();
        }
        */
        private void OnTabButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            TabControl tb = tabControl as TabControl;
            switch(btn.Name)
            {
                case "botonInvitados":

                    tabControl.SelectedIndex = 3;
                    
                   
                    break;


            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void eliminarInvitado(int indice)
        {
            Database db = new Database();
            String invitado = listBoxInvitados.Items.GetItemAt(indice) as String;
            db.eliminarInvitado(boda, invitado );
            invitados.RemoveAt(indice);
            listBoxInvitados.Items.RemoveAt(indice);
        }
        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxInvitados.SelectedIndex >= 0)
            {
                eliminarInvitado(listBoxInvitados.SelectedIndex);
            }
        }
        private void OnClickAgregar(object sender, RoutedEventArgs e)
        {
            agregarInvitado ag = new agregarInvitado();
            ag.ShowDialog();
            agregarInvitado(ag.Nombre);


        }

        private List<string> invitados = new List<string>();

        public string Boda { get => boda; set => boda = value; }
        public string Boda1 { get => boda; set => boda = value; }

        private void agregarInvitado(string nombre)
        {
            invitados.Add(nombre);
            listBoxInvitados.Items.Add(nombre);
            Database db = new Database();
            db.insertarInvitado(boda, nombre, false);
        }

        private void checkBoxConfirmado_CheckedChanged(object sender, EventArgs e)
        {
            if (listBoxInvitados.SelectedIndex >= 0)
            {
                confirmarInvitado(listBoxInvitados.SelectedIndex, checkBoxConfirmado.IsChecked.Value);
            }
        }

        private void confirmarInvitado(int indice, bool confirmado)
        {
            invitados[indice] = (confirmado ? "✔ " : "") + invitados[indice];
            listBoxInvitados.Items[indice] = invitados[indice];
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (listBoxInvitados.SelectedIndex >= 0)
            {
                confirmarInvitado(listBoxInvitados.SelectedIndex, true);
            }
        }
    }
}
