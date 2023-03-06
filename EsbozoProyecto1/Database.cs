
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace EsbozoProyecto1
{
    class Database
    {
        public void CreateDB()
        {
            if(File.Exists("wedding.sqlite"))
                return;
            SQLiteConnection.CreateFile("wedding.sqlite");
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS users ( 
                    name TEXT not null,
                    email TEXT not null,
                    passwd TEXT ,
                    emailBoda TEXT, 
                    fecha DATE
                );";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS invitados ( 
                    boda TEXT not null,
                    name TEXT not null,
                    confirmado TEXT
                );";
                command.ExecuteNonQuery();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS tareas ( 
                    boda TEXT not null,
                    tarea TEXT not null,
                    confirmado TEXT
                );";
                command.CommandText = @"CREATE TABLE IF NOT EXISTS proveedores ( 
                    boda TEXT not null,
                    empresa TEXT not null,
                    servicio TEXT,
                    coste REAL
                );";
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void guardarProveedor(Proveedor prov)
        {
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                insert into proveedores(boda, empresa, servicio, coste) values ($boda, $empresa, $servicio, $coste)
                ";
                command.Parameters.AddWithValue("$boda", prov.Boda);
                command.Parameters.AddWithValue("$empresa", prov.Empresa);
                command.Parameters.AddWithValue("$servicio", prov.Servicio);
                command.Parameters.AddWithValue("$coste", prov.Coste);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public bool calcularPresupuesto(String boda, Double presupuesto, out Double coste)
        {
            coste = 0;
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT sum(coste)
                FROM proveedores
                WHERE boda = $boda
                ";
                command.Parameters.AddWithValue("$boda", boda);

                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                         coste = reader.GetDouble(0);




                    }
                }
                connection.Close();
            }
            return presupuesto >= coste;
        }
        public List<Proveedor> getProveedores(String boda)
        {
            List<Proveedor> l = new List<Proveedor>();

            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT empresa, servicio, coste
                FROM proveedores
                WHERE boda = $boda
                ";
                command.Parameters.AddWithValue("$boda", boda);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Proveedor p = new Proveedor();
                        p.Empresa = reader.GetString(0);
                        p.Servicio = reader.GetString(1);
                        p.Coste = reader.GetDouble(2);

                        l.Add(p);


                    }
                }
                connection.Close();
            }

            return l;

        }

        public void guardarFecha(String boda, DateTime fecha)
        {

            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                update  users set fecha=$fecha where email=$boda
                ";
                command.Parameters.AddWithValue("$boda", boda);
                String fechaFmt = fecha.ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.AddWithValue("$fecha", fechaFmt); // yyyy-MM-dd HH:mm:ss
                command.ExecuteNonQuery();

                connection.Close();

            }
        }
            public void insertarInvitado(String boda, String invitado, Boolean confirmado)
        {
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                insert into invitados(boda, name, confirmado) values ($boda, $invitado, $confirmado)
                ";
                command.Parameters.AddWithValue("$boda", boda);
                command.Parameters.AddWithValue("$invitado", invitado);
                command.Parameters.AddWithValue("$confirmado", confirmado ? "SI" : "NO");
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void eliminarInvitado(String boda, String invitado)
        {
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                delete from invitados where boda =$boda and name=$invitado
                ";
                command.Parameters.AddWithValue("$boda", boda);
                command.Parameters.AddWithValue("$invitado", invitado);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }


        // tareas
        public void insertarTarea(String boda, String tarea,Boolean confirmado)
        {
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                insert into tareas(boda,tarea,confirmado) values ($boda,$tarea, $confirmado)
                ";
                command.Parameters.AddWithValue("$boda", boda);
                command.Parameters.AddWithValue("$tarea", tarea);
                command.Parameters.AddWithValue("$confirmado", confirmado ? "SI" : "NO");
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void eliminarTarea(String boda, String tarea)
        {
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                delete from tareas where boda =$boda and tarea=$tarea
                ";
                command.Parameters.AddWithValue("$boda", boda);
                command.Parameters.AddWithValue("$tarea", tarea);
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
        public User getUser(String email, String password)
        {
            User user = null;

            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, fecha
                FROM users
                WHERE email = $email and passwd = $passwd
                ";
                command.Parameters.AddWithValue("$email", email);
                command.Parameters.AddWithValue("$passwd", password);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User();
                        var name = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                        {
                            var fech = reader.GetDateTime(1);
                            user.Fecha = fech;
                        }
                       
                        user.Email = email;
                        user.Nombre = name;
                        user.Password = password;
                        

                        Console.WriteLine($"Hello, {name}!");
                    }
                }
                connection.Close();
            }

            return user;

        }
        public List<String> getInvitados(String boda)
        {
            List<String> l = new List<String>();

            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name
                FROM invitados
                WHERE boda = $boda
                ";
                command.Parameters.AddWithValue("$boda", boda);
                

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        l.Add(name);

                        
                    }
                }
                connection.Close();
            }

            return l;

        }

        public List<String> getTarea(String boda)
        {
            List<String> tareas = new List<String>();

            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT tarea
                FROM tareas
                WHERE boda = $boda and confirmado='NO'
                ";
                command.Parameters.AddWithValue("$boda", boda);


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        tareas.Add(name);


                    }
                }
                connection.Close();
            }

            return tareas;

        }

        public void setUser(User user)
        {
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"INSERT INTO USERS (email, name, passwd, emailBoda) values ($email, $name, $password, $boda)";
                
                command.Parameters.AddWithValue("$email", user.Email);
                command.Parameters.AddWithValue("$name", user.Nombre);
                command.Parameters.AddWithValue("$password", user.Password);
                command.Parameters.AddWithValue("$boda", user.Boda);
                command.ExecuteNonQuery();
                connection.Close();


            }

        }
    }
}
