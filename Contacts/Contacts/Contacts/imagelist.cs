using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class imagelist
    {
        private string imgSource;
        private string text;

        public string Image
        {
            get { return imgSource; }
            set { imgSource = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }


        public imagelist(string ImgSource, string Text)
        {
            this.imgSource = ImgSource;
            this.text = Text;
        }
    }
}
