using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakaznik
{
    interface IPayingStrategy
    {
        void Pay(Bill bill, int price);
    }
}
