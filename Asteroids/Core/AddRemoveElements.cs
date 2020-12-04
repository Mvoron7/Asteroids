using Asteroids.Enemies;
using Asteroids.Weapons;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    public partial class GameCore
    {
        private void Remove()
        {
            var newStones = new List<Stone>();
            _stones.ForEach(s =>
            {
                if (s.isDestroyed)
                {
                    s.Destroy().ToList().ForEach(d => newStones.Add((Stone)d));
                }
            });

            _elements = _elements.Where(e => !e.isDestroyed).ToList();
            _stones = _stones.Where(e => !e.isDestroyed).ToList();
            _bulets = _bulets.Where(e => !e.isDestroyed).ToList();
            _branders = _branders.Where(e => !e.isDestroyed).ToList();

            newStones.ForEach(s => AddElement(s));
        }

        private void AddElement(Stone stone)
        {
            _elements.Add(stone);
            _stones.Add(stone);
        }

        private void AddElement(Bulet bulet)
        {
            _elements.Add(bulet);
            _bulets.Add(bulet);
        }

        private void AddElement(Brander brander)
        {
            _elements.Add(brander);
            _branders.Add(brander);
        }


        private void RemoveElement(Stone stone)
        {
            _elements.Remove(stone);
            _stones.Remove(stone);
        }

        private void RemoveElement(Bulet bulet)
        {
            _elements.Remove(bulet);
            _bulets.Remove(bulet);
        }

        private void RemoveElement(Brander brander)
        {
            _elements.Remove(brander);
            _branders.Remove(brander);
        }
    }
}
