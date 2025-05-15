using System;
using System.Drawing;

namespace Lab1
{
    public class BrokenLine : CommonArray
    {
        public BrokenLine(Color penColor,Color brushColor, int penWidth, Point[] points)
           : base(penColor,brushColor, penWidth, points) { }

       
        public void AddPoint(Point point)
        {
            var pointList = points.ToList(); 
            pointList.Add(point);
            points = pointList.ToArray(); 
        }

        public void DeleteLast()
        {
            var pointList = points.ToList();
            pointList.RemoveAt(pointList.Count() - 1);
            points = pointList.ToArray();
        }

        public override void Draw(Graphics g)
        {
          
            if (points.Length >= 2)
            {
                using (var pen = new Pen(penColor, penWidth))
                {
                    g.DrawLines(pen, points);
                }
            }
        }

    }
}
