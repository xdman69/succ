using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakaznik
{
    class GoldMemberPayingStrategy : IPayingStrategy
    {
        public void Pay(Bill bill, int price)
        {
            price = price / 2;
            bill.AccountBalance = bill.AccountBalance - price;
            Console.WriteLine($"Your Account Balance is {bill.AccountBalance}");
        }
    }
}
