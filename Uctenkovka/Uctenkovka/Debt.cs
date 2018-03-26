using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uctenkovka
{
    public class Debt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }

        public Debt()
        {

        }

        public override string ToString()
        {
            return Name + " | " + Price.ToString() + " do " + Date;
        }
    }
}
