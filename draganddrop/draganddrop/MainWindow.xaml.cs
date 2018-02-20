using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Windows.Forms;
using FileHelpers;
using System.Windows.Shapes;
using System;

namespace draganddrop
{
    public partial class MainWindow : Window
    {

        Rectangle obj;
        private bool _isRectDragInProg = false;
        int row;
        int column;
        bool isFilled = false;
        public MainWindow()
        {
            InitializeComponent();
            var engine = new FileHelperEngine<Position>();
            if (File.Exists("position.txt"))
            {
                var records = engine.ReadFile("position.txt");

                foreach (var record in records)
                {
                    var element = record.Name;
                    double x = record.xpos;
                    double y = record.ypos;

                    Rectangle fieldTB = (Rectangle)this.FindName(element);
                    Grid.SetColumn(fieldTB, (int)x);
                    Grid.SetRow(fieldTB, (int)y);

                }
            }
            Zbran zbran = new Zbran(250);

        }

        [DelimitedRecord(",")]
        public class Position
        {

            public string Name;
            public double xpos;
            public double ypos;

        }

        private void move_Rectangle(object sender, MouseButtonEventArgs e)
        {
            int[,] pozice = new int[100, 2];
            /*while (true)
            {*/
            if (_isRectDragInProg == false)
            {
                _isRectDragInProg = true;
                obj = sender as Rectangle;
                Panel.SetZIndex(obj, 100);

                //Console.WriteLine(obj.Name);

                obj.CaptureMouse();




                //Console.WriteLine(pocetradky);
                //Console.WriteLine(pocetsloupce);


            }
            else if (_isRectDragInProg == true)
            {
                List<Pozice> fill = new List<Pozice>();
                List<Pozice> akt = new List<Pozice>();

                foreach (UIElement cell in grid.Children)
                {
                    int x = Grid.GetColumn(cell);
                    int y = Grid.GetRow(cell);
                    int xa = Grid.GetColumnSpan(cell);
                    int ya = Grid.GetRowSpan(cell);


                    if (cell.GetValue(NameProperty).ToString() == obj.Name)
                    {
                        Console.WriteLine(cell.GetValue(NameProperty));
                        Console.WriteLine(obj.Name);
                        if (xa == 0)
                        {

                            akt.Add(new Pozice(x + 1, y));
                            akt.Add(new Pozice(x, y));
                        }
                        else
                        {
                            akt.Add(new Pozice(x, y));
                        }

                        if (ya == 0)
                        {
                            akt.Add(new Pozice(x, y + 1));
                            akt.Add(new Pozice(x, y));
                        }
                        else
                        {
                            akt.Add(new Pozice(x, y));
                        }

                    }
                    else
                    {
                        Console.WriteLine(cell.GetValue(NameProperty));


                        if (xa == 0)
                        {

                            fill.Add(new Pozice(x + 1, y));
                            fill.Add(new Pozice(x, y));
                        }
                        else
                        {
                            fill.Add(new Pozice(x, y));
                        }

                        if (ya == 0)
                        {
                            fill.Add(new Pozice(x, y + 1));
                            fill.Add(new Pozice(x, y));
                        }
                        else
                        {
                            fill.Add(new Pozice(x, y));
                        }

                    }

                }
                foreach (var o in fill)
                {
                    Console.WriteLine(o.x + ", " + o.y);
                }
                foreach (var d in akt)
                {
                    Console.WriteLine(d.x + ", " + d.y);
                }

                foreach (var o in akt)
                {

                    foreach (var d in fill)
                    {
                        if (d.x == o.x && d.y == o.y)
                        {
                            isFilled = true;
                            Console.WriteLine(isFilled);
                        }


                    }

                }
                if (isFilled == true)
                {

                    _isRectDragInProg = true;

                }
                else
                {

                    obj.ReleaseMouseCapture();

                    Panel.SetZIndex(obj, 0);
                    _isRectDragInProg = false;
                    var engine = new FileHelperEngine<Position>();

                    var orders = new List<Position>();

                    orders.Add(new Position()
                    {
                        Name = obj.Name,
                        xpos = Grid.GetColumn(obj),
                        ypos = Grid.GetRow(obj)
                    });

                    engine.AppendToFile("position.txt", orders);
                }
                isFilled = false;
                /*{
                    //break;
                }
                else
                {
                    obj.ReleaseMouseCapture();
                    _isRectDragInProg = false;
                    _isRectDragInProg = true;
                }*/

            }
            //}



        }

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(_isRectDragInProg);
            if (_isRectDragInProg == true)
            {
                var mousePos = e.GetPosition(grid);
                double left;
                double top;
                if (mousePos.X < 0)
                {
                    left = 0;
                }
                else if (mousePos.X > 520)
                {
                    left = 8;
                }
                else
                {
                    left = mousePos.X / 40;
                }

                if (mousePos.Y < 0)
                {
                    top = 0;
                }
                else if (mousePos.Y > 280)
                {
                    top = 4;
                }
                else
                {
                    top = mousePos.Y / 40;
                }

                column = (int)left;
                if (Grid.GetColumnSpan(obj) >= 2 && column >= 12)
                {
                    column = 13 - Grid.GetColumnSpan(obj);
                }
                row = (int)top;
                if (Grid.GetRowSpan(obj) >= 2 && row >= 6)
                {
                    row = 7 - Grid.GetRowSpan(obj);
                }


                Grid.SetColumn(obj, column);
                Grid.SetRow(obj, row);
            }
        }
        /*public void getPosition(UIElement element, out int col, out int row)
        {
            DControl control =  as DControl;
            var point = Mouse.GetPosition(element);
            row = 0;
            col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            // calc row mouse was over
            foreach (var rowDefinition in control.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in control.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
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
            var engine = new FileHelperEngine<Position>();

            var orders = new List<Position>();

            orders.Add(new Position()
            {
                Name = elementBeingDragged.Name,
                x = pos[0],
                y = pos[1]
            });

            engine.WriteFile("position.txt", orders);

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

                if (x == 0 && pos[x] > 520)
                {
                    pos[x] = 480;
                }
                else if (x == 0 && pos[x] < 0)
                {
                    pos[x] = 40;
                }

                if (x == 1 && pos[x] > 280)
                {
                    pos[x] = 240;
                }
                else if (x == 1 && pos[x] < 0)
                {
                    pos[x] = 40;
                }
            }

            return pos;
        }


        bool captured = false;
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
