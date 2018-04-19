using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingForm
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string TextWarning { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this. DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Osoba customer = new Osoba(Firstname, Surname, Age);
            
            CustomerContract validator = new CustomerContract();
            FluentValidation.Results.ValidationResult results = validator.Validate(customer);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            if(validationSucceeded)
            {
                this.DataContext = new Text(customer);
            } else
            {
                foreach(var failure in failures)
                {
                    Console.WriteLine(failure);
                }
            }
        }
    }
}
