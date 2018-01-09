using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakaznik
{
    class Program
    {
        static void Main(string[] args)
        {


            Bill bill = new Bill();
            bill.AccountBalance = 1000;
            Bill bill1 = new Bill();
            bill1.AccountBalance = 1000;


            Person person = new Person();
            person.PayingStrategy = new GoldMemberPayingStrategy();
            person.AccountBalance = bill;
            person.BuyItem(1000);


            Person person1 = new Person();
            person1.PayingStrategy = new NotMemberPayingStrategy();
            person1.AccountBalance = bill1;
            person1.BuyItem(1000);

            Console.ReadKey();
            

        }
    }
}
