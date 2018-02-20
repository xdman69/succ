using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uctenkovka
{
    public class Expense
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }

        public Expense()
        {

        }

        public override string ToString()
        {
            return Date + " | " + Price;
        }



    }
}
