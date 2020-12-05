using Asteroids.Enemies;
using Asteroids.Weapons;

namespace Asteroids
{
    public partial class GameCore
    {
        private void CollisionsAndWeapoin()
        {
            for (int i = 0; i < _stones.Count; i++)
            {
                if (_stones[i].IsDestroyed())
                    continue;

                for (int j = i + 1; j < _stones.Count; j++)
                {
                    if (Maths.Collision(_stones[i], _stones[j]))
                    {
                        _stones[i].MarkDestroed();
                        _stones[j].MarkDestroed();
                        break;
                    }
                }
            }

            for (int buletIndex = 0; buletIndex < _bulets.Count; buletIndex++)
            {
                for (int stoneIndex = 0; stoneIndex < _stones.Count; stoneIndex++)
                {
                    if (_stones[stoneIndex].IsDestroyed())
                        continue;

                    if (Maths.Collision(_bulets[buletIndex], _stones[stoneIndex]))
                    {
                        _bulets[buletIndex].MarkDestroed();
                        _stones[stoneIndex].MarkDestroed();
                        break;
                    }
                }

                for (int branderIndex = 0; branderIndex < _branders.Count; branderIndex++)
                {
                    if (Maths.Collision(_bulets[buletIndex], _branders[branderIndex]))
                    {
                        _bulets[buletIndex].MarkDestroed();
                        _branders[branderIndex].MarkDestroed();
                        break;
                    }
                }
            }

            if (_laser.Enabled)
            {
                foreach (Stone stone in _stones)
                {
                    if (!stone.IsDestroyed() && Maths.Distance(stone.Position, _laser.FromPoint, _laser.Position) < stone.Size)
                        stone.MarkDestroed();
                }

                foreach (Bulet bulet in _bulets)
                {
                    if (!bulet.IsDestroyed() && Maths.Distance(bulet.Position, _laser.FromPoint, _laser.Position) < bulet.Size)
                        bulet.MarkDestroed();
                }

                foreach (Brander brander in _branders)
                {
                    if (!brander.IsDestroyed() && Maths.Distance(brander.Position, _laser.FromPoint, _laser.Position) < brander.Size)
                        brander.MarkDestroed();
                }
            }
        }

        private void LostFocus()
        {
            _movables.ForEach(
            m =>
            {
                if (!Maths.IsInSpace(m))
                    m.MarkAsRunAway();
            });
        }


        private bool ShipCollisions()
        {
            foreach (Stone stone in _stones)
            {
                if (Maths.Collision(stone, _ship))
                    return true;
            }

            foreach (Brander brander in _branders)
            {
                if (Maths.Collision(brander, _ship))
                    return true;
            }
            return false;
        }
    }
}
