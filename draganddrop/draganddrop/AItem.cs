using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace draganddrop
{
    public abstract class AItem
    {
        abstract public int Value();

        public int Vaha;
        public string Typ;
        public string NazevItemu { get; set; }

    }
}
