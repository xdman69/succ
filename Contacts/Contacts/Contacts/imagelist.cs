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
        private string number;
        private string email;
        private Xamarin.Forms.ImageSource background;

        public Xamarin.Forms.ImageSource Image
        {
            get { return image; }
            set { image = value; }
        }

        public Xamarin.Forms.ImageSource Background
        {
            get { return background; }
            set { background = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        public imagelist(Xamarin.Forms.ImageSource Image , string Text, string Number, string Email,Xamarin.Forms.ImageSource Background, int Index)
        {
            this.image = Image;
            this.text = Text;
            this.number = Number;
            this.index = Index;
            this.email = Email;
            this.background = Background;
        }
    }
}
