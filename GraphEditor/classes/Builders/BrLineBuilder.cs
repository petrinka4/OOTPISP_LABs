using Lab1;
using System;
using System.Drawing;
using Lab1.classes.Builders.Interfaces;

namespace Lab1.classes.Builders
{
    public class BrLineBuilder : IFigureBuilder
    {
        public bool isCreated { get; set; } = false;
        private BrokenLine brokenLine;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            if (!isCreated)
            {
                isCreated = true;
                brokenLine = new BrokenLine(lineColor,backColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = brokenLine;
            }
            
        }

        public void OnMouseMove(Point current, ref Shape[] shapes, bool isDrawing)
        {
       
            if (brokenLine != null)
            {
                if (isDrawing)
                {
                    brokenLine.DeleteLast();
                }
                brokenLine.AddPoint(current);
            }
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            
            if (brokenLine != null)
            {
                brokenLine.AddPoint(end);
                brokenLine.AddPoint(end);
            }
        }
       
        
        
        
    }
}
