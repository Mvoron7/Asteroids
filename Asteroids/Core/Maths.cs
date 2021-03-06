﻿using Asteroids.Abstracts;
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

        /// <summary>Проверяет переход границы поля</summary>
        /// <param name="position">Текущее положение объекта</param>
        /// <returns>Положение объекта</returns>
        internal static Point CheckMirror(Point position)
        {
            double X = position.X;
            if (X < 0) X = GameCore.WIDTH;
            else if (X > GameCore.WIDTH) X = 0;

            double Y = position.Y;
            if (Y < 0) Y = GameCore.HEIGHT;
            else if (Y > GameCore.HEIGHT) Y = 0;

            return new Point(X, Y);
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
        /// Возвращает вхождение элемента в отображаемое поле
        /// </summary>
        /// <param name="element">Элемент для проверки</param>
        /// <returns>True - элемент виден на поле</returns>
        public static bool IsInSpace(IMovable element)
        {
            Point point = element.GetPosition();
            bool inSpace = point.X >= 0;
            inSpace = inSpace && point.X <= GameCore.WIDTH;
            inSpace = inSpace && point.Y >= 0;
            inSpace = inSpace && point.Y <= GameCore.HEIGHT;

            return inSpace;
        }

        /// <summary>Расчет столкновений объектов</summary>
        /// <param name="first">Первый объект</param>
        /// <param name="second">Второй объект</param>
        /// <returns>Наличие коллизии</returns>
        public static bool Collision<T1,T2>(T1 first, T2 second)
        where T1: Element, IDestructible
        where T2: Element, IDestructible
        {
            double dX = first.Position.X - second.Position.X;
            double dY = first.Position.Y - second.Position.Y;
            double distance = Math.Sqrt(dX * dX + dY * dY);

            return distance < (second.Size + first.Size);
        }
    }
}
