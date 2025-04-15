using Lab1.classes;
using System;
using System.Drawing;

namespace Lab1.classes
{
    public class BrLineBuilder : IFigureBuilder
    {
        private BrokenLine brokenLine;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            // Проверяем, существует ли уже ломаная линия, если нет - создаем новую
            if (brokenLine == null)
            {
                brokenLine = new BrokenLine(lineColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = brokenLine;
            }
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
            // Добавляем точку к ломаной линии на каждом движении мыши
            if (brokenLine != null)
            {
               // brokenLine.AddPoint(current);
            }
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            // Завершаем рисование, добавляем точку окончания
            if (brokenLine != null)
            {
                brokenLine.AddPoint(end);
            }
        }
        public bool GetSelf()
        {
            if (brokenLine == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Clear()
        {
           brokenLine=null;
        }
    }
}
