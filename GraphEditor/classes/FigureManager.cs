using System;
using System.Drawing;
using System.Collections.Generic;
using Lab1.classes;

namespace Lab1.classes
{
    public class FigureBuilderManager
    {
        private readonly Dictionary<FigureType, IFigureBuilder> builders;
        private IFigureBuilder currentBuilder;

        public FigureBuilderManager()
        {
            builders = new Dictionary<FigureType, IFigureBuilder>
            {
                { FigureType.Line, new LineBuilder() },
                { FigureType.Rectangle, new RectangleBuilder() },
                { FigureType.Ellipse, new EllipseBuilder() },
                { FigureType.Polygon, new PolygonBuilder() },
                { FigureType.BrLine, new BrLineBuilder() }
            };
        }

        public void SetFigure(FigureType figureType)
        {
            currentBuilder = builders.ContainsKey(figureType) ? builders[figureType] : null;
        }

        public void HandleMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            currentBuilder?.OnMouseDown(start, ref shapes, lineColor, backColor, penWidth);
        }

        public void HandleMouseMove(Point current, ref Shape[] shapes)
        {
            currentBuilder?.OnMouseMove(current, ref shapes);
        }

        public void HandleMouseUp(Point end, ref Shape[] shapes)
        {
            currentBuilder?.OnMouseUp(end, ref shapes);
        }
    }
}
