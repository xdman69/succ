using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidator;

namespace BindingForm
{
    class Osoba : Notifiable
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public int Age { get; private set; }

        public Osoba(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        /*
            if (FirstName.Length < 3)
                AddNotification("FirstName", "FirstName is invalid");

            if (LastName.Length < 3)
                AddNotification("LastName", "LastName is invalid");*/
        }

        /*private string firstname;
        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        private string age;
        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public override string ToString()
        {
            return Firstname + " " + Surname + " | " + Age;
        }

        */

        public string firstnameSurname
        {
            get
            {
                return FirstName + " " + LastName + " | " + Age;
            }

            set
            {

            }
        }
    }
}
