using Asteroids.Structures;

namespace Asteroids.Abstracts
{
    public interface IWindow
    {
        /// <summary>Отрисовка объектов</summary>
        /// <param name="elements">Набор объектов тля отрисовки</param>
        void Render(ToRender elements);

        /// <summary>Получение </summary>
        /// <returns></returns>
        States State();
    }
}
