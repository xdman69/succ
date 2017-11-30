using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp3011
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int>();
    
            JsonHelper jsonHelper = new JsonHelper();



            XmlHelper xmlHelper = new XmlHelper();


            IFileHelper fileHelper = new JsonHelper();
            fileHelper = new  XmlHelper();

            string extension = ".json";
            string input = ".json";

            if(extension.Equals(input))
            {
                fileHelper = new JsonHelper();
            }
            else
            {
                fileHelper = new CsvHelper();
            }

            fileHelper.CollectionToString(data);
            fileHelper.StringToCollection("asdada");
        }
    }
}
