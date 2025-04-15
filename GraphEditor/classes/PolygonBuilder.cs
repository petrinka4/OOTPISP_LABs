using Lab1.classes;
using System;
using System.Drawing;

namespace Lab1.classes
{
    public class PolygonBuilder : IFigureBuilder
    {
        private Polygon polygon;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            // Проверяем, существует ли уже многоугольник, если нет - создаем новый
            if (polygon == null)
            {
                polygon = new Polygon(lineColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = polygon;
            }
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
            // Добавляем точку к многоугольнику на каждом движении мыши
            if (polygon != null)
            {
                //polygon.AddPoint(current);
            }
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            // Завершаем рисование, добавляем точку окончания
            if (polygon != null)
            {
                polygon.DeleteLast();
                polygon.AddPoint(end);
                polygon.AddFirst();
            }
        }

        public bool GetSelf()
        {
            return polygon != null;  // Проверяем, есть ли уже многоугольник
        }

        public void Clear()
        {
            polygon = null;  // Очищаем текущий многоугольник
        }
    }
}
