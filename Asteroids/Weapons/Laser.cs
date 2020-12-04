using System.Windows;

namespace Asteroids.Weapons
{
    /// <summary>Лазер корабля</summary>
    public class Laser : Weapon
    {
        public double Power { get; private set; }
        public readonly double MaxPower;

        public bool Enabled;

        public Laser(double maxPower)
        {
            Power = maxPower;
            MaxPower = maxPower;
        }

        public void Reload() {
            if (Power < MaxPower)
                Power++;
        }

        public void Enable(Point target)
        {
            if (Power >= 2)
            {
                Position = Maths.GetTargetPoint(new Point(400, 255), target, 1000);
                Power -= 2;
                Enabled = true;
            }
        }

        public void Disable() => Enabled = false;

        public override string ToString()
        {
            return $"Laser [400:225] [{this.Position.X:f4}:{this.Position.Y:f4}]\n";
        }

        public override bool NeedRemoved()
        {
            return false;
        }
    }
}
