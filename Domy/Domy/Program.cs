using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domy
{
    class Program
    {
        static void Main(string[] args)
        {
            Domy dum = new Domy("18100", "Hackerova");
            Domy dum2 = new Domy("18100", "Bohnická");
            rodiny rodina = new rodiny("Adamcovi");
            dum.PridatOsobu(rodina);
            rodiny rodina2 = new rodiny("Markovi");
            dum.PridatOsobu(rodina2);
            clenove clen = new clenove("Marek", "Adamec");
            List<Domy> seznamDomu = new List<Domy>()
            {
                dum, dum2
            };
            /*List<rodiny> seznamRodin = new List<rodiny>()
            {
                rodina
            };*/
            List<clenove> seznamClenu = new List<clenove>()
            {
                clen
            };

            int j = 1;
            foreach(var p in seznamDomu)
            {
                p.cislo = j;
                j = j + 1;
            }

            //Console.WriteLine(seznamRodin[0].ToString());
            string choice1;

            while (true)
            {
                Console.WriteLine("1. Prohledat Domy\n2. Zavřít");
                choice1 = Console.ReadLine();

                try
                {
                    if (choice1 == "1")
                    {
                        Console.Clear();
                        break;
                    }
                    else if(choice1 == "2")
                    {
                        Environment.Exit(0);
                    } else
                    {
                        continue;
                    }
                }
                catch(Exception)
                {

                }
            }

            if(choice1 == "1")
            {
                foreach (var l in seznamDomu) {
                    Console.WriteLine (l.ToString());
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Jaký dům chceš prohledat: ");
                        string choice2 = Console.ReadLine();
                        int x = int.Parse(choice2);
                        if (x > 0 && x <= seznamDomu.Count)
                        {
                            Console.Clear();
                            x--;
                            Console.WriteLine(seznamDomu[x].Toxd());
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
    }
}
