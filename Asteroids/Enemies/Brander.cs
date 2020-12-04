using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class Brander : Enemy, IMovable, IDestructible
    {
        public static Point target;
        private readonly int _speed;

        public bool isDestroyed { get; private set; }

        public double dX { get; private set; }
        public double dY { get; private set; }

        public Brander(Point point, int speed)
        {
            Position = point;
            _speed = speed;
            Size = 15;
            isDestroyed = false;
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
            return $"Brander [{this.Position.X:f4}:{this.Position.Y:f4}] {this.Size:f4}\n";
        }

        public void MarkDestroed()
        {
            isDestroyed = true;
        }
    }
}
