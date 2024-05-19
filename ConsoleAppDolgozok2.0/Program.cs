using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDolgozok2._0
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Dolgozok2> elemek = new List<Dolgozok2>();
        static List<Dolgozok2> Topfizetes = new List<Dolgozok2>();
        static List<Dolgozok2> munkakor = new List<Dolgozok2>();
        static List<Dolgozok2> reszleg = new List<Dolgozok2>();
        static void Main(string[] args)
        {
            elemek = db.getDolgozok2s();
            Topfizetes = db.getDolgozok2s();
            munkakor = db.getDolgozok2s();
            reszleg = db.getDolgozok2s();
            var dolgozok2 = db.getDolgozok2s();
            feladat1();
            feladat2();
            feladat3();
            feladat4(dolgozok2);
            Console.WriteLine("\nPorgram vége");
            Console.ReadLine();
        }

        private static void feladat4(List<Dolgozok2> dolgozok2)
        {
            Console.WriteLine($"\n4. Feladat: ");
            var asztalasok = dolgozok2.Where(d => d.reszleg == "asztalosműhely").Select(d => d.nev);
            Console.WriteLine("\tAz asztalosműhelyen dolgozók: ");
            foreach(var nev in asztalasok)
            {
                Console.WriteLine($"\t{nev}");
            }
        }

        private static void feladat3()
        {
            Console.WriteLine("\n3. Feladat: ");
            var munkakorokSzam = munkakor.GroupBy(d => d.reszleg).Select(group => new {Munkakor = group.Key, Darab = group.Count()});
            foreach(var munkakor in munkakorokSzam)
            {
                Console.WriteLine($"\tMunkakör: {munkakor.Munkakor}; \t\n\nDolgotók száma: {munkakor.Darab}");
            }
        }

        private static void feladat2()
        {
            Console.WriteLine("\n2. Feladat: ");
            if(Topfizetes.Count > 0)
            {
                var legmagasabbFizetes = Topfizetes.OrderByDescending(d => d.ber).First();
                Console.WriteLine($"\tLegmagasabb fizetéssel rendelkező dolgozó: {legmagasabbFizetes.nev}");
            }
            else
            {
                Console.WriteLine($"\tNincs adat a legmagasabb fizetéssel rendelkező dolgozóról.");
            }
        }

        private static void feladat1()
        {
            Console.WriteLine($"1. Feladat: Elemek száma {elemek.Count}");
        }
    }
}
