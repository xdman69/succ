using SQLite;
using SQLiteNetExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znamky
{
    public class Znamky
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Predmet { get; set; }
        public int Znamka { get; set; }


        public Znamky()
        {

        }

        public override string ToString()
        {
            return Znamka + " " + Predmet;
        }
    }
}
