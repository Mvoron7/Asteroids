using Asteroids.Abstracts;
using Asteroids.Enemies;
using Asteroids.Structures;
using Asteroids.Weapons;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace Asteroids
{
    public partial class GameCore
    {
        private bool _isRun;
        private List<Element> _elements;
        private List<Stone> _stones;
        private List<Bulet> _bulets;
        private List<Brander> _branders;
        private readonly Laser _laser;

        private List<IMovable> movables;
        private List<IDestructible> destructibles;

        private readonly IWindow _window;

        public GameCore(IWindow window)
        {
            _stones = new List<Stone>();
            _bulets = new List<Bulet>();
            _branders = new List<Brander>();
            _elements = new List<Element>();
            _laser = new Laser(100);

            AddElement(new BigStone(new Point(0, 0), 1, 1));
            AddElement(new BigStone(new Point(200, 200), -1, -1));
            AddElement(new BigStone(new Point(100, 0), 1, 2));

            AddElement(new Brander(new Point(0, 0), 1));

            _window = window;
        }

        internal void Start()
        {
            _isRun = true;
            new Thread(new ThreadStart(Run)).Start();
        }

        private void Run()
        {
            while (_isRun)
            {
                Takt();
                Thread.Sleep(41);
            }
        }

        private void Takt()
        {
            States state = _window.State();

            Brander.target = new Point(400, 225);

            MoveObjects();
            CollapseAndDestoy();
            LostFocus();
            //IsGameOver();
            Remove();

            _laser.Disable();
            _laser.Reload();

            Shoot(state);

            _window.Render(new ToRender()
            {
                stones = _stones,
                bulets = _bulets,
                branders = _branders,
                laser = _laser,
            });
        }

        private void MoveObjects()
        {
            _elements.ForEach(e => e.Move());
        }

        internal void Stop()
        {
            _isRun = false;
        }
    }
}
