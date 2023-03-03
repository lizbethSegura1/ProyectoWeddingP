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
    public partial class NewUser : Window
    {
        Database db;
        public NewUser()
        {
            InitializeComponent();
            db = new Database();
   
        }

      

        private void OnCreateUser(object sender, RoutedEventArgs e)
        {
            User u = new User();
            u.Email = Email.Text;
            u.Nombre = Name.Text;
            u.Password = Passwd.Text;
            u.Boda = Boda.Text;
            db.setUser(u);
            Close();
       
        }


    }
}
