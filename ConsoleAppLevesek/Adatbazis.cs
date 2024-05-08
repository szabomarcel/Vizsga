using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAppLevesek
{
    internal class Adatbazis
    {
        MySqlCommand sqlCommand;
        MySqlConnection connection;
        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "etelek";
            connection = new MySqlConnection(builder.ConnectionString);
            sqlCommand = connection.CreateCommand();
            try
            {
                kapcsolatNyit();
                kapcsolatZar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void kapcsolatZar()
        {
            if(connection.State != System.Data.ConnectionState.Closed) 
            {
                connection.Close();
            }
        }

        private void kapcsolatNyit()
        {
            if(connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        internal List<Leves> getAllLeves()
        {
            List<Leves> levesek = new List<Leves>();
            sqlCommand.CommandText = "SELECT `levesekkod`, `megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost` FROM `levesek`";
            kapcsolatNyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Leves levese = new Leves(dr.GetInt32("levesekkod"), dr.GetString("megnevezes"), dr.GetInt32("kaloria"), dr.GetInt32("feherje"), dr.GetInt32("zsir"), dr.GetInt32("szenhidrat"), dr.GetInt32("hamu"), dr.GetInt32("rost"));
                    levesek.Add(levese);
                }
            }
            kapcsolatZar();
            return levesek;
        }
    }
}
