using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_auto
{
    class Program
    {
        static void Main(string[] args)
        {
            car auto = new car("Volkswagen Passat", "Bíla", 200000, 2012, true);
            car auto2 = new car("Škoda Fabia", "Žlutá", 10000000, 2007, false);
            car auto3 = new car("Fiat Punto", "Červená", 50000, 2015, true);
            car auto4 = new car("Audi A6", "Černá", 215000, 2010, false);
            car auto5 = new car("Mercedes C Class", "Černá", 2000, 2017, true);
            List<car> seznamAut = new List<car>()
            {
                auto, auto2, auto3, auto4, auto5
            };
            var slct = seznamAut[0];
            int top = 0;
            foreach (var cs in seznamAut) {
                if(cs.Kilometry >= slct.Kilometry)
                {
                    top = cs.Kilometry;
                    Console.WriteLine("TOP | " + cs.ToString());
                } else
                {
                    Console.WriteLine(cs.ToString());
                }
            }
        }
    }
}
