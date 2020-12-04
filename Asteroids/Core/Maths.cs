using Asteroids.Abstracts;
using System;
using System.Windows;

namespace Asteroids
{
    public static class Maths
    {
        /// <summary>
        /// Возвращает расстояние от точки до прямой
        /// </summary>
        /// <param name="point">Точка до которой раститывается дистанция</param>
        /// <param name="lineP1">Первая точка прямой</param>
        /// <param name="lineP2">Вторая точка прямой</param>
        /// <returns>Растояние от точки до прямой</returns>
        public static double Distance(Point point, Point lineP1, Point lineP2)
        {
            double dY = (lineP2.Y - lineP1.Y);
            double dX = (lineP2.X - lineP1.X);

            double p1 = Math.Abs(dY * point.X - dX * point.Y + lineP2.X * lineP1.Y - lineP2.Y * lineP1.X);
            double p2 = Math.Sqrt(dY * dY + dX * dX);
            return p1 / p2;
        }

        /// <summary>
        /// Маштабирует вектор до заданнго размера
        /// </summary>
        /// <param name="from">Точка начала вектора</param>
        /// <param name="midle">Точка конца вектора</param>
        /// <param name="targetLength">Целевая длина вектора</param>
        /// <returns>Конечнаяч точка вектора</returns>
        internal static Point GetTargetPoint(Point from, Point midle, int targetLength)
        {
            double dX = midle.X - from.X;
            double dY = midle.Y - from.Y;
            double length = Math.Sqrt(dX * dX + dY * dY);

            if (length == 0)
                return from;

            double prop = targetLength / length;

            double X = from.X + dX * prop;
            double Y = from.Y + dY * prop;

            return new Point(X, Y);
        }

        /// <summary>
        /// Возвращает вхождение елемента в отображаемое поле. Размеры поля считаем неизменными.
        /// </summary>
        /// <param name="element">Элемент для проверки</param>
        /// <returns>Наличие элемента в отображаемом поле</returns>
        public static bool inSpase(Element element)
        {
            bool inSpace = element.position.X >= 0;
            inSpace = inSpace && element.position.X <= 800;
            inSpace = inSpace && element.position.Y >= 0;
            inSpace = inSpace && element.position.Y <= 450;

            return inSpace;
        }
    }
}
