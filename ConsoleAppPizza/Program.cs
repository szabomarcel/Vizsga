using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPizza
{
    internal class Program
    {
        static Database db = new Database();
        static List<Futar> futarok = new List<Futar>();
        static List<Futar> Topfutar = new List<Futar>();
        static List<Futar> osszertek = new List<Futar>();
        static void Main(string[] args)
        {
            futarok = db.getAllfutarok();
            Topfutar = db.getTopfutarok();
            osszertek = db.getossz();
            feladat01();
            feladat02();
            feladat03();
            Console.WriteLine("\nProgram vége");
            Console.ReadLine();
        }

        private static void feladat03()
        {
            //Hányan dolgoznak az egyes részlegeken
            Console.WriteLine("\n3. feladat");
            Console.WriteLine($"\tAz összes kiszállított pizza értéke: {osszertek[0].osszpizza}");
        }

        private static void feladat02()
        {
            //A legkisebb értékben értékesítő futár nevét írja ki 
            Console.WriteLine("\n2. feladat");
            foreach (var f in Topfutar)
            {
                Console.WriteLine($"\t{f.fnev} - {f.ertek}");
            }
        }

        private static void feladat01()
        {
            //Írja ki a futárok adatait
            Console.WriteLine("1. feladat");
            foreach (var f in futarok)
            {
                Console.WriteLine($"\t{f.fazon}, {f.fnev}, {f.ftel}");
            }
        }
    }
}
