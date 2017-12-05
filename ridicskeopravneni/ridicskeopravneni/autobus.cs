using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridicskeopravneni
{
    class autobus : auto
    {

        private int pocetMist;
        static int Mist = 0;

        public int PocetMist
        {
            get { return pocetMist; }
            set { pocetMist = value; }
        }

        public autobus(string Model, string Vyrobce, char Opravneni, int Spotreba, int PocetMist)
        {
            this.model = Model;
            this.vyrobce = Vyrobce;
            this.opravneni = Opravneni;
            this.spotreba = Spotreba;
            this.pocetMist = PocetMist;
        }

        public void ridicOpravneni(char Opravneni)
        { 
            if (Opravneni == 'D')
            {
                Console.WriteLine("Tento typ vozidla můžete řídit");
            }
            else
            {
                Console.WriteLine("Tento typ vozidla nemůžete řídit");
            }
        }

        public void Nalozit(int PocetMist)
        {
            if (Mist >= PocetMist)
            {
                Console.WriteLine("Nelze naložit více pasažérů");
            }
            else
            {
                Mist++;
                Console.WriteLine("Nyní je v autobuse: " + Mist + " pasažérů");
            }
        }

        public void Vylozit(int Mist)
        {
            if(Mist <= 0)
            {
                Console.WriteLine("Nelze vyložit více pasažérů");
            }
            else
            {
                Mist--;
                Console.WriteLine("Nyní je v autobuse: " + Mist + " pasažérů");
            }
        }

        public void VolneMisto(int PocetMist)
        {
            int Zbyva = PocetMist - Mist;
            Console.WriteLine(Zbyva);
        }

    }
}
