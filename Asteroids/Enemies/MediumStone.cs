using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class MediumStone : Stone, IMovable, IDestructible
    {
        public MediumStone(Point point, double dx, double dy)
        {
            position = point;
            dX = dx;
            dY = dy;
            Size = Stone.Medium;
            isDestroyed = false;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>()
            {
                new SmallStone(position, 0, 5),
                //new SmallStone(position, 0, -5),
                //new SmallStone(position, 5, 0),
            };
        }
    }
}
