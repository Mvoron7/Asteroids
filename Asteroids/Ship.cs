using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids
{
    public class Ship : Element, IMovable, IDestructible
    {
        public double dX { get; private set; }
        public double dY { get; private set; }

        private bool _destroyed;

        public Ship()
        {
            Position = new Point(GameCore.WIDTH_MIDDLE, GameCore.HEIGHT_MIDDLE);
            Size = 25;
            _destroyed = false;
        }

        public Point GetPosition()
        {
            return Position;
        }

        public override string ToString()
        {
            return $"Ship [{Position.X:f4}:{Position.Y:f4}] {Size:f4}\n";
        }

        internal void SetMove(Point targetPosition)
        {
            Point nextPoint = Maths.GetTargetPoint(Position, targetPosition, 1);

            dX = nextPoint.X - Position.X;
            dY = nextPoint.Y - Position.Y;
        }

        internal void Reset()
        {
            Position = new Point(GameCore.WIDTH_MIDDLE, GameCore.HEIGHT_MIDDLE);
            _destroyed = false;
        }

        #region IMovable
        public bool IsRunAway()
        {
            return false;
        }

        public void MarkAsRunAway()
        {
            // Корабль не может покинуть поле
        }

        public void Move()
        {
            double newX = Position.X + dX;
            double newY = Position.Y + dY;

            Point newPosition = new Point(newX, newY);

            Position = Maths.CheckMirror(newPosition);
        }
        #endregion

        #region IDestructible
        public IEnumerable<Element> Destroy()
        {
            return new List<Element>();
        }

        public bool IsDestroyed()
        {
            return _destroyed;
        }

        public void MarkDestroed()
        {
            _destroyed = true;
        }

        public override bool NeedRemoved()
        {
            return false;
        }
        #endregion
    }
}
