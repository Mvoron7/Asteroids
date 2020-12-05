using Asteroids.Abstracts;
using Asteroids.Enemies;
using Asteroids.Structures;
using Asteroids.Weapons;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace Asteroids
{
    public partial class GameCore
    {
        //Размеры поля считаем неизменными.
        public const int WIDTH = 800;
        public const int WIDTH_MIDDLE = 400;
        public const int HEIGHT = 450;
        public const int HEIGHT_MIDDLE = 225;

        private const int DELAY = 41; // ~24 FPS

        private int _points;

        private bool _isRun;
        private readonly List<Stone> _stones;
        private readonly List<Bulet> _bulets;
        private readonly List<Brander> _branders;
        private readonly Laser _laser;
        private readonly Ship _ship;

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
            _ship = new Ship();
            _random = new Random(DateTime.Now.Millisecond);

            _window = window;
        }

        internal void Start()
        {
            ClearLists();
            _ship.Reset();
            _points = 0;

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
            GameOver();
        }

        internal void Stop()
        {
            _isRun = false;
        }

        private void GameOver()
        {
            _window.SetGameOver();
        }

        private void Takt()
        {
            States state = _window.State();

            MoveShip(state.mousePosition);
            MoveObjects();
            CollisionsAndWeapoin();
            CalcPoints();
            IsGameOver();
            LostFocus();
            Remove();
            SpawnEnemies();

            _laser.Disable();
            _laser.Reload();

            Shoot(state);

            _window.Render(new ToRender()
            {
                Stones = _stones,
                Bulets = _bulets,
                Branders = _branders,
                Laser = _laser,
                Ship = _ship,
                Points = _points,
            });
        }

        private void CalcPoints()
        {
            foreach (Stone stone in _stones)
                if (stone.IsDestroyed())
                    _points += stone.GetPoint();

            foreach (Brander brander in _branders)
                if (brander.IsDestroyed())
                    _points += brander.GetPoint();
        }

        private void IsGameOver()
        {
            if (ShipCollisions())
            {
                _ship.MarkDestroed();
                _isRun = false;
            }
        }

        private void MoveShip(Point position)
        {
            _ship.SetMove(position);
            _ship.Move();
            Brander.target = _ship.Position;
            _laser.FromPoint = _ship.Position;
        }

        private void MoveObjects()
        {
            _movables.ForEach(m => m.Move());
        }

        private void ClearLists()
        {
            _stones.Clear();
            _bulets.Clear();
            _branders.Clear();
            _movables.Clear();
            _destructibles.Clear();
        }
    }
}