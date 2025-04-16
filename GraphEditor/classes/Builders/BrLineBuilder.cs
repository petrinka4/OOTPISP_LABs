using Lab1.classes.Managers;
using Lab1;
using System;
using System.Drawing;

namespace Lab1.classes.Builders
{
    public class BrLineBuilder : IFigureBuilder
    {
        private BrokenLine brokenLine;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            if (brokenLine == null)
            {
                brokenLine = new BrokenLine(lineColor,backColor, penWidth, new Point[] { start });
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[shapes.Length - 1] = brokenLine;
            }
            
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
       
            if (brokenLine != null)
            {
                brokenLine.DeleteLast();
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
       
        public bool GetSelf()
        {
            
                return brokenLine!=null;
            
        }
        //GC создан не для того что бы на него смотрели и любовались)
        public void Clear()
        {
           brokenLine=null;
        }
    }
}
