using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _test
{
    class Program
    {
        static void Main(string[] args)
        {

            //string num = "0123456789";
            int pocet = 0;
            int s = 0;
            int pomocna = 0;

            Console.WriteLine("Zadejte vstup:");
            string xd = Console.ReadLine();
            Char[] stringArr = new Char[xd.Length];

            foreach (char spr in xd)
            {
                /*if (num.Contains(spr))
                {
                    pocet = pocet + 1;
                }*/
                stringArr[s] = spr;
                s++;
            }

            foreach (char prvek in stringArr)
            {
                //Console.Write(prvek);
                if(char.IsNumber(prvek)) // Pocitani cislic
                {
                    pomocna = pomocna + 1;

                }

                if (char.IsLetter(prvek))
                {
                    if(pomocna >= 1)
                    {
                        pomocna = 1;
                        pocet = pocet + pomocna;

                    }
                }
            }

            Console.WriteLine(pocet);

            Console.WriteLine();
        }
    }
}
