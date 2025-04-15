using System;
using System.Drawing;
using System.Linq;

namespace Lab1
{
    public class Polygon : CommonArray
    {
        public Polygon(Color penColor, int penWidth, Point[] points)
           : base(penColor, penWidth, points) { }

        // Метод для добавления точки в массив
        public void AddPoint(Point point)
        {
            var pointList = Points.ToList();  // Преобразуем в список для добавления
            pointList.Add(point);
            Points = pointList.ToArray(); // Преобразуем обратно в массив
        }
        public void DeleteLast()
        {
            // Проверяем, что в массиве есть хотя бы одна точка
            if (Points.Length > 1)
            {
                var pointList = Points.ToList();  // Преобразуем в список
                pointList.RemoveAt(pointList.Count - 1);  // Удаляем последнюю точку
                Points = pointList.ToArray();  // Преобразуем обратно в массив
            }
        }
        public void AddFirst()
        {
            if (Points.Length > 0)
            {
                var pointList = Points.ToList(); // Преобразуем в список
                pointList.Add(pointList[0]);     // Добавляем первую точку в конец
                Points = pointList.ToArray();    // Преобразуем обратно в массив
            }
        }


        public override void Draw(Graphics g)
        {
            // Проверяем, что количество точек больше или равно 2
            if (Points.Length >= 3)
            {
                using (var pen = new Pen(penColor, penWidth))
                {
                    g.DrawPolygon(pen, Points); // Рисуем многоугольник
                }
            }
        }
    }
}
