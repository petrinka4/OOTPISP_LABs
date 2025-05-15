using System;
using System.Drawing;

namespace Lab1
{
    public class Ellipse : CommonArray
    {
        public Ellipse(Color penColor, Color brushColor, int penWidth, Point[] points)
            : base(penColor, brushColor, penWidth, points) { }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                
                int x = Math.Min(points[0].X, points[1].X);
                int y = Math.Min(points[0].Y, points[1].Y);

                
                int width = Math.Abs(points[1].X - points[0].X);
                int height = Math.Abs(points[1].Y - points[0].Y);

                Rectangle rect = new Rectangle(x, y, width, height);

                
                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
