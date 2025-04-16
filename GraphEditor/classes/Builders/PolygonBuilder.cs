using Lab1.classes.Managers;
using Lab1;
using System;
using System.Drawing;

namespace Lab1.classes.Builders
{
    public class PolygonBuilder : IFigureBuilder
    {
        private Polygon polygon;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
           
            if (polygon == null)
            {
                polygon = new Polygon(lineColor,backColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = polygon;
            }
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
           
            if (polygon != null)
            {
                polygon.DeleteLast();
                polygon.AddPoint(current);
            }
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            
            if (polygon != null)
            {
                polygon.DeleteLast();
                polygon.AddPoint(end);
                polygon.AddFirst();
            }
        }

        public bool GetSelf()
        {
            return polygon != null;  
        }

        public void Clear()
        {
            polygon = null;  
        }
    }
}
