using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class paperbook : book
    {
        public int Weight;
        public int Stock;

        public paperbook() { }

        public paperbook(string Name, int Weight, int Stock, author autor)
        {
            this.Name = Name;
            this.Weight = Weight;
            this.Stock = Stock;
            this.autor = autor;
        }

        public override string ToString()
        {
            return "Kniha " + Name + " váží " + Weight + " Kilo, na skladě je " + Stock + " Kusů a jejím autorem je " + autor.FirstName + " " + autor.LastName;
        }
    }
}
