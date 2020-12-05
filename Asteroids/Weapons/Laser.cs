using System.Windows;

namespace Asteroids.Weapons
{
    /// <summary>Лазер корабля</summary>
    public class Laser : Weapon
    {
        public double Power { get; private set; }
        public readonly double MaxPower;

        public bool Enabled;

        public Point FromPoint { get; set; }

        public bool Reloaded { get; private set; }

        public Laser(double maxPower)
        {
            Power = maxPower;
            MaxPower = maxPower;
            Reloaded = false;
        }

        public void Reload() {
            if (Power < MaxPower)
            {
                Power++;
            }
            else
            {
                Reloaded = true;
            }
        }

        public void Enable(Point target)
        {
            if (!Reloaded)
                return;

            if ( Power >= 2)
            {
                Position = Maths.GetTargetPoint(FromPoint, target, 1000);
                Power -= 2;
                Enabled = true;
            } else {
                Reloaded = false;
            }
        }

        public void Disable()
        {
            Enabled = false;
        }

        public override string ToString()
        {
            return $"Laser [{FromPoint.X:f4}:{FromPoint.Y:f4}] [{Position.X:f4}:{Position.Y:f4}]\n";
        }

        public override bool NeedRemoved()
        {
            return false;
        }
    }
}
