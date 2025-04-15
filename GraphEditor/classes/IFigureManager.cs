using System.Drawing;

namespace Lab1.classes
{
    public interface IFigureBuilder
    {
        void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth);
        void OnMouseMove(Point current, ref Shape[] shapes);
        void OnMouseUp(Point end, ref Shape[] shapes);
        bool GetSelf();
        void Clear();
    }
}
