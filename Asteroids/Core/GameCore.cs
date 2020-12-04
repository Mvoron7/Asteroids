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
        private const int DELAY = 41; // ~24 FPS

        private bool _isRun;
        private readonly List<Stone> _stones;
        private readonly List<Bulet> _bulets;
        private readonly List<Brander> _branders;
        private readonly Laser _laser;

        private readonly List<IMovable> _movables;
        private readonly List<IDestructible> _destructibles;

        private readonly IWindow _window;

        public GameCore(IWindow window)
        {
            _stones = new List<Stone>();
            _bulets = new List<Bulet>();
            _branders = new List<Brander>();
            _movables = new List<IMovable>();
            _destructibles = new List<IDestructible>();
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
                Thread.Sleep(DELAY);
            }
        }

        private void Takt()
        {
            States state = _window.State();

            Brander.target = new Point(400, 225);

            MoveObjects();
            //IsGameOver();
            CollisionsAndWeapoin();
            LostFocus();
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
            _movables.ForEach(m => m.Move());
        }

        internal void Stop()
        {
            _isRun = false;
        }
    }
}
