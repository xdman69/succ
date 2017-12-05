using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridicskeopravneni
{
    class Program
    {
        static void Main(string[] args)
        {


            autobus autobus1 = new autobus("TE-36", "Karosa", 'C', 26, 66);



            List<autobus> seznamAutobusu = new List<autobus>()
            {
                autobus1
            };

            autobus1.ridicOpravneni('C');
            autobus1.Nalozit(66);

            Console.ReadLine();
        }
    }
}
