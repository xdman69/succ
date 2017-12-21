using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DraciDoupe
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                Canvas.SetTop(pictureBox1, Canvas.GetTop(pictureBox1) - 10);
            }
            else if (e.Key == Key.Left)
            {
                pictureBox1.Source = new BitmapImage(new Uri(@"D:\valesja15\art\chars\1Left.png"));
                Canvas.SetLeft(pictureBox1, Canvas.GetLeft(pictureBox1) - 5);

            }
            else if (e.Key == Key.Right)
            {
                pictureBox1.Source = new BitmapImage(new Uri(@"D:\valesja15\art\chars\1Right.png"));
                Canvas.SetLeft(pictureBox1, Canvas.GetLeft(pictureBox1) + 5);
            }
        }

        private void RectangleMouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void MyCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox1.Source = new BitmapImage(new Uri(@"D:\valesja15\art\chars\0Right.png"));
        }
    }
}
