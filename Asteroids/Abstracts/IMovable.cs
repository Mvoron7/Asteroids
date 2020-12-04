namespace Asteroids.Abstracts
{
    /// <summary>Перемещающиеся объекты</summary>
    public interface IMovable
    {
        /// <summary>Перемещение по оси X за один фрейм</summary>
        double dX { set; }
        /// <summary>Перемещение по оси Y за один фрейм</summary>
        double dY { set; }

        /// <summary>Переместить объект</summary>
        void Move();
    }
}
