using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp3011
{
    interface IFileHelper
    {
        string CollectionToString(List<int> input);

        List<int> StringToCollection(string input);
    }
}
