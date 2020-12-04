using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class SmallStone : Stone
    {
        public SmallStone(Point point, double dx, double dy) : base(dx, dy)
        {
            Position = point;
            Size = Small;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>();
        }
    }
}
