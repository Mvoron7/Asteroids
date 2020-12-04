using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class SmallStone : Stone, IMovable, IDestructible
    {
        public SmallStone(Point point, double dx, double dy)
        {
            position = point;
            dX = dx;
            dY = dy;
            Size = Stone.Small;
            isDestroyed = false;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>();
        }
    }
}
