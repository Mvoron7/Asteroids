using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Weapons
{
    /// <summary>Снаряд выпускаемые кораблем</summary>
    public class Bulet : Weapon, IMovable, IDestructible
    {
        public Bulet(Point point, double dx, double dy)
        {
            position = point;
            dX = dx;
            dY = dy;
            Size = 4.9;
        }

        public IEnumerable<Element> Destroy()
        {
            return new List<Element>();
        }

        public override string ToString()
        {
            return $"Bulet [{this.position.X:f4}:{this.position.Y:f4}] {this.Size:f4}\n";
        }
    }
}
