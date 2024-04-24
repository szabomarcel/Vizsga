using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Dolgozo> dolgozok;
        static void Main(string[] args)
        {
            dolgozok = db.getAllDolgozo();
            feladat1();
            feladat2();
            feladat3();
            feladat4();
            Console.WriteLine("Program vége!");
            Console.ReadLine();
        }

        private static void feladat4()
        {
            Console.WriteLine("\n4. Feladat");
            foreach (var item in dolgozok.FindAll(a => a.reszleg == "asztalosműhely"))
            {
                Console.WriteLine($"\tKilistázzot asztalosműhely dolgozók nevét: {item.nev}; {item.reszleg};");
            }
        }

        private static void feladat3()
        {
            Console.WriteLine("\n3. Feladat: ");
            foreach (var item in dolgozok.GroupBy(a => a.reszleg).Select(b => new {reszleg = b.Key, letszam = b.Count()}).OrderBy(c=>c.reszleg))
            {
                Console.WriteLine($"\tHányan dolgoznak van az egyes részlegeken: {item.reszleg}; {item.letszam} fő");
            }
        }

        private static void feladat2()
        {
            Console.WriteLine("\n2. Feladat: ");
            int maxBer = dolgozok.Max(a => a.ber);
            Dolgozo dolgozo = dolgozok.Find(a => a.ber == maxBer);
            Console.WriteLine($"\tLegmagasabb keresetű dolgozó neve: {dolgozo.nev}, Bér: {dolgozo.ber}");
        }

        private static void feladat1()
        {
            Console.WriteLine("1. Feladat: ");
            Console.WriteLine($"\tA dolgozók számát: {dolgozok.Count} fő");
        }
    }
}
