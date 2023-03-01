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
    /// Lógica de interacción para ListaInvitados.xaml
    /// </summary>
    public partial class ListaInvitados : Window
    {
        public ListaInvitados()
        {
            InitializeComponent();

        }

        private List<string> invitados = new List<string>();

        private void agregarInvitado(string nombre)
        {
            invitados.Add(nombre);
            listBoxInvitados.Items.Add(nombre);
        }

        private void eliminarInvitado(int indice)
        {
            invitados.RemoveAt(indice);
            listBoxInvitados.Items.RemoveAt(indice);
        }

        private void confirmarInvitado(int indice, bool confirmado)
        {
            invitados[indice] = (confirmado ? "✔ " : "") + invitados[indice];
            listBoxInvitados.Items[indice] = invitados[indice];
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del invitado:", "Agregar invitado", "");
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                agregarInvitado(nombre);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxInvitados.SelectedIndex >= 0)
            {
                eliminarInvitado(listBoxInvitados.SelectedIndex);
            }
        }

        private void checkBoxConfirmado_CheckedChanged(object sender, EventArgs e)
        {
            if (listBoxInvitados.SelectedIndex >= 0)
            {
                confirmarInvitado(listBoxInvitados.SelectedIndex, checkBoxConfirmado.Checked);
            }
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (listBoxInvitados.SelectedIndex >= 0)
            {
                confirmarInvitado(listBoxInvitados.SelectedIndex, true);
            }
        }

        private void agregar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
