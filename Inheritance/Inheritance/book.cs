using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class book
    {
        public string Name;
        public int ISBN;
        public author autor;

        public book() { }

        public book(string Name, int ISBN, author autor)
        {
            this.Name = Name;
            this.ISBN = ISBN;
            this.autor = autor;
        }

        public override string ToString()
        {
            return "Kniha " + Name + " má ISBN kód: " + ISBN + " a jejím autorem je " + autor.FirstName + " "  + autor.LastName;
        }

    }
}
