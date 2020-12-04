using System;
using System.Windows;

namespace Asteroids.Abstracts
{
    /// <summary>Базовый класс для всех отображаемых элементов</summary>
    public abstract class Element
    {
        /// <summary>Положение на карте</summary>
        public Point Position { get; set; }

        /// <summary>Размер</summary>
        public double Size { get; set; }

        /// <summary>Отметка об необходимости удалении объекта</summary>
        /// <returns>True - объект требует удаления</returns>
        public abstract bool NeedRemoved();
    }
}
