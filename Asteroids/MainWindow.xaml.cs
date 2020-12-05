using Asteroids.Abstracts;
using Asteroids.RenderModules;
using Asteroids.Structures;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Asteroids
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private readonly GameCore _core;

        protected bool runGame;

        private readonly IRender[] renders;
        private IRender actualRenders;

        public MainWindow()
        {
            InitializeComponent();

            renders = new IRender[] {
                new Both() { Window = this },
                new Visual() { Window = this },
                new RenderModules.Vector() { Window = this },
            };

            SetActualRenders(0);

            _core = new GameCore(this);
        }

        #region IWindow
        public void Render(ToRender elements)
        {
            DoInvoke(actualRenders.GetRenderModule(elements));
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

        public void SetGameOver()
        {
            DoInvoke(() => Restart.Visibility = Visibility.Visible);
        }
        #endregion

        private void SetActualRenders(int index)
        {
            actualRenders = renders[index];
        }

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

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    SetActualRenders(0);
                    break;
                case Key.D2:
                    SetActualRenders(1);
                    break;
                case Key.D3:
                    SetActualRenders(2);
                    break;
            }
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            Restart.Visibility = Visibility.Collapsed;
            runGame = true;
            _core.Start();
        }
    }
}
