using Lab1;
using System.Drawing;
using System.Drawing.Printing;

namespace Lab1.classes.Managers
{
    public interface IFigureBuilder
    {
        bool isCreated { get; set; }
        void OnMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth);
        void OnMouseMove(Point current, ref Shape[] shapes);
        void OnMouseUp(Point end, ref Shape[] shapes);
        
    }
    
}
