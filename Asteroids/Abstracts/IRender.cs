using Asteroids.Structures;
using System;

namespace Asteroids.Abstracts
{
    public interface IRender
    {
        MainWindow Window { set; }

        Action GetRenderModule(ToRender elements);
    }
}
