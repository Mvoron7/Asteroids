using Asteroids.Structures;
using Asteroids.Weapons;
using System;
using System.Windows;

namespace Asteroids
{
    public partial class GameCore
    {
        private void Shoot(States state)
        {
            if (state.Right)
                ShootLaser(state.mousePosition);
            else if (state.Left)
                ShootBullet(state.mousePosition);
        }

        private void ShootLaser(Point mousePosition)
        {
            _laser.Enable(mousePosition);
        }

        private void ShootBullet(Point mousePosition)
        {
            double dX = mousePosition.X - GameCore.WIDTH_MIDDLE;
            double dY = mousePosition.Y - GameCore.HEIGHT_MIDDLE;
            double length = Math.Sqrt(dX * dX + dY * dY);

            dX /= length / 10;
            dY /= length / 10;
            AddElement(new Bulet(_ship.Position, dX, dY));
        }
    }
}
