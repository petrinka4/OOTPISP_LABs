using System;
using System.Drawing;

namespace Lab1
{
    public abstract class CommonArray : Shape
    {
        protected Color penColor;
        protected int penWidth;
        public Point[] Points { get; set; }

        public CommonArray(Color penColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.Points = points;
        }
    }
}
