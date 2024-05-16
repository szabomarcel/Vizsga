using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDolgozok
{
    internal class Program
    {
        static Database db = new Database();
        static List<Dolgozok> elemek = new List<Dolgozok>();
        static List<Dolgozok> Topfizetes = new List<Dolgozok>();
        static List<Dolgozok> munkakor = new List<Dolgozok>();
        static List<Dolgozok> reszleg = new List<Dolgozok>();
        static void Main(string[] args)
        {
            elemek = db.getAlldolgozok();
            Topfizetes = db.getAlldolgozok();
            munkakor = db.getAlldolgozok();
            reszleg = db.getAlldolgozok();
            var dolgozok = db.getAlldolgozok();
            feladat01();
            feladat02();
            feladat03();
            feladat04(dolgozok);
            Console.WriteLine("\nProgram vége");
            Console.ReadLine();
        }

        private static void feladat04(List<Dolgozok> dolgozok)
        {
            // Adott részlegen dolgozó neve.
            Console.WriteLine("\n4. Feladat: ");
            var asztalasok = dolgozok.Where(d => d.reszleg == "asztalosműhely").Select(d => d.nev);
            Console.WriteLine("\tAz asztalosműhelyen dolgozók:");
            foreach (var nev in asztalasok)
            {
                Console.WriteLine($"\t{nev}");
            }
        }

        private static void feladat03()
        {
            Console.WriteLine("\n3. feladat");
            // Munkakörök számolása
            var munkakorokSzama = munkakor.GroupBy(d => d.reszleg).Select(group => new { Munkakor = group.Key, Darab = group.Count() });
            foreach (var munkakor in munkakorokSzama)
            {
                Console.WriteLine($"\tMunkakör: {munkakor.Munkakor}, Dolgozók száma: {munkakor.Darab}");
            }
        }

        private static void feladat02()
        {
            Console.WriteLine("\n2. feladat");
            if (Topfizetes.Count > 0)
            {
                // Kiírjuk a legmagasabb fizetéssel rendelkező dolgozó nevét
                var legmagasabbFizetes = Topfizetes.OrderByDescending(d => d.ber).First();
                Console.WriteLine($"\tLegmagasabb fizetéssel rendelkező dolgozó: {legmagasabbFizetes.nev}");
            }
            else
            {
                Console.WriteLine("\tNincs adat a legmagasabb fizetéssel rendelkező dolgozóról.");
            }
        }

        private static void feladat01()
        {
            Console.WriteLine("1. feladat");
            // Kiírjuk az elemek számát
            Console.WriteLine($"\tElemek száma: {elemek.Count}");
        }
    }
}
