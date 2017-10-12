using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            author autorKnihy = new author("Karel", "Novák");
            author autorKnihy2 = new author("Pepa", "Kokot");

            book kniha = new book("Velká encyklopedie piva", 154564564, autorKnihy);

            ebook ekniha = new ebook("Vaření piva 101", "1337", 125, autorKnihy2);

            paperbook papKniha = new paperbook("Pivní turistika", 15, 420, autorKnihy2);



            List<author> seznamAutoru = new List<author>()
            {
                autorKnihy, autorKnihy2
            };

            List<book> seznamKnih = new List<book>()
            {
                kniha
            };

            List<ebook> seznamEKnih = new List<ebook>()
            {
                ekniha
            };

            List<paperbook> seznamPAPKnih = new List<paperbook>()
            {
                papKniha
            };

            foreach(var p in seznamEKnih)
            {
                Console.WriteLine(p.ToString());
            }



        }
    }
}
