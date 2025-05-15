using Lab1;
using System.Drawing;
using Lab1.classes.Builders.Interfaces;

namespace Lab1.classes.Builders
{
    public class LineBuilder : IFigureBuilder
    {
        public bool isCreated { get; set; } = false;
        private Point start;
        private Color color;
        private int width;

        public void OnMouseDown(Point start, ref CommonArray[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            this.start = start;
            color = lineColor;
            width = penWidth;
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[^1] = new Line(color, Color.Empty, width, new Point[] { start, start });
        }

        public void OnMouseMove(Point current, ref CommonArray[] shapes, bool isDrawing)
        {
            shapes[^1] = new Line(color, Color.Empty, width, new Point[] { start, current });
        }

        public void OnMouseUp(Point end, ref CommonArray[] shapes)
        {
            shapes[^1] = new Line(color, Color.Empty, width, new Point[] { start, end });
        }
    }
}
