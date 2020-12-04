using Asteroids.Enemies;
using Asteroids.Weapons;
using System.Linq;
using System.Windows;

namespace Asteroids
{
    public partial class GameCore
    {
        private void CollapseAndDestoy()
        {
            for (int i = 0; i < _stones.Count; i++)
            {
                for (int j = i + 1; j < _stones.Count; j++)
                {
                    if (_stones[i].Collapse(_stones[j]))
                    {
                        _stones[i].isDestroyed = true;
                        _stones[j].isDestroyed = true;
                        break;
                    }
                }
            }

            for (int buletIndex = 0; buletIndex < _bulets.Count; buletIndex++)
            {
                for (int stoneIndex = 0; stoneIndex < _stones.Count; stoneIndex++)
                {
                    if (_bulets[buletIndex].Collapse(_stones[stoneIndex]))
                    {
                        _bulets[buletIndex].isDestroyed = true;
                        _stones[stoneIndex].isDestroyed = true;
                        break;
                    }
                }

                for (int branderIndex = 0; branderIndex < _branders.Count; branderIndex++)
                {
                    if (_bulets[buletIndex].Collapse(_branders[branderIndex]))
                    {
                        _bulets[buletIndex].isDestroyed = true;
                        _branders[branderIndex].isDestroyed = true;
                        break;
                    }
                }
            }

            if (_laser.Enabled)
            {
                foreach (Stone stone in _stones)
                {
                    if (Maths.Distance(stone.position, _laser.position, new Point(400, 225)) < stone.Size)
                        stone.isDestroyed = true;
                }

                foreach (Bulet bulet in _bulets)
                {
                    if (Maths.Distance(bulet.position, _laser.position, new Point(400, 255)) < bulet.Size)
                        bulet.isDestroyed = true;
                }

                foreach (Brander brander in _branders)
                {
                    if (Maths.Distance(brander.position, _laser.position, new Point(400, 255)) < brander.Size)
                        brander.isDestroyed = true;
                }
            }
        }

        private void LostFocus()
        {
            _elements = _elements.Where(e => Maths.inSpase(e)).ToList();
        }
    }
}
