using System.Windows;

namespace Asteroids.Abstracts
{
    /// <summary>Перемещающиеся объекты</summary>
    public interface IMovable
    {
        /// <summary>Перемещение по оси X за один фрейм</summary>
        double dX { get; }
        /// <summary>Перемещение по оси Y за один фрейм</summary>
        double dY { get; }

        /// <summary>Переместить объект</summary>
        void Move();

        /// <summary>Получает текущее положение объекта</summary>
        /// <returns>Текущее положение</returns>
        Point GetPosition();

        /// <summary>Поставить отметку о выходе из области отрисовки</summary>
        void MarkAsRunAway();

        /// <summary>Получить отметку о выходе из области отрисовки</summary>
        /// <returns>True - Объект покинул область отрисовки</returns>
        bool IsRunAway();
    }
}
