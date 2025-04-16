using Lab1.classes;
using System;
using System.Drawing;

namespace Lab1.classes
{
    public class BrLineBuilder : IFigureBuilder
    {
        private BrokenLine brokenLine;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            if (brokenLine == null)
            {
                brokenLine = new BrokenLine(lineColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = brokenLine;
            }
            
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
       
            if (brokenLine != null)
            {
               // brokenLine.AddPoint(current);
            }
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            
            if (brokenLine != null)
            {
                brokenLine.AddPoint(end);
            }
        }
        public bool GetSelf()
        {
            if (brokenLine == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Clear()
        {
           brokenLine=null;
        }
    }
}
