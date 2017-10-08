using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tridy
{
    class osoba
    {
        private string rc;
        private string jmeno;
        private string prijmeni;
        private bool alive = true;

        public string Jmeno
        {
            get
            {
                return jmeno;
            }
            set
            {
                jmeno = value;
            }
        }

        public string Prijmeni
        {
            get
            {
                return prijmeni;
            }
            set
            {
                prijmeni = value;
            }
        }

        public string GetRc()
        {
            return "XD";
        }

        public int GetVek()
        {
            return 10;
        }

        public bool IsAlive()
        {
            return alive;
        }

    }
}
