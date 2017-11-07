using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_auto
{
    class car
    {
        private string nazev;
        private string barva;
        private int kilometry;
        private int vyroba;
        public bool pohyb;
        public string Nazev
        {
            get
            {
                return nazev;
            }
            set
            {
                 nazev = value;

            }
        }
        public string Barva
        {
            get
            {
                return barva;
            }
            set
            {
                barva = value;

            }
        }
        public int Kilometry
        {
            get
            {
                return kilometry;
            }
            set
            {
                kilometry = value;

            }
        }
        public int Vyroba
        {
            get
            {
                return vyroba;
            }
            set
            {
                vyroba = value;

            }
        }
        public bool Pohyb
        {
            get
            {
                return pohyb;
            }
            set
            {
                pohyb = value;

            }
        }

        public car(string Nazev, string Barva, int Kilometry, int Vyroba, bool Pohyb)
        {
            this.Nazev = Nazev;
            this.Barva = Barva;
            this.Kilometry = Kilometry;
            this.Vyroba = Vyroba;
            this.Pohyb = Pohyb;
        }
        public override string ToString()
        {
                return Nazev + " | " + Barva + " | " + Kilometry + " | " + Vyroba + " | V pohybu : " + Pohyb;        
        }
    }
}
