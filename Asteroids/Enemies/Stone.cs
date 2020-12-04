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

        public bool isDestroyed { get; private set; }

        public abstract IEnumerable<Element> Destroy();

        protected Stone(double dx, double dy)
        {
            dX = dx;
            dY = dy;
            isDestroyed = false;
        }

        public void MarkDestroed()
        {
            isDestroyed = true;
        }

        public void Move()
        {
            Position = new Point(Position.X + dX, Position.Y + dY);
        }

        public override string ToString()
        {
            return $"Stone [{this.Position.X:f4}:{this.Position.Y:f4}] {this.Size:f4}\n";
        }
    }
}
