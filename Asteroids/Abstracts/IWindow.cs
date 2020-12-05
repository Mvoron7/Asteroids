using Asteroids.Structures;

namespace Asteroids.Abstracts
{
    /// <summary>Окно для отрисовки и обратной связи от игрока</summary>
    public interface IWindow
    {
        /// <summary>Отрисовка объектов</summary>
        /// <param name="elements">Набор объектов для отрисовки</param>
        void Render(ToRender elements);

        /// <summary>Получение состояния устройства ввода</summary>
        /// <returns>Нажатые кнопки</returns>
        States State();

        /// <summary>Конец раунда</summary>
        void SetGameOver();
    }
}
