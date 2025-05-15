using Lab1;
using System.Drawing;
using System.Drawing.Printing;

namespace Lab1.classes.Builders.Interfaces
{
    public interface IFigureBuilder
    {
        bool isCreated { get; set; }
        void OnMouseDown(Point start, ref CommonArray[] shapes, Color lineColor, Color backColor, int penWidth);
        void OnMouseMove(Point current, ref CommonArray[] shapes, bool isDrawing);
        void OnMouseUp(Point end, ref CommonArray[] shapes);
        
    }
    
}
