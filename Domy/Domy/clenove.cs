using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domy
{
    class clenove
    {
        public string Jmeno;
        public string Prijmeni;

        public clenove(string Jmeno, string Prijmeni)
        {
            this.Jmeno = Jmeno;
            this.Prijmeni = Prijmeni;
        }

        public override string ToString()
        {
            return Jmeno + " " + Prijmeni;
        }
    }
}
