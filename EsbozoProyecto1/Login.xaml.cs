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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Database db;
        public Login()
        {
            InitializeComponent();
            db = new Database();
          
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            
            User u = db.getUser(Email.Text, Passwd.Password);
            if (u == null)
                MessageBox.Show("Usuario no localizado");
            else
            {
                PaginaPrincipal p = new PaginaPrincipal(u.Email, u.Fecha);
                p.Show();
                this.Close();
            }
               
        }

        private void OnCreateUser(object sender, RoutedEventArgs e)
        {
            NewUser alta = new NewUser();
            alta.ShowDialog();
        }
    }
}
