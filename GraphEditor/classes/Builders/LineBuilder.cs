using Lab1.classes.Managers;
using Lab1;
using System.Drawing;

namespace Lab1.classes.Builders
{
    public class LineBuilder : IFigureBuilder
    {
        private Point start;
        private Color color;
        private int width;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            this.start = start;
            color = lineColor;
            width = penWidth;
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Line(color, width, start, start);
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
            shapes[^1] = new Line(color, width, start, current);
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            shapes[^1] = new Line(color, width, start, end);
        }
        public bool GetSelf()
        {
            return false;
        }
        public void Clear()
        {

        }
    }
}
