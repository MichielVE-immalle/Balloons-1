﻿using System;
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


        public Balloon(Canvas canvas, int diameter) : this(canvas, diameter, 10, 10)
        {

        }

        public Balloon(Canvas canvas, int diameter, int height, int xpos)
        {
            cans = canvas;
            this.diameter = diameter;
            x = xpos;
            y = height;

            CreateEllipse();
        }

        void UpdateEllipse()
        {
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            ellipse.Margin = new Thickness(x, y, 0, 0);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = background;
            TxtBlck.Text = "België";
            TxtBlck.Height = diameter;
            TxtBlck.Width = diameter;
            TxtBlck.Margin = new Thickness(x + diameter / 4, y + diameter / 2, 0, 0);
            TxtBlck.FontSize = fontSize;
            TxtBlck.FontFamily = new FontFamily("Murp");
        }

        void CreateEllipse()
        {
            UpdateEllipse();

            cans.Children.Add(ellipse);
            cans.Children.Add(TxtBlck);
        }

        public void Grow()
        {
            diameter += 10;
           
            fontSize = fontSize + 2;
            UpdateEllipse();
        }

        public void Move()
        {
            y -= 10;
            UpdateEllipse();
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
