using Asteroids.Abstracts;
using Asteroids.Enemies;
using Asteroids.Weapons;
using System.Linq;
using System.Windows;

namespace Asteroids
{
    public partial class GameCore
    {
        private void CollisionsAndWeapoin()
        {
            for (int i = 0; i < _stones.Count; i++)
            {
                for (int j = i + 1; j < _stones.Count; j++)
                {
                    Maths.Collision(_stones[i], _stones[j]);
                    if (_stones[i].isDestroyed)
                        break;
                }
            }

            for (int buletIndex = 0; buletIndex < _bulets.Count; buletIndex++)
            {
                for (int stoneIndex = 0; stoneIndex < _stones.Count; stoneIndex++)
                {
                    Maths.Collision(_bulets[buletIndex],_stones[stoneIndex]);
                    if (_bulets[buletIndex].isDestroyed)
                        break;
                }

                for (int branderIndex = 0; branderIndex < _branders.Count; branderIndex++)
                {

                    Maths.Collision(_bulets[buletIndex], _branders[branderIndex]);
                    if (_bulets[buletIndex].isDestroyed)
                        break;
                }
            }

            if (_laser.Enabled)
            {
                foreach (Stone stone in _stones)
                {
                    if (Maths.Distance(stone.Position, _laser.Position, new Point(400, 225)) < stone.Size)
                        stone.MarkDestroed();
                }

                foreach (Bulet bulet in _bulets)
                {
                    if (Maths.Distance(bulet.Position, _laser.Position, new Point(400, 255)) < bulet.Size)
                        bulet.MarkDestroed();
                }

                foreach (Brander brander in _branders)
                {
                    if (Maths.Distance(brander.Position, _laser.Position, new Point(400, 255)) < brander.Size)
                        brander.MarkDestroed();
                }
            }
        }

        private void LostFocus()
        {
            _movables.Where(m => Maths.inSpase((Element)m));
        }
    }
}
