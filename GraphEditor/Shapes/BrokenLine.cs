using System;
using System.Drawing;

namespace Lab1
{
    public class BrokenLine : CommonArray
    {
        public BrokenLine(Color penColor, int penWidth, Point[] points)
           : base(penColor, penWidth, points) { }

       
        public void AddPoint(Point point)
        {
            var pointList = Points.ToList(); 
            pointList.Add(point);
            Points = pointList.ToArray(); 
        }

        public override void Draw(Graphics g)
        {
          
            if (Points.Length >= 2)
            {
                using (var pen = new Pen(penColor, penWidth))
                {
                    g.DrawLines(pen, Points);
                }
            }
        }

    }
}
