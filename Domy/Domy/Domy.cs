using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domy
{
    class Domy
    {
        public string PSC;
        public string Ulice;
        public int cislo;
        public List<rodiny> seznamRodin = new List<rodiny>();


        public Domy(string PSC, string Ulice)
        {
            this.PSC = PSC;
            this.Ulice = Ulice;
        }
        public void PridatOsobu(rodiny rodina)
        {
            seznamRodin.Add(rodina);
        }
        public override string ToString()
        {
            return cislo + ". Dům na adrese: " + PSC + " v ulici " + Ulice;
        }
        public string Toxd()
        {
            string textKVraceni = String.Empty;

            foreach(rodiny rodina in seznamRodin)
            {
                textKVraceni += rodina.cislo + ". ";
                textKVraceni += rodina.Prijmeni;
                textKVraceni += Environment.NewLine;
            }

            return textKVraceni;
        }
    }
}
