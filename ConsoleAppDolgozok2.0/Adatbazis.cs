using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAppDolgozok2._0
{
    internal class Adatbazis
    {
        MySqlCommand sqlcommand;
        MySqlConnection connection;
        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dolgozok";
            connection = new MySqlConnection(builder.ConnectionString);
            sqlcommand = connection.CreateCommand();
            try
            {
                kapcsolatnyit();
                kapcsolatzar();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void kapcsolatzar()
        {
            if(connection.State != System.Data.ConnectionState.Closed)
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

        internal List<Dolgozok2> getDolgozok2s()
        {
            List<Dolgozok2> dolgozok2 = new List<Dolgozok2>();
            sqlcommand.CommandText = "SELECT `dolgozoid`, `nev`, `neme`, `reszleg`, `belepesev`, `ber` FROM `dolgozok` WHERE 1";
            kapcsolatnyit();
            using (MySqlDataReader dr = sqlcommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dolgozok2 dolgozo21 = new Dolgozok2(dr.GetInt32("dolgozoid"), dr.GetString("nev"), dr.GetString("neme"), dr.GetString("reszleg"), dr.GetInt32("belepesev"), dr.GetInt32("ber"));
                    dolgozok2.Add(dolgozo21);
                }
            }
            kapcsolatzar();
            return dolgozok2;
        }
    }
}
