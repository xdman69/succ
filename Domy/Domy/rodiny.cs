using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domy
{
    class rodiny
    {

        public string Prijmeni;

        public rodiny(string Prijmeni)
        {
            this.Prijmeni = Prijmeni;
        }
        public override string ToString()
        {
            return "Rodina " + Prijmeni;
        }
    }
}
