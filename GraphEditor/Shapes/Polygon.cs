using System;
using System.Drawing;
using System.Linq;

namespace Lab1
{
    public class Polygon : CommonArray
    {
        public Polygon(Color penColor,Color brushColor, int penWidth, Point[] points)
           : base(penColor, brushColor, penWidth, points) { }

        
        public void AddPoint(Point point)
        {
            var pointList = points.ToList(); 
            pointList.Add(point);
            points = pointList.ToArray();
        }
        
        public void DeleteLast()
        {
          
            if (points.Length > 1)
            {
                var pointList = points.ToList(); 
                pointList.RemoveAt(pointList.Count - 1);  
                points = pointList.ToArray();  
            }
        }
        public void AddFirst()
        {
            if (points.Length > 0)
            {
                var pointList = points.ToList(); 
                pointList.Add(pointList[0]);    
                points = pointList.ToArray();    
            }
        }


        public override void Draw(Graphics g)
        {
           
            if (points.Length >= 3)
            {
                
                using (var brush = new SolidBrush(brushColor))
                using (var pen = new Pen(penColor, penWidth))
                {
                    
                    g.FillPolygon(brush, points);
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
