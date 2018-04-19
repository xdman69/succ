using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingForm
{
    class Text : INotifyPropertyChanged
    {

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        private ObservableCollection<Osoba> textik = new ObservableCollection<Osoba>();

        public ObservableCollection<Osoba> Textik
        {
            get
            {
                return textik;
            }

            set
            {
                textik = value;
            }
        }

        public Text(Osoba person)
        {
            textik.Add(person);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _text = "Okay";
        public string TextWarning
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("TextWarning");
            }
        }

        private bool _numberChecker = true;
        public bool NumberChecker
        {
            get => _numberChecker;
            set
            {
                _numberChecker = value;
                OnPropertyChanged("NumberChecker");
            }
        }

        public string Name { get; set; }

        private string _number = "";
        public string Number
        {
            get => _number;
            set
            {
                _number = value;

                int check = 0;
                if (int.TryParse(Number, out int trueNumber))
                    check++;
                else
                    TextWarning = "Only Numbers";

                if (Number.Length > 0)
                    check++;
                else
                    TextWarning = "OnlyNumbers!";

                if (check == 2)
                {
                    NumberChecker = true;
                }
                else
                    NumberChecker = false;

                OnPropertyChanged("TextWarning");
            }
        }

    }
}
