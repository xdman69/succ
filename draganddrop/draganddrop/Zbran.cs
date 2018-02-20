using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace draganddrop
{
    class Zbran : AItem
    {

        public string TypZbrane { get; set; }
        public int Damage { get; set; }

        public Zbran(int damage)
        {
            Damage = damage;
        }

        public override int Value()
        {
            return Damage;
        }

    }
}
