using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridicskeopravneni
{
    class nakladniAuto : auto
    {
        private int nosnost;
        private static int naklad = 0;

        public int Nosnost
        {
            get { return nosnost; }
            set { nosnost = value; }

        }
        public static int Naklad
        {
            get { return naklad; }
            set { naklad = value; }

        }

        public nakladniAuto(string Model, string Vyrobce, char Opravneni, int Spotreba, int Nosnost)
        {
            this.model = Model;
            this.vyrobce = Vyrobce;
            this.opravneni = Opravneni;
            this.spotreba = Spotreba;
            this.nosnost = Nosnost;
        }

        public void ridicOpravneni(char Opravneni)
        {
            if(Opravneni == 'C')
            {
                Console.WriteLine("Tento typ vozidla můžete řídit");
            } else
            {
                Console.WriteLine("Tento typ vozidla nemůžete řídit");
            }
        }
        public void Nalozit(int Nosnost)
        {
            if(Naklad >= Nosnost)
            {
                Console.WriteLine("Nelze naložit více");
            } else
            {
                Naklad++;
                Console.WriteLine("Naklad je nyni: " + Naklad + " Kg");
            }
        }

        public void Vylozit(int Naklad)
        {
            if (Naklad <= 0)
            {
                Console.WriteLine("Nelze vyložit více");
            }
            else
            {
                Naklad--;
                Console.WriteLine("Naklad je nyni: " + Naklad + " Kg");
            }
        }

        public void VolneMisto(int Nosnost)
        {
            int Zbyva = Nosnost - Naklad;
            Console.WriteLine(Zbyva);
        }

    }
}
