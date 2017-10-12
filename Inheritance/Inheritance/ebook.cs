using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class ebook : book
    {
        public string URI;
        public int SizeMB;

        public ebook() { }

        public ebook(string Name, string URI, int SizeMB, author autor)
        {
            this.Name = Name;
            this.URI = URI;
            this.SizeMB = SizeMB;
            this.autor = autor;
        }

        public override string ToString()
        {
            return "Kniha " + Name + " je velká " + SizeMB + " MB, její URI je " + URI + " a jejím autorem je " + autor.FirstName + " " + autor.LastName;
        }
    }
}
