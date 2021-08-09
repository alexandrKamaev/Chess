using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Chess
    {
        /// <summary>
        /// Текущая точка
        /// </summary>
        public Point curPoint { get; set; }

        /// <summary>
        /// Список направлений
        /// </summary>
        List<Point> listDirection = new List<Point>() {
            new Point(-1,-1),
            new Point(-1,0),
            new Point(-1,1),
            new Point (0,-1),
        //new Point (0,0), а зачем :)
            new Point (0,1),
            new Point (1,-1),
            new Point (1,0),
            new Point (1,1) };

        public delegate void ColorSet(Point point, Color color);
        /// <summary>
        /// Выводит движение ферзя
        /// </summary>
        /// <param name="SetColor">Просто подсветить грид</param>
        /// <param name="color">Цвет для подсветки</param>
        public void WriteMovePoint(ColorSet SetColor, Color color)
        {
            // по всем направлениям верзя
            foreach (var point in listDirection)
            {
                Point movePoint = curPoint;
                // двигаем, пока мы находимся на доске
                while (movePoint.AddPoint(point).OnBoard())
                {
                    //подкрашиваем
                    SetColor(movePoint, color);
                    // выводим
                    Console.WriteLine(movePoint.GetValueChess());
                }
            }
        }

      
        /// <summary>
        /// Выводит расположение ферзей
        /// </summary>
        /// <param name="SetColor">Функция, подсвечивающая точку</param>
        /// <param name="color">Цвет для подсветки</param>
        /// <param name="figure">Текущая точка</param>
        /// <param name="iteration">Итерация</param>
        public void GetEightFigure(ColorSet SetColor, Color color, Point figure, int iteration)
        {
            // достаточно движения буквой Г с переходом на начало строки/столбца при превышении доски
            // также просто задаем цвет
            SetColor(new Point(figure.Y, figure.X), color);
            if (iteration==8)
                return;

            // сам в шоке, что оно работает
            Point newPoint = new Point(figure.X + 2 > 8 ? 1 + figure.X % 2 : figure.X +2, figure.Y+1 > 8 ? 1 : figure.Y + 1);
            //просто рекурсия, на 8 итерации выходим
            GetEightFigure(SetColor, color, newPoint, ++iteration);
        }

    }
}
