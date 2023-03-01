
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EsbozoProyecto1
{
    class Database
    {
        public void CreateDB()
        {
            //creacion de la bbdd
            //creacion de la tabla users con 4 columnas 
            SQLiteConnection.CreateFile("wedding.sqlite");
            using (var connection = new SQLiteConnection("Data Source=wedding.sqlite")) //conexion con ddbb y creacion del bin
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS users ( 
                    name TEXT not null,
                    email TEXT not null,
                    passwd TEXT not null,
                    emailBoda TEXT 
                );";
                command.ExecuteNonQuery(); //ejecuta las querys
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
                SELECT name
                FROM users
                WHERE email = $email and passwd = $passwd
                ";
                command.Parameters.AddWithValue("$email", email);
                command.Parameters.AddWithValue("$passwd", password);

                using (var reader = command.ExecuteReader())
                // ExecuteReader() para ejecutar la consulta y devolver un objeto SQLiteDataReader,
                // que se usa para leer los resultados devueltos por la consulta
                {
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        user = new User();
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
