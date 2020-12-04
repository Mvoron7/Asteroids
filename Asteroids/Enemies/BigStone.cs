using Asteroids.Abstracts;
using System.Collections.Generic;
using System.Windows;

namespace Asteroids.Enemies
{
    public class BigStone : Stone, IMovable, IDestructible
    {
        public BigStone(Point point, double dx, double dy)
        {
            position = point;
            dX = dx;
            dY = dy;
            Size = Stone.Big;
            isDestroyed = false;
        }

        public override IEnumerable<Element> Destroy()
        {
            return new List<Stone>()
            {
                new MediumStone(position, 0, 5),
                //new MediumStone(position, 0, -5),
                //new MediumStone(position, 5, 0),
            };
        }
    }
}
