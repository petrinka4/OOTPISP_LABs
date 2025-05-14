using Lab1;
using System;
using System.Drawing;
using Lab1.classes.Builders.Interfaces;

namespace Lab1.classes.Builders
{
    public class PolygonBuilder : IFigureBuilder
    {
        public bool isCreated { get; set; } = false;
        
        private Polygon polygon;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
           
            if (!isCreated)
            {
                isCreated = true;
                polygon = new Polygon(lineColor,backColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = polygon;
            }
        }

        public void OnMouseMove(Point current, ref Shape[] shapes, bool isDrawing)
        {
           
            if (polygon != null)
            {
                if (isDrawing)
                {
                    polygon.DeleteLast();
                }
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

        
    }
}
