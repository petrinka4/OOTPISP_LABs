using System;
using System.Drawing;

namespace Lab1
{
    public abstract class Shape
    {
        public Color penColor { get; set; }
        public Color brushColor { get; set; }
        public int penWidth { get; set; }
        public Point position { get; set; }
        public abstract void Draw(Graphics g);
    }
}
