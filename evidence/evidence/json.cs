using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence
{
    class Json : IFileHelper
    {
        public string saveTo(bool Type, string Data, string Dir)
        {
            if (Type == false)
            {
                System.IO.File.AppendAllText(Dir + @"\text.json", Data.ToString() + "\n");
                return "Done";
            } else
            {
                return "Not Done";
            }
        }
    }
}
