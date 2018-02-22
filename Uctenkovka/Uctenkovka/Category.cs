using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uctenkovka
{
    public class Category
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        public Category()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
