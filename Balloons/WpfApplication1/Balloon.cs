using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace WpfApplication1
{
    // ENCAPSULATIE

    class Balloon
    {
        private int x = 10;
        private int y = 10;
        private int diameter = 10;
        private int fontSize = 1;

        Ellipse ellipse = new Ellipse();
        Brush background = new LinearGradientBrush(Colors.Black, Colors.Red, 20);
        TextBlock TxtBlck = new TextBlock();


        public Balloon(Canvas canvas, int diameter)
        {
            this.diameter = diameter;

            UpdateEllipse(canvas);
        }

        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            this.diameter = diameter;
            x = xpos;
            y = height;

            UpdateEllipse(canvas);
        }

        void UpdateEllipse(Canvas canvas)
        {
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = background;
            TxtBlck.Text = "Happy Birthday!";
            TxtBlck.Height = diameter;
            TxtBlck.Width = diameter;
            TxtBlck.Margin = new Thickness(x + diameter / 4, y + diameter / 2, 0, 0);
            TxtBlck.FontSize = fontSize;
            TxtBlck.FontFamily = new FontFamily("Murp");

            canvas.Children.Add(ellipse);
            canvas.Children.Add(TxtBlck);
        }

        public void Grow()
        {
            diameter += 10;
            ellipse.Width = diameter;
            ellipse.Height = diameter;

            fontSize = fontSize + 2;
            TxtBlck.Width = diameter;
            TxtBlck.Height = diameter;
            TxtBlck.FontSize = fontSize;
            TxtBlck.Margin = new Thickness(x, y + diameter / 2, 0, 0);
        }

        public void Move()
        {
            y -= 10;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            TxtBlck.Margin = new Thickness(x, y + diameter / 2, 0, 0);
        }

    }
}
