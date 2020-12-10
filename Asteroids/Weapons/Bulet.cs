using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Weapons
{
    /// <summary>Снаряд выпускаемый кораблем</summary>
    public class Bulet : Weapon, IMovable, IDestructible
    {
        public double dX { get; private set; }
        public double dY { get; private set; }

        private bool _destroyed;
        private bool _runAway;

        public Bulet(Point point, double dx, double dy)
        {
            Position = point;
            dX = dx;
            dY = dy;
            Size = 4.9;
        }

        public override bool NeedRemoved()
        {
            return _destroyed || _runAway;
        }

        public override string ToString()
        {
            return $"Bulet [{Position.X:f4}:{Position.Y:f4}] {Size:f4}\n";
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

        public IEnumerable<Element> Destroy()
        {
            return new List<Element>();
        }
        #endregion
    }
}
