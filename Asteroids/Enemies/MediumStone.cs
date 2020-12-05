using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class MediumStone : Stone
    {
        public MediumStone(Point point, double dx, double dy) : base(dx, dy)
        {
            Position = point;
            Size = Medium;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>()
            {
                new SmallStone(new Point(Position.X, Position.Y - 5.8), 0, -2.5),
                new SmallStone(new Point(Position.X + 5.1, Position.Y + 2.9), 2.2, 1.25),
                new SmallStone(new Point(Position.X - 5.1, Position.Y + 2.9), -2.2, 1.25),
            };
        }
    }
}
