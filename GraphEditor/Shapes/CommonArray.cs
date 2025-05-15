using System;
using System.Drawing;

namespace Lab1
{
    public abstract class CommonArray 
    {
        
        public Point[] points { get; set; }
        public Color penColor { get; set; }
        public Color brushColor { get; set; }
        public int penWidth { get; set; }
        public bool isCreated { get; set; }
        public CommonArray(Color penColor,Color brushColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.brushColor = brushColor;
            this.penWidth = penWidth;
            this.points = points;
        }
        public abstract void Draw(Graphics g);
    }
}
