using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class imagelist
    {
        private int index;
        private Xamarin.Forms.ImageSource image;
        private string text;

        public Xamarin.Forms.ImageSource Image
        {
            get { return image; }
            set { image = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        public imagelist(Xamarin.Forms.ImageSource Image , string Text, int Index)
        {
            this.image = Image;
            this.text = Text;
            this.index = Index;
        }
    }
}
