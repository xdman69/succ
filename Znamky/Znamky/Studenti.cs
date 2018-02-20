using SQLite;
using SQLiteNetExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znamky
{
    public class Studenti
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Trida { get; set; }


        public Studenti()
        {

        }

        public override string ToString()
        {
            return Jmeno + " " + Trida;
        }
    }
}
