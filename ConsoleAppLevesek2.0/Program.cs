using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLevesek2._0
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Levesek> leves;
        static void Main(string[] args)
        {
            leves = db.getAlllevesek();
            feladat1();
            feladat2();
            Console.WriteLine("\nProgram vége!");
            Console.ReadLine();
        }

        private static void feladat2()
        {
            Console.WriteLine("\n2. Feladat: ");
            int maxKaloria = leves.Max(a => a.kaloria);
            Levesek levese = leves.Find(a => a.kaloria == maxKaloria);
            Console.WriteLine($"\tLegmagasabb kalóriájú leves neve: {levese.megnevezes}; Kalória: {levese.kaloria}");
        }

        private static void feladat1()
        {
            Console.WriteLine($"1. Feladat: Levesek száma: {leves.Count}");
        }
    }
}
