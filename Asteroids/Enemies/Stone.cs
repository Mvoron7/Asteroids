using Asteroids.Abstracts;
using System.Collections.Generic;

namespace Asteroids.Enemies
{
    public abstract class Stone : Enemy
    {
        public const double Big = 20.0;
        public const double Medium = 10.0;
        public const double Small = 5.0;

        public abstract IEnumerable<Element> Destroy();

        public override string ToString()
        {
            return $"Stone [{this.position.X:f4}:{this.position.Y:f4}] {this.Size:f4}\n";
        }
    }
}
