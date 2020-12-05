using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class BigStone : Stone
    {
        public BigStone(Point point, double dx, double dy) : base(dx, dy)
        {
            Position = point;
            Size = Big;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>()
            {
                new MediumStone(new Point(Position.X, Position.Y - 11.6), 0, -5),
                new MediumStone(new Point(Position.X + 10.1, Position.Y + 5.8), 4.3, 2.5),
                new MediumStone(new Point(Position.X - 10.1, Position.Y + 5.8), -4.3, 2.5),
            };
        }
    }
}
