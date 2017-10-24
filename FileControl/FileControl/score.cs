using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileControl
{
    class score
    {
        private string Name;
        private string Score;

        public score(string Name, string Score)
        {
            this.Name = Name;
            this.Score = Score;
        }

        public override string ToString()
        {
            return Name + " | " +Score;
        }
    }
}
