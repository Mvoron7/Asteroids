using System.Collections.Generic;

namespace Asteroids.Abstracts
{
    /// <summary>Разрушаемые объекты</summary>
    public interface IDestructible
    {
        /// <summary>Отметка что объект получил повреждения</summary>
        bool isDestroyed { get; }

        /// <summary>Отметка о разрушении</summary>
        void MarkDestroed();

        /// <summary>Разрушение объекта</summary>
        /// <returns>Список новых объектов на месте старого</returns>
        IEnumerable<Element> Destroy();
    }
}
