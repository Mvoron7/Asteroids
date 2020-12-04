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

        public bool isDestroyed { get; private set; }

        public Bulet(Point point, double dx, double dy)
        {
            Position = point;
            dX = dx;
            dY = dy;
            Size = 4.9;
        }

        public void Move()
        {
            Position = new Point(Position.X + dX, Position.Y + dY);
        }

        public IEnumerable<Element> Destroy()
        {
            return new List<Element>();
        }

        public override string ToString()
        {
            return $"Bulet [{this.Position.X:f4}:{this.Position.Y:f4}] {this.Size:f4}\n";
        }

        public void MarkDestroed()
        {
            isDestroyed = true;
        }
    }
}
