using System;
using System.Windows;

namespace Asteroids.Enemies
{
    public class CleverStone : BigStone
    {
        public static Point target;

        private int _speed { get => (int)Math.Sqrt(dX * dX + dY * dY); }

        public CleverStone(Point point, double dx, double dy) : base(point, dx, dy) { }

        public new void Move()
        {
            Position = Maths.GetTargetPoint(Position, target, _speed);
        }
    }
}
