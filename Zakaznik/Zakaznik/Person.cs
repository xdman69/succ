using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakaznik
{
    class Person
    {
        public Bill AccountBalance = new Bill();
        public IPayingStrategy PayingStrategy;

        public int Id { get; set; }
        public string Name { get; set; }

        public void BuyItem(int price)
        {

            PayingStrategy.Pay(AccountBalance, price);  

        }

    }
}
