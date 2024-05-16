using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOrarend
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Orarend> tantargy = new List<Orarend>();
        static List<Orarend> sorszam = new List<Orarend>();
        static List<Orarend> hetnapja = new List<Orarend>();
        static void Main(string[] args)
        {
            feladat01();
            feladat02();
            feladat03();
            Console.WriteLine("\nProgram vége");
            Console.ReadLine();
        }

        private static void feladat03()
        {
            Console.WriteLine("\n3. Feladat: ");
        }

        private static void feladat02()
        {
            Console.WriteLine("\n2. Feladat: ");
            //int maxSorszam = sorszam.Max(a => a.sorszam);
            //Orarend sor = sorszam.Find(a => a.sorszam == maxSorszam);
            //Console.WriteLine($"\tLegmagasabb sorszám: {sor.sorszam}");
        }

        private static void feladat01()
        {
            Console.WriteLine($"1. Feladat: {sorszam.Count}");            
        }
    }
}
