using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tridy
{
    class Program
    {
        static void Main(string[] args)
        {
            kanál kanal = new kanál();
            kanal.Nick = "TlustejKarel";
            kanal.Email = "karel@pillow.com";
            kanal.Subs = 69000;
            kanal.Active = true;

            kanál kanal2 = new kanál();
            kanal2.Nick = "PjeDiPi";
            kanal2.Email = "pjed@pi.com";
            kanal2.Subs = 420000;

            kanál kanal3 = new kanál("xdman", 420420, "xdman@blazeit.com");
            kanal3.Active = true;

            List<kanál> seznamKanalu = new List<kanál>()
            {
                kanal, kanal2, kanal3
            };


            Console.WriteLine(seznamKanalu[0].ToString());
            Console.WriteLine(seznamKanalu[1].ToString());
            Console.WriteLine(seznamKanalu[2].ToString());

        }
    }
}
