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
        private readonly GameCore core;

        protected bool runGame;

        public MainWindow()
        {
            InitializeComponent();

            core = new GameCore(this);

            runGame = true;
            core.Start();
        }

        public void Render(ToRender elements)
        {
            DoInvoke(() =>
            {
                Space.Children.Clear();
                Vector.Text = "";

                elements.stones.ForEach(e =>
                {
                    Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = stone,
                        Margin = new Thickness(e.position.X - e.Size, e.position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Vector.Text += e.ToString();
                });

                elements.bulets.ForEach(e =>
                {
                    Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = bulet,
                        Margin = new Thickness(e.position.X - e.Size, e.position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Vector.Text += e.ToString();
                });

                elements.branders.ForEach(e =>
                {
                    Space.Children.Add(new Ellipse()
                    {
                        Height = e.Size * 2,
                        Width = e.Size * 2,
                        Fill = brander,
                        Margin = new Thickness(e.position.X - e.Size, e.position.Y - e.Size, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                    });
                    Vector.Text += e.ToString();
                });

                LaserPower.Maximum = elements.laser.MaxPower;
                LaserPower.Value = elements.laser.Power;
                if (elements.laser.Enabled)
                {
                    Space.Children.Add(new Line()
                    {
                        Stroke = laser,
                        X1 = 400,
                        Y1 = 225,
                        X2 = elements.laser.position.X,
                        Y2 = elements.laser.position.Y,
                        StrokeThickness = 5,
                    });
                    Vector.Text += elements.laser.ToString();
                }
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

        private void DoInvoke(Action action, DispatcherPriority priority = DispatcherPriority.Normal)
        {
            if (runGame)
                Dispatcher.Invoke(action, priority);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            runGame = false;
            core.Stop();
        }
    }
}
