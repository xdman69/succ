﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace draganddrop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(Mouse.MouseUpEvent, new MouseButtonEventHandler(OnMouseUp), true);

        }

        private bool _isBeingDragged;

        public void OnMouseDown(object sender, MouseEventArgs args)
        {
            if (!(args.OriginalSource is Canvas))
            {
                _isBeingDragged = true;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (_isBeingDragged)
            {
                var elementBeingDragged = (FrameworkElement)args.OriginalSource;
                var position = args.GetPosition(MyCanvas);
                Canvas.SetLeft(elementBeingDragged, position.X - elementBeingDragged.ActualWidth / 2);
                Canvas.SetTop(elementBeingDragged, position.Y - elementBeingDragged.ActualHeight / 2);
            }
        }

        public void OnMouseUp(object sender, MouseEventArgs args)
        {
            _isBeingDragged = false;
            var elementBeingDragged = (FrameworkElement)args.OriginalSource;
            var position = args.GetPosition(MyCanvas);
            double[] pos = new double[2];
            pos = Round_Coordinates(position.X, position.Y);
            Canvas.SetLeft(elementBeingDragged,pos[0] - elementBeingDragged.ActualWidth / 2);
            Canvas.SetTop(elementBeingDragged,pos[1] - elementBeingDragged.ActualHeight / 2);
        }
        private double[] Round_Coordinates(double left, double top)
        {
            double[] pos = new double[2];
            pos[0] = left;
            pos[1] = top;

            for (int x = 0; x < 2; x++)
            {
                if (pos[x] % 20 > 9)
                {
                    pos[x] = pos[x] + (20 - (pos[x] % 20));
                }
                else
                {
                    pos[x] = pos[x] - (pos[x] % 20);
                }

                if (x == 0 && pos[x] > 360)
                {
                    pos[x] = 360;
                }
                else if (x == 0 && pos[x] < 0)
                {
                    pos[x] = 0;
                }

                if (x == 1 && pos[x] > 280)
                {
                    pos[x] = 280;
                }
                else if (x == 1 && pos[x] < 0)
                {
                    pos[x] = 0;
                }
            }

            return pos;
        }
        public void Write()
        {
            var engine = new FileHelperEngine<Poz>();

            var orders = new List<Poz>();

            orders.Add(new Poz()
            {
                pozL = pozice[0, 0],
                pozT = pozice[0, 1],
            });
            orders.Add(new Poz()
            {
                pozL = pozice[1, 0],
                pozT = pozice[1, 1],
            });
            orders.Add(new Poz()
            {
                pozL = pozice[2, 0],
                pozT = pozice[2, 1],
            });
            orders.Add(new Poz()
            {
                pozL = pozice[3, 0],
                pozT = pozice[3, 1],
            });


            engine.WriteFile("poz.txt", orders);
        }


        /*bool captured = false;
        double x_shape, x_canvas, y_shape, y_canvas;
        UIElement source = null;

        public IInputElement LayoutRoot { get; private set; }

        private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            source = (UIElement)sender;
            Mouse.Capture(source);
            captured = true;
            x_shape = Canvas.GetLeft(source);
            x_canvas = e.GetPosition(LayoutRoot).X;
            y_shape = Canvas.GetTop(source);
            y_canvas = e.GetPosition(LayoutRoot).Y;

        }
        private void shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (captured)
            {
                double x = e.GetPosition(LayoutRoot).X;
                double y = e.GetPosition(LayoutRoot).Y;
                x_shape += x - x_canvas;
                Canvas.SetLeft(source, x_shape);
                x_canvas = x;
                y_shape += y - y_canvas;
                Canvas.SetTop(source, y_shape);
                y_canvas = y;
            }
        }
        private void shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            captured = false;
            int x = (int)Math.Ceiling(x_canvas);
            int y = (int)Math.Ceiling(y_canvas);
            int[] arr1 = new int[] { x, y };
            int counter = 0;
            foreach (int z in arr1)
            {
                if(z % 40 > 20)
                {
                    x_canvas = z + (40 - (z % 40));
                    y_canvas = z + (40 - (z % 40));
                } else
                {
                    x_canvas = z - (z % 40);
                    y_canvas = z - (z % 40);
                }
                counter++;
            }
        }*/

    }
}
