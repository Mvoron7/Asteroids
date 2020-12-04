using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class Brander : Enemy, IMovable, IDestructible
    {
        public static Point target;
        private readonly int _speed;

        public Brander(Point point, int speed)
        {
            position = point;
            _speed = speed;
            Size = 15;
            isDestroyed = false;
        }

        public override void Move()
        {
            position = Maths.GetTargetPoint(position, target, _speed);
        }

        public IEnumerable<Element> Destroy()
        {
            return new List<Element>();
        }

        public override string ToString()
        {
            return $"Brander [{this.position.X:f4}:{this.position.Y:f4}] {this.Size:f4}\n";
        }
    }
}
