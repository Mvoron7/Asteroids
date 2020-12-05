using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public abstract class Stone : Enemy, IMovable, IDestructible
    {
        public const double Big = 20.0;
        public const double Medium = 10.0;
        public const double Small = 5.0;

        public double dX { get; private set; }
        public double dY { get; private set; }

        private bool _destroyed;
        private bool _runAway;

        protected Stone(double dx, double dy)
        {
            dX = dx;
            dY = dy;
            _destroyed = false;
        }

        public override int GetPoint()
        {
            return 2;
        }

        public override bool NeedRemoved()
        {
            return _destroyed || _runAway;
        }

        public override string ToString()
        {
            return $"Stone [{Position.X:f4}:{Position.Y:f4}] {Size:f4}\n";
        }

        #region IMovable
        public void Move()
        {
            Position = new Point(Position.X + dX, Position.Y + dY);
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
        #endregion

        #region IDestructible
        public bool IsDestroyed()
        {
            return _destroyed;
        }

        public void MarkDestroed()
        {
            _destroyed = true;
        }

        public abstract IEnumerable<Element> Destroy();
        #endregion
    }
}
