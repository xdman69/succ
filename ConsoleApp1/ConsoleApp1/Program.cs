using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sz = 0;
            int xint = 0;
            int yint = 0;
            bool start = true;

            long[,] arr = new long[9, 9];

            for(int i = 0; i < 9; i++)
            {
                arr[sz, sz] = 0;
                sz = sz + 1;
            }

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            void map() {
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0} ", arr[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
            }

            void text()
            {
                Console.WriteLine("\nZadej pozici, kterou chceš napadnout\n");
                
                while (true)
                {
                    try
                    {
                        Console.Write("X = ");
                        string x = Console.ReadLine();
                        xint = int.Parse(x);
                        xint = xint - 1;
                        if (xint > 8 || xint < 0)
                        {
                            Console.WriteLine("Pouze v rozmezí 1 - 9");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Pouze čísla");
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.Write("Y = ");
                        string y = Console.ReadLine();
                        yint = int.Parse(y);
                        yint = yint - 1;
                        if (yint > 8 || yint < 0)
                        {
                            Console.WriteLine("Pouze v rozmezí 1 - 9");
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Pouze čísla\n");
                    }
                }

                arr[xint, yint] = 1;
            }

            while(start)
            {
                map();
                Console.WriteLine("Zadej pozici 2x1 lodě: \n");
                start = false;
            }

            while (start)
            {
                for (int i = 0; i <= 81; i++)
                {
                    map();
                    text();
                }
            }

            Console.WriteLine();
        }
    }
}
