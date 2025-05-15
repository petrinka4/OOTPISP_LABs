using Lab1;
using System.Drawing;
using Lab1.classes.Builders.Interfaces;

namespace Lab1.classes.Builders
{
    public class EllipseBuilder : IFigureBuilder
    {
        public bool isCreated { get; set; } = false;
        private Point start;
        private Color lineColor, fillColor;
        private int penWidth;

        public void OnMouseDown(Point start, ref CommonArray[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            this.start = start;
            this.lineColor = lineColor;
            fillColor = backColor;
            this.penWidth = penWidth;
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Ellipse(lineColor, backColor, penWidth, new Point[] { start, start });
        }

        public void OnMouseMove(Point current, ref CommonArray[] shapes, bool isDrawing)
        {
            Point[] points = new Point[]
            {
                start,
                current
            };

            shapes[^1] = new Ellipse(lineColor, fillColor, penWidth, points);
        }

        public void OnMouseUp(Point end, ref CommonArray[] shapes)
        {
            OnMouseMove(end, ref shapes, false);
        }
    }
}
