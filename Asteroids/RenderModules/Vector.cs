using Asteroids.Abstracts;
using Asteroids.Structures;
using System;
using System.Text;

namespace Asteroids.RenderModules
{
    public class Vector : IRender
    {
        public MainWindow Window { get; set; }

        public Action GetRenderModule(ToRender elements)
        {
            return new Action(() =>
            {
                Window.Space.Children.Clear();

                StringBuilder stringBuilder = new StringBuilder();

                elements.Stones.ForEach(e => stringBuilder.Append(e.ToString()));

                elements.Bulets.ForEach(e => stringBuilder.Append(e.ToString()));

                elements.Branders.ForEach(e => stringBuilder.Append(e.ToString()));

                if (elements.Laser.Enabled)
                {
                    stringBuilder.Append(elements.Laser.ToString());
                }

                stringBuilder.Append(elements.Ship.ToString());

                Window.Vector.Text = stringBuilder.ToString();
                Window.Points.Text = $"Очки: {elements.Points}";
            });
        }
    }
}
