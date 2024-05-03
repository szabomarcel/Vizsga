using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPizza
{
    internal class Futar
    {
        public int fazon;
        public string fnev;
        public string ftel;
        public int ertek;
        public int osszpizza;

        public Futar(int fazon, string fnev, string ftel, int ertek, int osszpizza)
        {
            this.fazon = fazon;
            this.fnev = fnev;
            this.ftel = ftel;
            this.ertek = ertek;
            this.osszpizza = osszpizza;
        }
    }
}
