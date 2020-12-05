using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class Brander : Enemy, IMovable, IDestructible
    {
        public static Point target;
        private readonly int _speed;

        public double dX { get; private set; }
        public double dY { get; private set; }

        private bool _destroyed;
        private bool _runAway;

        public Brander(Point point, int speed)
        {
            Size = 15;
            Position = point;
            _speed = speed;
            _destroyed = false;
            _runAway = false;
        }

        public override int GetPoint()
        {
            return 5;
        }

        public override bool NeedRemoved()
        {
            return _destroyed || _runAway;
        }

        public void Move()
        {
            Position = Maths.GetTargetPoint(Position, target, _speed);
        }

        public IEnumerable<Element> Destroy()
        {
            return new List<Element>();
        }

        public override string ToString()
        {
            return $"Brander [{Position.X:f4}:{Position.Y:f4}] {Size:f4}\n";
        }

        public void MarkDestroed()
        {
            _destroyed = true;
        }

        public bool IsDestroyed()
        {
            return _destroyed;
        }

        public Point GetPosition()
        {
            return Position;
        }

        public void MarkAsRunAway()
        {
            _runAway = true;
        }

        public bool IsRunAway()
        {
            return _runAway;
        }
    }
}
