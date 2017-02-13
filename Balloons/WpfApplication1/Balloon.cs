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
        private int fontSize = 10;

        Ellipse ellipse = new Ellipse();
        Brush background = new LinearGradientBrush(Colors.White, Colors.Black, 20);
        TextBlock TxtBlck = new TextBlock();
        Canvas cans = new Canvas();


        public Balloon(Canvas canvas, int diameter)
        {
            cans = canvas;
            this.diameter = diameter;

            UpdateEllipse();
        }

        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            cans = canvas;
            this.diameter = diameter;
            x = xpos;
            y = height;

            UpdateEllipse();
        }

        void UpdateEllipse()
        {
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = new SolidColorBrush(Colors.White);
            ellipse.Fill = background;
            TxtBlck.Text = "Oh dierbaar België";
            TxtBlck.Height = diameter;
            TxtBlck.Width = diameter;
            TxtBlck.Margin = new Thickness(x + diameter / 4, y + diameter / 2, 0, 0);
            TxtBlck.FontSize = fontSize;
            TxtBlck.FontFamily = new FontFamily("Murp");

            cans.Children.Add(ellipse);
            cans.Children.Add(TxtBlck);
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

        public Brush Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                UpdateEllipse();
            }
        }

    }
}
