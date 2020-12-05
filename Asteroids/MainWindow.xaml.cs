using Asteroids.Abstracts;
using Asteroids.Structures;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Asteroids
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private readonly Brush stone = new SolidColorBrush(Colors.Aqua);
        private readonly Brush bulet = new SolidColorBrush(Colors.BlueViolet);
        private readonly Brush brander = new SolidColorBrush(Colors.Chocolate);
        private readonly Brush laser = new SolidColorBrush(Colors.Red);
        private readonly Brush laser_work = new SolidColorBrush(Colors.Green);
        private readonly Brush laser_reload = new SolidColorBrush(Colors.Blue);
        private readonly Brush ship = new SolidColorBrush(Colors.Purple);
        private readonly GameCore _core;

        protected bool runGame;

        public MainWindow()
        {
            InitializeComponent();

            _core = new GameCore(this);

            runGame = true;
            _core.Start();
        }

        #region IWindow
        public void Render(ToRender elements)
        {
            DoInvoke(() =>
            {
                Space.Children.Clear();
                Vector.Text = "";

                elements.Stones.ForEach(e =>
                {
                    Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = stone,
                        Margin = new Thickness(e.Position.X - e.Size, e.Position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Vector.Text += e.ToString();
                });

                elements.Bulets.ForEach(e =>
                {
                    Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = bulet,
                        Margin = new Thickness(e.Position.X - e.Size, e.Position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Vector.Text += e.ToString();
                });

                elements.Branders.ForEach(e =>
                {
                    Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = brander,
                        Margin = new Thickness(e.Position.X - e.Size, e.Position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Vector.Text += e.ToString();
                });

                LaserPower.Maximum = elements.Laser.MaxPower;
                LaserPower.Value = elements.Laser.Power;
                LaserPower.Foreground = elements.Laser.Reloaded ? laser_work : laser_reload;
                if (elements.Laser.Enabled)
                {
                    Space.Children.Add(new Line()
                    {
                        Stroke = laser,
                        X1 = elements.Laser.FromPoint.X,
                        Y1 = elements.Laser.FromPoint.Y,
                        X2 = elements.Laser.Position.X,
                        Y2 = elements.Laser.Position.Y,
                        StrokeThickness = 5,
                    });
                    Vector.Text += elements.Laser.ToString();
                }

                Space.Children.Add(new Ellipse()
                {
                    Height = elements.Ship.Size * 2,
                    Width = elements.Ship.Size * 2,
                    Fill = ship,
                    Margin = new Thickness(elements.Ship.Position.X - elements.Ship.Size, elements.Ship.Position.Y - elements.Ship.Size, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                });
                Vector.Text += elements.Ship.ToString();
            });
        }

        public States State()
        {
            States states = new States();
            DoInvoke(() =>
            {
                states.mousePosition = Mouse.GetPosition(Space);
                states.Left = Mouse.LeftButton == MouseButtonState.Pressed;
                states.Right = Mouse.RightButton == MouseButtonState.Pressed;
            });

            return states;
        }
        #endregion

        private void DoInvoke(Action action, DispatcherPriority priority = DispatcherPriority.Normal)
        {
            if (runGame)
                Dispatcher.Invoke(action, priority);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            runGame = false;
            _core.Stop();
        }
    }
}
