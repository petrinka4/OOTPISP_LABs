using Lab1.classes.Managers;
using Lab1;
using System.Drawing;

namespace Lab1.classes.Builders
{
    public class RectangleBuilder : IFigureBuilder
    {
        private Point start;
        private Color lineColor, fillColor;
        private int penWidth;

        public void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            this.start = start;
            this.lineColor = lineColor;
            fillColor = backColor;
            this.penWidth = penWidth;
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new RectangleF(lineColor, backColor, penWidth, start, 0, 0);
        }

        public void OnMouseMove(Point current, ref Shape[] shapes)
        {
            Point topLeft = new Point(Math.Min(start.X, current.X), Math.Min(start.Y, current.Y));
            int width = Math.Abs(current.X - start.X);
            int height = Math.Abs(current.Y - start.Y);

            shapes[^1] = new RectangleF(lineColor, fillColor, penWidth, topLeft, width, height);
        }

        public void OnMouseUp(Point end, ref Shape[] shapes)
        {
            OnMouseMove(end, ref shapes);
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
