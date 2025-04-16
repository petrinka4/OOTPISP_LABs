using System;
using System.Drawing;
using System.Collections.Generic;
using Lab1.classes.Builders;

namespace Lab1.classes.Managers
{
    public class FigureBuilderManager
    {
        private readonly Dictionary<int, IFigureBuilder> builders;
        private IFigureBuilder currentBuilder;

        public FigureBuilderManager()
        {
            builders = new Dictionary<int, IFigureBuilder>
                {
                    { 0, new LineBuilder() },
                    { 1, new RectangleBuilder() },
                    { 2, new EllipseBuilder() },
                    { 3, new PolygonBuilder() },
                    { 4, new BrLineBuilder() }
                };
            //// Пример добавления нового элемента с индексом = текущий размер + 1
            //figureBuilders.Add(figureBuilders.Count, new NewPluginBuilder());
        
        }

        public int GetDictSize()
        {
            return builders.Count();
        }
        public IFigureBuilder GetBuilder()
        {
            return currentBuilder;
        }
        public void SetFigure(int index)
        {
            currentBuilder = builders.ContainsKey(index) ? builders[index] : null;
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
