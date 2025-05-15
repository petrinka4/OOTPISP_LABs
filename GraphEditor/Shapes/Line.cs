using System;
using System.Drawing;

namespace Lab1
{
    public class Line : CommonArray
    {
        

        public Line(Color penColor, Color brushColor, int penWidth, Point[] points)
           : base(penColor, brushColor, penWidth, points)
        {
            if (points == null || points.Length != 2)
                throw new ArgumentException("Line должен содержать ровно 2 точки");
        }

        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(penColor, penWidth))
            {
                g.DrawLine(pen, points[0], points[1]);
            }
        }
    }
}
