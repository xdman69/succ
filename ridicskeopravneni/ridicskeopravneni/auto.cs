using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridicskeopravneni
{
    class auto
    {
        protected string model;
        protected string vyrobce;
        protected char opravneni;
        protected int spotreba;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Vyrobce
        {
            get { return vyrobce; }
            set { vyrobce = value; }
        }
        public char Opravneni
        {
            get { return opravneni; }
            set { opravneni = value; }
        }
        public int Spotreba
        {
            get { return spotreba; }
            set { spotreba = value; }
        }

        public auto() { }

        public auto(string Model, string Vyrobce, char Opravneni, int Spotreba)
        {
            this.model = Model;
            this.vyrobce = Vyrobce;
            this.opravneni = Opravneni;
            this.spotreba = Spotreba;
        }
        public void ridicOpravneni(char Opravneni)
        {
            if (Opravneni == 'B')
            {
                Console.WriteLine("Tento typ vozidla můžete řídit");
            }
            else
            {
                Console.WriteLine("Tento typ vozidla nemůžete řídit");
            }
        }

        public void Presun()
        {

        }
    }
}
