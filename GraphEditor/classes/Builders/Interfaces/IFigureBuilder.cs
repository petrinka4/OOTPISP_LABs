using Lab1;
using System.Drawing;
using System.Drawing.Printing;

namespace Lab1.classes.Builders.Interfaces
{
    public interface IFigureBuilder
    {
        bool isCreated { get; set; }
        void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth);
        void OnMouseMove(Point current, ref Shape[] shapes, bool isDrawing);
        void OnMouseUp(Point end, ref Shape[] shapes);
        
    }
    
}
