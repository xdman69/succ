using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace evidence
{
    class Csv : IFileHelper
    {
        public string saveTo(bool Type, string Data, string Dir)
        {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.Append(Data);
            csvcontent.AppendLine("");
            File.AppendAllText(Dir, csvcontent.ToString());
            return "Done";
        }
    }
}
