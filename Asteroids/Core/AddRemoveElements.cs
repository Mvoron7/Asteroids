﻿using Asteroids.Enemies;
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

            _stones = _stones.Where(e => !e.isDestroyed).ToList();
            _bulets = _bulets.Where(e => !e.isDestroyed).ToList();
            _branders = _branders.Where(e => !e.isDestroyed).ToList();

            newStones.ForEach(s => AddElement(s));
        }

        private void AddElement(Stone stone)
        {
            _stones.Add(stone);
            _movables.Add(stone);
            _destructibles.Add(stone);
        }

        private void AddElement(Bulet bulet)
        {
            _bulets.Add(bulet);
            _movables.Add(bulet);
            _destructibles.Add(bulet);
        }

        private void AddElement(Brander brander)
        {
            _branders.Add(brander);
            _movables.Add(brander);
            _destructibles.Add(brander);
        }

        private void RemoveElement(Stone stone)
        {
            _stones.Remove(stone);
            _movables.Remove(stone);
            _destructibles.Remove(stone);
        }

        private void RemoveElement(Bulet bulet)
        {
            _bulets.Remove(bulet);
            _movables.Remove(bulet);
            _destructibles.Remove(bulet);
        }

        private void RemoveElement(Brander brander)
        {
            _branders.Remove(brander);
            _movables.Remove(brander);
            _destructibles.Remove(brander);
        }
    }
}
