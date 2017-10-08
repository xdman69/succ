using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{

    enum Rotace
    {
        horizont,vertikal
    }
    class Program
    {
        // proměnné pro hru
        static int pole = 10;
        static int aktualHrac = 0;
        static string errorText = "";
        static int gameMode = 0;

        // arrays
        static string[] pismena = new string[10] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        static string[][] lode1 = create(pole);
        static string[][] bat1 = create(pole);
        static string[][] lode2 = create(pole);
        static string[][] bat2 = create(pole);
        static string[][][][] mapaPole = arrayConnector();
        static int[,] lodicky = new int[4,2] { {1,4}, {2,2}, {3,2}, {4,1} };

        // proměnné na lod
        static int lodCounter = 0;
        static int max = 3;

        static void Main(string[] args)
        {

            bool loop = true;
            int[] typRange = new int[2] {1,5};
            int[] rotRange = new int[2] {1,2};
            Rotace[] rot = new Rotace[2] {Rotace.vertikal, Rotace.horizont };

            // vytvoření pole s loděmi
            while (gameMode == 0)
            {

                mapa(gameMode);
                stavbaLode(typRange,rotRange,rot);

                if (lodCounter == max)
                {
                    mapa(gameMode);
                    if(aktualHrac == 0)
                    {
                        switchPlayers(aktualHrac);
                        Console.WriteLine("Na tahu je {0}. hráč ",aktualHrac+1);
                        Console.WriteLine("Stiskni libovolné tlačítko pro pokračování");
                        Console.ReadLine();
                    }
                    else if (aktualHrac == 1)
                    {
                        gameMode++;
                    }
                    lodCounter = 0;
                }

            }

            switchPlayers(aktualHrac);
            mapa(gameMode-1);
            Console.Write("Stiskni libovolné tlačítko pro pokračování na další etapu hry");
            Console.ReadLine();

            // Ničení lodiček :)
            while (loop)
            {
                mapa(1);
                int[] lok = poz(pole);

                if (lode1[lok[1]][lok[0]] == "X")
                {
                    Console.WriteLine("Zásah");
                    bat1[lok[1]][lok[0]] = "-";
                }
                else
                {
                    bat1[lok[1]][lok[0]] = "O";
                }
                if (ctr(bat1) == ctr(lode1))
                {
                    loop = false;
                }
            }
            mapa(gameMode);
            Console.WriteLine("VYHRÁL JSI");
        }

        static void show(string[][][] array, int type)
        {
            string text1 = "";
            string text2 = "";
            string pozice = "";

            int[] choose = new int[2] { aktualHrac, gameMode };

            string[,] pole = new string[2,3];

            string multiMezera = "       ";

            for (int i = 0; i < array[0].Length; i++)
            {
                pozice += pismena[i] + "  ";
            }
            pole[0,0] = "XY " + pozice;
            pole[1,0] = "XY " + pozice + multiMezera + "XY " + pozice;
            Console.WriteLine(pole[type,0]);
            for (int i = 0; i < array[0].Length; i++)
            {
                for (int j = 0; j < array[0][i].Length; j++)
                {
                    text1 += " " + array[0][i][j] + " ";
                    text2 += " " + array[1][i][j] + " ";
                }
                pole[0,0] = i + "|" + text1;
                pole[0,1] = i + "|" + text2;
                pole[1,1] = i + "|" + text1 + multiMezera + " " + i + "|" + text2;
                Console.WriteLine(pole[type,choose[gameMode]]);
                text1 = "";
                text2 = "";
            }

        }

        static string[][] create(int ctr)
        {
            string[][] array = new string[ctr][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string[ctr];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = "*";
                }
            }
            return array;
        }

        static int[] poz(int vel)
        {
            int[] array = new int[2];
            bool loop = true;
 
            while (loop)
            {
                try
                {
                    mapa(gameMode);
                    Console.Write("Zadejte začáteční pozici lodě : ");
                    string pozice = Console.ReadLine();
                    if (checkPozice(pozice))
                    {
                        string znak = char.ToString(pozice[0]);
                        for (int i = 0; i < pismena.Length; i++)
                        {
                            znak = char.ToString(pozice[0]);
                            if (znak.ToUpper() == pismena[i])
                            {
                                array[0] = i;
                            }
                        }
                        array[1] = int.Parse(char.ToString(pozice[1]));
                        if (array[0] >= 0 && array[0] < vel && array[1] >= 0 && array[1] < vel)
                        {
                            errorText = "";
                            loop = false;
                        }
                        else
                        {
                            errorText = "Zadejte pouze písmena : A-"+ pismena[pismena.Length-1] + " a číslice : 0-" + (lode1.Length - 1);
                        }
                    }

                }
                catch
                {
                    errorText = "Zadejte pouze písmena : A-" + pismena[pismena.Length-1] + " a číslice : 0-" + (lode1.Length - 1);
                }
            }
            return array;
        }

        static bool checkPozice(string pozice)
        {
            bool check = false;
            string znak = "";
            for(int i = 0; i < pismena.Length; i++)
            {
                znak = char.ToString(pozice[0]);
                if (znak.ToUpper() == pismena[i])
                {
                    check = true;
                }
            }
            if (pozice.Length <= 2)
            {
                if (!char.IsDigit(pozice[0]) && check && char.IsDigit(pozice[1]))
                {
                    return true;
                }
            }
            return false;
        }

        static int checkVstup(string text,int[] range)
        {
            while(true)
            {
                try
                {
                    mapa(gameMode);
                    Console.Write(text);
                    int vstup = int.Parse(Console.ReadLine());

                    if(vstup >= range[0] && vstup <= range[1])
                    {
                        errorText = "";
                        return vstup;
                    }
                    errorText = "Zadávejte pouze povolená čísla";
                }
                catch
                {
                    errorText = "Zadávejte pouze povolená čísla";
                }            
            }
        }

        static int ctr(string[][] array)
        {
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if(array[i][j] != "*" && array[i][j] != "O")
                    {
                        counter += 1;
                    }
                }
            }
            return counter;
        }

        static void switchPlayers(int player)
        {
            if(player == 0)
            {
                aktualHrac = 1;
            }
            else if (player == 1)
            {
                aktualHrac = 0;
            }
        }

        static void mapa(int type)
        {

            Console.Clear();
            Console.WriteLine("Nacházíte se v {0}. části hry", gameMode+1);
            Console.WriteLine("Hraje {0}. hráč", aktualHrac + 1);

            show(mapaPole[type], type);
            Console.WriteLine("Můžeš ještě postavit {0} lod(ě)",max-lodCounter);
            errorShow();
        }

        static void errorShow()
        {
            if (errorText != "")
            {
                Console.WriteLine(">> "+errorText+" <<");
            }
        }

        static void stavbaLode(int[] typRange,int[] rotRange,Rotace[] rot)
        {
            int delkaLode = checkVstup("Vyberte typ lodě > ",typRange);
            int smer = checkVstup("vyberte směr lodě 1. ver 2. hor > ",rotRange);
            Rotace rotace = rot[smer-1];
            int[] pozice = poz(pole);
            /*
             if(lode.Checked())
             {
                Lode lode = new Lode();
                int[] lokace = Lode.Limit(delkaLode, rotace, pozice, x, y);
                lode.Pole.add(Lode.CreatePole(lokace));
             }
             */
            int errorCTR = 0;
            int jY = 0;
            int jX = 0;
            Console.WriteLine(rotace);
            if (delkaLode + pozice[1] <= lode1.Length)
            {
                for (int x = -1; x <= delkaLode; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        int[] lok = lodLimit(rotace, pozice, x, y);
                        mapaPole[0][aktualHrac][lok[0]][lok[1]] = "O";
                        if (mapaPole[ 0 ][ aktualHrac ][ lok[0] ][ lok[1] ] == "X")
                        {
                            errorCTR += 1;
                        }
                    }
                }
                if (errorCTR == 0)
                {
                    for (int i = 0; i < delkaLode; i++)
                    {
                        if (rotace == Rotace.horizont)
                        {
                            jX = pozice[1] + i;
                            jY = pozice[0];
                        }
                        else if (rotace == Rotace.vertikal)
                        {
                            jX = pozice[1];
                            jY = pozice[0] + i;
                        }
                        mapaPole[0][aktualHrac][jX][jY] = "X";
                    }

                    lodCounter++;
                }
                Console.ReadLine();
            }
        }

        static int[] lodLimit(Rotace rotace,int[] pozice,int x, int y)
        {
            int[] lokace = new int[2]; 

            if (rotace == Rotace.vertikal)
            {
                if (pozice[1] + y >= 0 && pozice[0] + x >= 0)
                {
                    lokace[0] = pozice[0] + x;
                    lokace[1] = pozice[1] + y;
                }
            }
            else if (rotace == Rotace.horizont)
            {
                if (pozice[1] + y >= 0 && pozice[0] + x >= 0)
                {
                    lokace[1] = pozice[0] + x;
                    lokace[0] = pozice[1] + y;
                }
            }
            return lokace;
        }

        static string[][][][] arrayConnector()
        {
            string[][][][] mapa = new string[2][][][];
            for (int i = 0; i < mapa.Length; i++)
            {
                mapa[i] = new string[2][][];
            }
            mapa[0][0] = lode1;
            mapa[0][1] = lode2;
            mapa[1][0] = bat1;
            mapa[1][1] = bat2;
            return mapa;
        }

    }
}
