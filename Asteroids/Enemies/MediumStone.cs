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
                new SmallStone(Position, 0, 5),
                //new SmallStone(position, 0, -5),
                //new SmallStone(position, 5, 0),
            };
        }
    }
}
