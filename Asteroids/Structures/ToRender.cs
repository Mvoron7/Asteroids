using Asteroids.Abstracts;
using Asteroids.Enemies;
using Asteroids.Weapons;
using System.Collections.Generic;

namespace Asteroids.Structures
{
    public struct ToRender
    {
        public List<Stone> stones;
        public List<Bulet> bulets;
        public List<Brander> branders;
        public Laser laser;
        public Element ship;
    }
}
