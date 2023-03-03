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
        public PaginaPrincipal(String boda, DateTime fecha)
        {
            InitializeComponent();
            tabControl.SelectionChanged += MyTabControl_SelectionChanged;
            this.boda = boda;
            FechaBoda.SelectedDate = fecha;
           // CalcularCuentaRegresiva();



        }

        private String boda;

        Database db = new Database();
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
                    CalcularCuentaRegresiva();
                    
                    break;
                case "tabProveedores":
                    // Agregar los controles necesarios dentro del TabItem2
                    break;
                case "tabTareas":
                    if (listBoxTareas.Items.Count > 0)
                        break;
                    
                    tareas = db.getTarea(boda);
                    listBoxTareas.Items.Clear();
                    foreach (String s in tareas)
                        listBoxTareas.Items.Add(s);
                    break;
                case "tabInvitados":
                    // Agregar los controles necesarios dentro del TabItem4
                    if (listBoxInvitados.Items.Count > 0)
                        break;
                   
                    invitados = db.getInvitados(boda);
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
        
        
        private void OnTabButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            TabControl tb = tabControl as TabControl;
            switch(btn.Name)
            {
                case "botonInvitados":

                    tabControl.SelectedIndex = 3;
                    
                   
                    break;
                case "botonTareas":

                    tabControl.SelectedIndex = 2;


                    break;


            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GuardarFecha(object sender, RoutedEventArgs e)
        {
            DateTime fechaBoda = FechaBoda.SelectedDate.Value;
            db.guardarFecha(boda,fechaBoda);
        }

        private void CalcularCuentaRegresiva()
        {
            if (FechaBoda.SelectedDate == null)
            {
                CuentaRegresiva.Text = "FECHA NO FIJADA";
                return;
            }
            DateTime fechaBoda = FechaBoda.SelectedDate.Value;
            TimeSpan tiempoRestante = fechaBoda - DateTime.Now;
            CuentaRegresiva.Text = string.Format("Faltan {0} días, {1} horas, {2} minutos y {3} segundos para la boda.", tiempoRestante.Days, tiempoRestante.Hours, tiempoRestante.Minutes, tiempoRestante.Seconds);
        }

        private void MiMetodoLoaded(object sender, RoutedEventArgs e)
        {
            CalcularCuentaRegresiva();
        }

        private void eliminarInvitado(int indice)
        {
            
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
            ag.Show();
            agregarInvitado(ag.Nombre);
            Close();
        }

       
        private void OnClickCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
            private void eliminarTarea(int indice)
        {

            String tarea = listBoxTareas.Items.GetItemAt(indice) as String;
            db.eliminarTarea(boda, tarea);
            tareas.RemoveAt(indice);
            listBoxTareas.Items.RemoveAt(indice);
        }

        private void OnClickTareaRealizada(object sender, RoutedEventArgs e)
        {
            {
                if (listBoxTareas.SelectedIndex >= 0)
                {
                    eliminarTarea(listBoxTareas.SelectedIndex);
                }
            };
        }
        

        private void OnClickNuevaTarea(object sender, RoutedEventArgs e)
        {
            agregarNuevaTarea ag = new agregarNuevaTarea();
            ag.ShowDialog();
            AgregarTarea(ag.Nombre);
        }


        private List<string> invitados = new List<string>();
        private List<string> tareas = new List<string>();

        public string Boda { get => boda; set => boda = value; }
        public string Boda1 { get => boda; set => boda = value; }

        private void agregarInvitado(string nombre)
        {
            invitados.Add(nombre);
            listBoxInvitados.Items.Add(nombre);
            db.insertarInvitado(boda, nombre, false);
        }

        private void AgregarTarea(string nombre)
        {
            tareas.Add(nombre);
            listBoxTareas.Items.Add(nombre);
            db.insertarTarea(boda,nombre, false);
        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
