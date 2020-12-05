using Asteroids.Abstracts;
using Asteroids.Structures;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Asteroids.RenderModules
{
    /// <summary>неизбежное дублирование кода</summary>
    public class Both : IRender
    {
        private readonly Brush stone = new SolidColorBrush(Colors.Aqua);
        private readonly Brush bulet = new SolidColorBrush(Colors.BlueViolet);
        private readonly Brush brander = new SolidColorBrush(Colors.Chocolate);
        private readonly Brush laser = new SolidColorBrush(Colors.Red);
        private readonly Brush laser_work = new SolidColorBrush(Colors.Green);
        private readonly Brush laser_reload = new SolidColorBrush(Colors.Blue);
        private readonly Brush ship = new SolidColorBrush(Colors.Purple);

        public MainWindow Window { get; set; }

        public Action GetRenderModule(ToRender elements)
        {
            return new Action(() => {
                Window.Space.Children.Clear();
                Window.Vector.Text = "";

                elements.Stones.ForEach(e =>
                {
                    Window.Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = stone,
                        Margin = new Thickness(e.Position.X - e.Size, e.Position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Window.Vector.Text += e.ToString();
                });

                elements.Bulets.ForEach(e =>
                {
                    Window.Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = bulet,
                        Margin = new Thickness(e.Position.X - e.Size, e.Position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Window.Vector.Text += e.ToString();
                });

                elements.Branders.ForEach(e =>
                {
                    Window.Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = brander,
                        Margin = new Thickness(e.Position.X - e.Size, e.Position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Window.Vector.Text += e.ToString();
                });

                Window.LaserPower.Maximum = elements.Laser.MaxPower;
                Window.LaserPower.Value = elements.Laser.Power;
                Window.LaserPower.Foreground = elements.Laser.Reloaded ? laser_work : laser_reload;
                if (elements.Laser.Enabled)
                {
                    Window.Space.Children.Add(new Line()
                    {
                        Stroke = laser,
                        X1 = elements.Laser.FromPoint.X,
                        Y1 = elements.Laser.FromPoint.Y,
                        X2 = elements.Laser.Position.X,
                        Y2 = elements.Laser.Position.Y,
                        StrokeThickness = 5,
                    });
                    Window.Vector.Text += elements.Laser.ToString();
                }

                Window.Space.Children.Add(new Ellipse()
                {
                    Height = elements.Ship.Size * 2,
                    Width = elements.Ship.Size * 2,
                    Fill = ship,
                    Margin = new Thickness(elements.Ship.Position.X - elements.Ship.Size, elements.Ship.Position.Y - elements.Ship.Size, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                });
                Window.Vector.Text += elements.Ship.ToString();
                Window.Points.Text = $"Очки: {elements.Points}";

            });
        }
    }
}
