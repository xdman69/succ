using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence
{
    class xml : IFileHelper
    {
        public string saveTo(bool Type, string Data, string Dir)
        {
            if (Type == true)
            {
                System.IO.File.AppendAllText(Dir + @"\text.xml", Data.ToString() + "\n");
                return "Done";
            } else
            {
                return "Not Done";
            }
        }
    }
}
