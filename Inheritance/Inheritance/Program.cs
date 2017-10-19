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
            author autorKnihy2 = new author("Pepa", "Lmao");
            
            ebook ekniha = new ebook("Vaření piva 101", "1337", 125, autorKnihy2);
            ebook ekniha2 = new ebook("Vaření piva 202", "1277", 127, autorKnihy2);
            ebook ekniha3 = new ebook("Vaření piva 404", "1877", 120, autorKnihy2);

            paperbook papKniha = new paperbook("Pivní turistika", 3, 420, autorKnihy2);
            paperbook papKniha2 = new paperbook("Pivní cyklistika", 3, 120, autorKnihy);
            paperbook papKniha3 = new paperbook("S pivem po českých řekách", 2, 115, autorKnihy);



            List<author> seznamAutoru = new List<author>()
            {
                autorKnihy, autorKnihy2
            };

            /*List<book> seznamKnih = new List<book>()
            {
                kniha, kniha2
            };*/

            List<ebook> seznamEKnih = new List<ebook>()
            {
                ekniha, ekniha2, ekniha3
            };

            List<paperbook> seznamPAPKnih = new List<paperbook>()
            {
                papKniha, papKniha2, papKniha3
            };
            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Zobrazit eKnihy\n2. Zobrazit Knihy\n3. Zapsat Knihu\n4. Ukončit\n");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("\neKnihy:\n");
                        foreach (var p in seznamEKnih)
                        {
                            Console.WriteLine(p.ToString());
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("\nKnihy:\n");
                        foreach (var p in seznamPAPKnih)
                        {
                            Console.WriteLine(p.ToString());
                        }
                    }
                    else if (choice == "3")
                    {
                        while(true)
                        {
                            try
                            {
                                Console.WriteLine("\neKnihu nebo Knihu? (E/K)");
                                string typ = Console.ReadLine();
                                if(typ == "e" || typ == "E")
                                {
                                    Console.Write("Jak se kniha jmenuje? : ");
                                    string nazev = Console.ReadLine();
                                    Console.Write("\nJakou má velikost? (MB) : ");
                                    string size = Console.ReadLine();
                                    Console.Write("\nJaké má URI? : ");
                                    string uri = Console.ReadLine();
                                    Console.Write("\nKdo je autor?\nJméno : ");
                                    string jmeno = Console.ReadLine();
                                    Console.Write("Příjmení : ");
                                    string prijmeni = Console.ReadLine();

                                    int isize = int.Parse(size);

                                    author autor = new author(jmeno, prijmeni);
                                    ebook newebook = new ebook(nazev, uri, isize, autor);
                                    seznamEKnih.Add(newebook);

                                    break;

                                }
                                else if(typ == "k" || typ == "K")
                                {
                                    Console.Write("Jak se kniha jmenuje? : ");
                                    string nazev = Console.ReadLine();
                                    Console.Write("\nKolik kniha váží? (Kg) : ");
                                    string weight = Console.ReadLine();
                                    Console.Write("\nKolik jich je na skladě? : ");
                                    string stock = Console.ReadLine();
                                    Console.Write("\nKdo je autor?\nJméno : ");
                                    string jmeno = Console.ReadLine();
                                    Console.Write("Příjmení : ");
                                    string prijmeni = Console.ReadLine();

                                    int iweight = int.Parse(weight);
                                    int istock = int.Parse(stock);

                                    author autor = new author(jmeno, prijmeni);
                                    paperbook newebook = new paperbook(nazev, iweight, istock, autor);
                                    seznamPAPKnih.Add(newebook);

                                    break;
                                }
                            } catch(Exception)
                            {

                            }
                        }

                    } 
                    else if (choice == "4")
                    {
                        break;
                    }
                } catch(Exception)
                {

                }
            }

        }
    }
}
