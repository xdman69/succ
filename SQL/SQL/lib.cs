using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class lib
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Power { get; set; }
        public string Name { get; set; }
        public string Cond { get; set; }
        public string Manu { get; set; }

        public static void add(SQLiteConnection db, string name, int power, string cond, string manu)
        {
            var dd = db.Insert(new lib()
            {
                Name = name,
                Power = power,
                Cond = cond,
                Manu = manu
            });
        }

        public override string ToString()
        {
            return Manu + " " + Name + " | " + Power + " kW | " + Cond;
        }
    }
}
