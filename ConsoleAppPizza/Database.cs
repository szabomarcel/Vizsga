using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAppPizza
{
    internal class Database
    {
        MySqlCommand sqlCommand;
        MySqlConnection connection;
        public Database()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            connection = new MySqlConnection(builder.ConnectionString);
            sqlCommand = connection.CreateCommand();
            try
            {
                kapcsolatnyit();
                kapcsolatzar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        private void kapcsolatzar()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void kapcsolatnyit()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        internal List<Futar> getAllfutarok()
        {
            List<Futar> futarok = new List<Futar>();
            sqlCommand.CommandText = "SELECT futar.fazon, futar.fnev, futar.ftel from futar GROUP BY(futar.fnev) ORDER BY `fazon` ASC";
            kapcsolatnyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Futar fut = new Futar(dr.GetInt32("fazon"), dr.GetString("fnev"), dr.GetString("ftel"), 0, 0);
                    futarok.Add(fut);
                }
            }
            return futarok;
        }
        internal List<Futar> getossz()
        {
            List<Futar> futarok = new List<Futar>();
            sqlCommand.CommandText = "SELECT sum(db*par) as osszpizza FROM `pizza` NATURAL JOIN tetel";
            kapcsolatnyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Futar fut = new Futar(0, "", "", 0, dr.GetInt32("osszpizza"));
                    futarok.Add(fut);
                }
            }
            return futarok;
        }
        internal List<Futar> getTopfutarok()
        {
            List<Futar> futarok = new List<Futar>();
            sqlCommand.CommandText = "SELECT futar.fazon, futar.fnev,  futar.ftel, SUM(db*pizza.par) as ertek from futar NATURAL JOIN rendeles NATURAL JOIN tetel NATURAL JOIN pizza GROUP BY(futar.fnev) ORDER BY `ertek` ASC limit 1";
            kapcsolatnyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Futar fut = new Futar(dr.GetInt32("fazon"), dr.GetString("fnev"), dr.GetString("ftel"), dr.GetInt32("ertek"), 0);
                    futarok.Add(fut);
                }
            }
            return futarok;
        }
    }
}
