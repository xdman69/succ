﻿using System;
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

            for (int i = 0; i < 9; i++)
            {
                arr[sz, sz] = 0;
                arr2[sz, sz] = 0;
                sz = sz + 1;
            }

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            string rotace = "";
            int player = 1;

            void map(int current) {
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        if (current == 1)
                        {
                            Console.Write(string.Format("{0} ", arr[i, j]));
                        } else
                        {
                            Console.Write(string.Format("{0} ", arr2[i, j]));
                        }
   
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
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
            void battle()
            {
                while (true)
                {
                    for (int i = 0; i <= 81; i++)
                    {
                        Console.WriteLine("Hraje {0}. hráč\n", player);
                        map(player);
                        text();
                        if (i % 2 == 0)
                        {
                            arr2[xint, yint] = 1;
                            player--;
                        } else
                        {
                            arr[xint, yint] = 1;
                            player++;
                        }

                    }
                }
            }
            building();
            battle();

            Console.WriteLine();
        }
    }
}
