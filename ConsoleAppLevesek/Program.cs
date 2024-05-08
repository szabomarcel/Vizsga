using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLevesek
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Leves> levesek;
        static void Main(string[] args)
        {
            levesek = db.getAllLeves();
            feladat1();
            feladat2();
            Console.WriteLine("Program vége!");
            Console.ReadLine();
        }

        private static void feladat1()
        {
            Console.WriteLine($"1. Feladat: Leveszek széma: {levesek.Count}");
        }

        private static void feladat2()
        {
            Console.WriteLine("\n2. Feladat: ");
            int maxKaloria = levesek.Max(a => a.kaloria);
            Leves levese = levesek.Find(a => a.kaloria == maxKaloria);
            Console.WriteLine($"\tLegmagasabb kalóriáju leves neve: {levese.megnevezes}, Kalória: {levese.kaloria}");
        }
    }
}
