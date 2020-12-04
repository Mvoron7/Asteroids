using System;
using System.Windows;

namespace Asteroids.Abstracts
{
    public abstract class Element
    {
        public Point position;

        public double dX { get; set; }
        public double dY { get; set; }

        public double Size { get; set; }

        public virtual void Move()
        {
            position = new Point(position.X + dX, position.Y + dY);
        }

        public bool Collapse(Element e)
        {
            double dX = this.position.X - e.position.X;
            double dY = this.position.Y - e.position.Y;
            double distance = Math.Sqrt(dX * dX + dY * dY);

            return distance < (e.Size + this.Size);
        }

        public bool isDestroyed { get; set; }
    }
}
