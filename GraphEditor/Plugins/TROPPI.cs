
using System.Collections.Generic;
using System;
using System.Drawing;
using Lab1;


public class TROPPI : CommonArray
    {
        public TROPPI(Color penColor, Color brushColor, int penWidth, Point[] points)
           : base(penColor, brushColor, penWidth, points) { }

    

    Point[] GetTrapezoid(Point start, Point end)
    {
        int offsetX = (end.X - start.X) / 4;
        return new Point[]
        {
                new Point(start.X, end.Y),    // Нижний левый
        new Point(start.X + offsetX, start.Y),           // Верхний левый
        new Point(end.X - offsetX, start.Y),             // Верхний правый
        new Point(end.X, end.Y)                    // Нижний правый

        };
    }



    public override void Draw(Graphics g)
        {
        var resultPoints = GetTrapezoid(points[0], points[^1]);

        using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {

                g.FillPolygon(brush, resultPoints);
                g.DrawPolygon(pen, resultPoints);
            }

        }
    }

