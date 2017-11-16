using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evidence
{
    class Cars
    {

        private string brand;
        private string model;
        private int build_year;
        private int km;

        public Cars(string Brand, string Model, int Build_Year, int Km)
        {
            this.brand = Brand;
            this.model = Model;
            this.build_year = Build_Year;
            this.km = Km;
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Build_Year
        {
            get { return build_year; }
            set { build_year = value; }
        }
        public int Km
        {
            get { return km; }
            set { km = value; }
        }

        public override string ToString()
        {
            return Brand + " " + Model + " " + Build_Year + " " + Km; 
        }
    }
}
