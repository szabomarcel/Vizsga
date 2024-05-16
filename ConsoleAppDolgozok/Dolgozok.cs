using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDolgozok
{
    internal class Dolgozok
    {
        public int dolgozoid;
        public string nev;
        public string neme;
        public string reszleg;
        public int belepesev;
        public int ber;

        public Dolgozok(int dolgozoid, string nev, string neme, string reszleg, int belepesev, int ber)
        {
            this.dolgozoid = dolgozoid;
            this.nev = nev;
            this.neme = neme;
            this.reszleg = reszleg;
            this.belepesev = belepesev;
            this.ber = ber;
        }
    }
}
