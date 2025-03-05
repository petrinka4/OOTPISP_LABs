using System;
using System.Drawing;

namespace Lab1
{
    public class BrokenLine : CommonArray
    {
        public BrokenLine(Color penColor, int penWidth, Point[] points)
           : base(penColor, penWidth, points) { }

        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(penColor, penWidth))
            {
                g.DrawLines(pen, Points);
            }
        }
    }
}
