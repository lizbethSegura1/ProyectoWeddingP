
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
                    passwd TEXT not null,
                    emailBoda TEXT 
                );";
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
                SELECT name
                FROM users
                WHERE email = $email and passwd = $passwd
                ";
                command.Parameters.AddWithValue("$email", email);
                command.Parameters.AddWithValue("$passwd", password);

                using (var reader = command.ExecuteReader())
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
