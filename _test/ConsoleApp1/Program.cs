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
            long[,] arr2 = new long[9, 9];
            long[,] arrPlay = new long[9, 9];
            long[,] arr2Play = new long[9, 9];

            for (int i = 0; i < 9; i++)
            {
                arr[sz, sz] = 0;
                arr2[sz, sz] = 0;
                arrPlay[sz, sz] = 0;
                arr2Play[sz, sz] = 0;
                sz = sz + 1;
            }

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            string rotace = "";
            int player = 1;
            int play = 0;
            int pos = 1;

            void map(int current) {
                Console.Write("   1  2  3  4  5  6  7  8  9\n  --------------------------\n");
                for (int i = 0; i < rowLength; i++)
                {
                    Console.Write(pos + "| ");
                    for (int j = 0; j < colLength; j++)
                    {
                        if (current == 1)
                        {
                            Console.Write(string.Format("{0}  ", arr[i, j]));
                        }
                        else if(current == 2)
                        {
                            Console.Write(string.Format("{0}  ", arr2[i, j]));
                        }
                        else if (current == 3)
                        {
                            Console.Write(string.Format("{0}  ", arrPlay[i, j]));
                        }
                        else if (current == 4)
                        {
                            Console.Write(string.Format("{0}  ", arr2Play[i, j]));
                        }
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                    pos++;
                    if(pos > 9)
                    {
                        pos = 1;
                    }
                }
            }

            void rotation()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Horizontálně nebo Vertikálně? H/V");
                        rotace = Console.ReadLine();
                        if (rotace != "H" && rotace != "V" && rotace != "h" && rotace != "v")
                        {
                            continue;
                        } else
                        {
                            break;
                        }
                    }
                    catch(Exception)
                    {

                    }
                }

            }
            void text()
            {
                Console.WriteLine("\nZadej pozici\n");
                
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

                //arr[xint, yint] = 1;
            }
            void building()
            {
                while (start)
                {
                    Console.WriteLine("Hraje {0}. hráč\n", player);
                    map(player);
                    Console.WriteLine("Zadej pozici 2x1 lodě: \n");
                    rotation();
                    text();
                    if (rotace == "H" || rotace == "h")
                    {
                        arr[xint, yint] = 2;
                        arr[xint + 1, yint] = 2;
                    }
                    else if (rotace == "V" || rotace == "v")
                    {
                        arr[xint, yint] = 2;
                        arr[xint, yint + 1] = 2;
                    }

                    map(player);
                    Console.WriteLine("Zadej pozici 3x1 lodě: \n");
                    rotation();
                    text();
                    if (rotace == "H" || rotace == "h")
                    {
                        arr[xint, yint] = 2;
                        arr[xint + 1, yint] = 2;
                        arr[xint + 2, yint] = 2;
                    }
                    else if (rotace == "V" || rotace == "v")
                    {
                        arr[xint, yint] = 2;
                        arr[xint, yint + 1] = 2;
                        arr[xint, yint + 2] = 2;
                    }

                    map(player);
                    Console.WriteLine("Zadej pozici 4x1 lodě: \n");
                    rotation();
                    text();
                    if (rotace == "H" || rotace == "h")
                    {
                        arr[xint, yint] = 2;
                        arr[xint + 1, yint] = 2;
                        arr[xint + 2, yint] = 2;
                        arr[xint + 3, yint] = 2;
                    }
                    else if (rotace == "V" || rotace == "v")
                    {
                        arr[xint, yint] = 2;
                        arr[xint, yint + 1] = 2;
                        arr[xint, yint + 2] = 2;
                        arr[xint, yint + 3] = 2;
                    }
                    player = 2;
                    if (player == 2)
                    {
                        Console.WriteLine("Hraje {0}. hráč\n", player);
                        map(player);
                        Console.WriteLine("Zadej pozici 2x1 lodě: \n");
                        rotation();
                        text();
                        if (rotace == "H" || rotace == "h")
                        {
                            arr2[xint, yint] = 2;
                            arr2[xint + 1, yint] = 2;
                        }
                        else if (rotace == "V" || rotace == "v")
                        {
                            arr2[xint, yint] = 2;
                            arr2[xint, yint + 1] = 2;
                        }

                        map(player);
                        Console.WriteLine("Zadej pozici 3x1 lodě: \n");
                        rotation();
                        text();
                        if (rotace == "H" || rotace == "h")
                        {
                            arr2[xint, yint] = 2;
                            arr2[xint + 1, yint] = 2;
                            arr2[xint + 2, yint] = 2;
                        }
                        else if (rotace == "V" || rotace == "v")
                        {
                            arr2[xint, yint] = 2;
                            arr2[xint, yint + 1] = 2;
                            arr2[xint, yint + 2] = 2;
                        }

                        map(player);
                        Console.WriteLine("Zadej pozici 4x1 lodě: \n");
                        rotation();
                        text();
                        if (rotace == "H" || rotace == "h")
                        {
                            arr2[xint, yint] = 2;
                            arr2[xint + 1, yint] = 2;
                            arr2[xint + 2, yint] = 2;
                            arr2[xint + 3, yint] = 2;
                        }
                        else if (rotace == "V" || rotace == "v")
                        {
                            arr2[xint, yint] = 2;
                            arr2[xint, yint + 1] = 2;
                            arr2[xint, yint + 2] = 2;
                            arr2[xint, yint + 3] = 2;
                        }
                        break;
                    }
                    //start = false;
                }
            }
            player = 1;
            int ctr = 0;
            int ctr2 = 0;
            void battle()
            {
                while (true)
                {
                    for (int i = 0; i <= 81; i++)
                    {
                        Console.WriteLine("Hraje {0}. hráč\n", player);
                        map(play);
                        text();
                        if (i % 2 == 0)
                        {
                            if (arr2[xint, yint] == 0)
                            {
                                Console.WriteLine("Minul jsi");
                                arr2Play[xint, yint] = 3;
                            }
                            else if (arr2Play[xint, yint] == 1)
                            {
                                Console.WriteLine("Sem už jsi střelil");
                            }
                            else if (arr2[xint, yint] == 2)
                            {
                                Console.WriteLine("Zásah!");
                                arr2Play[xint, yint] = 1;
                                ctr++;
                                if(ctr >= 9)
                                {
                                    Console.Clear();
                                    break;
                                }

                            }
                            play = 3;
                            player--;
                        } else
                        {
                            if (arr[xint, yint] == 0)
                            {
                                Console.WriteLine("Minul jsi");
                                arrPlay[xint, yint] = 3;
                            }
                            else if (arrPlay[xint, yint] == 1) 
                            {
                                Console.WriteLine("Sem už jsi střelil");
                            }
                            else if (arr[xint, yint] == 2)
                            {
                                Console.WriteLine("Zásah!");
                                arrPlay[xint, yint] = 1;
                                ctr2++;
                                if(ctr2 >= 9)
                                {
                                    Console.Clear();
                                    break;
                                }
                            }
                            play = 4;
                            player++;
                        }
                        if (ctr >= 9)
                        {
                            break;
                        }
                        else if (ctr2 >= 9)
                        {
                            break;
                        }
                    }
                    if (ctr >= 9)
                    {
                        break;
                    }
                    else if (ctr2 >= 9)
                    {
                        break;
                    }
                }
            }
            building();
            battle();
            Console.WriteLine("Vyhrál hráč {0}", player);

            Console.ReadLine();
        }
    }
}
