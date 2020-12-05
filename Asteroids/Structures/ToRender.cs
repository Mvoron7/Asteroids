using Asteroids.Abstracts;
using Asteroids.Enemies;
using Asteroids.Weapons;
using System.Collections.Generic;

namespace Asteroids.Structures
{
    public struct ToRender
    {
        public List<Stone> Stones;
        public List<Bulet> Bulets;
        public List<Brander> Branders;
        public Laser Laser;
        public Ship Ship;
    }
}
