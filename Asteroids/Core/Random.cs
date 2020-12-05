using Asteroids.Enemies;
using Asteroids.Enums;
using System;
using System.Windows;

namespace Asteroids
{
    public partial class GameCore
    {
        private readonly Random _random;

        private void SpawnEnemies()
        {
            while (_random.NextDouble() > 0.7)
                SpawnAsteroids();

            if (_random.NextDouble() > 0.95)
                SpawnBrander();
        }

        private void SpawnAsteroids()
        {
            SpaceSide site = (SpaceSide)_random.Next(1, 5);
            double position = _random.NextDouble();
            double corner = Math.PI * _random.NextDouble();

            double dX, dY;
            switch (site)
            {
                case SpaceSide.Top:
                    position *= GameCore.WIDTH;
                    dX = Math.Cos(corner);
                    dY = Math.Sin(corner);

                    AddElement(new BigStone(new Point(position, 0), dX, dY));
                    break;

                case SpaceSide.Left:
                    position *= GameCore.HEIGHT;
                    dX = Math.Sin(corner);
                    dY = Math.Cos(corner);

                    AddElement(new BigStone(new Point(0, position), dX, dY));
                    break;

                case SpaceSide.Bottom:
                    position *= GameCore.WIDTH;
                    dX = Math.Cos(corner);
                    dY = -Math.Sin(corner);

                    AddElement(new BigStone(new Point(position, GameCore.HEIGHT), dX, dY));
                    break;

                case SpaceSide.Right:
                    position *= GameCore.HEIGHT;
                    dX = -Math.Sin(corner);
                    dY = Math.Cos(corner);

                    AddElement(new BigStone(new Point(GameCore.WIDTH, position), dX, dY));
                    break;
            }
        }

        private void SpawnBrander()
        {
            SpaceSide site = (SpaceSide)_random.Next(1, 5);
            double position = _random.NextDouble();

            int speed =_random.Next(1, 10);
            switch (site)
            {
                case SpaceSide.Top:
                    position *= GameCore.WIDTH;

                    AddElement(new Brander(new Point(position, 0), speed));
                    break;

                case SpaceSide.Left:
                    position *= GameCore.HEIGHT;

                    AddElement(new Brander(new Point(0, position), speed));
                    break;

                case SpaceSide.Bottom:
                    position *= GameCore.WIDTH;

                    AddElement(new Brander(new Point(position, GameCore.HEIGHT), speed));
                    break;

                case SpaceSide.Right:
                    position *= GameCore.HEIGHT;

                    AddElement(new Brander(new Point(GameCore.WIDTH, position), speed));
                    break;
            }
        }
    }
}
