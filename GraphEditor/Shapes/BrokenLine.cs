using System;
using System.Drawing;

namespace Lab1
{
    public class BrokenLine : CommonArray
    {
        public BrokenLine(Color penColor, int penWidth, Point[] points)
           : base(penColor, penWidth, points) { }

        // Метод для добавления точки в массив
        public void AddPoint(Point point)
        {
            var pointList = Points.ToList();  // Преобразуем в список для добавления
            pointList.Add(point);
            Points = pointList.ToArray(); // Преобразуем обратно в массив
        }

        public override void Draw(Graphics g)
        {
            // Проверяем, что количество точек больше или равно 2
            if (Points.Length >= 2)
            {
                using (var pen = new Pen(penColor, penWidth))
                {
                    g.DrawLines(pen, Points); // Рисуем ломаную линию
                }
            }
        }

    }
}
