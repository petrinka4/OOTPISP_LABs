using System;
using System.Drawing;

namespace Lab1
{
    public abstract class CommonArray : Shape
    {
        
        public Point[] Points { get; set; }

        public CommonArray(Color penColor,Color brushColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.brushColor = brushColor;
            this.penWidth = penWidth;
            this.Points = points;
        }
    }
}
