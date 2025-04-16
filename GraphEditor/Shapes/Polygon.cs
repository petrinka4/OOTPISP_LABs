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
            var pointList = Points.ToList(); 
            pointList.Add(point);
            Points = pointList.ToArray();
        }
        
        public void DeleteLast()
        {
          
            if (Points.Length > 1)
            {
                var pointList = Points.ToList(); 
                pointList.RemoveAt(pointList.Count - 1);  
                Points = pointList.ToArray();  
            }
        }
        public void AddFirst()
        {
            if (Points.Length > 0)
            {
                var pointList = Points.ToList(); 
                pointList.Add(pointList[0]);    
                Points = pointList.ToArray();    
            }
        }


        public override void Draw(Graphics g)
        {
           
            if (Points.Length >= 3)
            {
                
                using (var brush = new SolidBrush(brushColor))
                using (var pen = new Pen(penColor, penWidth))
                {
                    
                    g.FillPolygon(brush, Points);
                    g.DrawPolygon(pen, Points);
                }
            }
        }
    }
}
