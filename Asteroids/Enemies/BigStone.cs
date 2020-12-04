using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class BigStone : Stone
    {
        public BigStone(Point point, double dx, double dy) :base (dx, dy)
        {
            Position = point;
            Size = Big;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>()
            {
                new MediumStone(Position, 0, 5),
                //new MediumStone(position, 0, -5),
                //new MediumStone(position, 5, 0),
            };
        }
    }
}
