using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tridy
{
    class kanál
    {
        private string xd;
        public string Nick;
        private string password;
        public bool Active;
        private int subscribers;

        public kanál()
        {

        }

        public kanál(string Nick, int Subs, string Email)
        {
            this.Nick = Nick;
            this.Subs = Subs;
            this.Email = Email;
        }

        public int Subs
        {
            get
            {
                return subscribers;
            }
            set
            {
                subscribers = value;
            }
        }
        private string email;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }


        public override string ToString()
        {
            if(Active == true)
            {
                xd = "je";
            } else
            {
                xd = "není";
            }
            return "Kanál " + Nick + " (" + Email + ") má " + Subs + " subs a " + xd + " aktivní";
        }

    }
}
