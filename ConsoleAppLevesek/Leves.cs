using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLevesek
{
    internal class Leves
    {
        public int levesekkod;
        public string megnevezes;
        public int kaloria;
        public int feherje;
        public int zsir;
        public int szenhidrat;
        public int hamu;
        public int rost;

        public Leves(int levesekkod, string megnevezes, int kaloria, int feherje, int zsir, int szenhidrat, int hamu, int rost)
        {
            this.levesekkod = levesekkod;
            this.megnevezes = megnevezes;
            this.kaloria = kaloria;
            this.feherje = feherje;
            this.zsir = zsir;
            this.szenhidrat = szenhidrat;
            this.hamu = hamu;
            this.rost = rost;          
        }
    }
}
