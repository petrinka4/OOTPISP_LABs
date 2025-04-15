using System;
using System.Collections.Generic;

namespace Lab1.classes
{
    class UndoRendoManager
    {
        private List<Shape> stack = new List<Shape>();
        private Shape[] shapes = Array.Empty<Shape>();

        public Shape[] Shapes => shapes;
        public void ClearShapes()
        {
            stack.Clear();
            shapes = Array.Empty<Shape>();
        }
        public void SetShapes(Shape[] newShapes)
        {
            shapes = newShapes;
        }

        public void Undo()
        {
            if (shapes.Length > 0)
            {
                stack.Insert(0, shapes[^1]);
                Array.Resize(ref shapes, shapes.Length - 1);
            }
        }

        public void Redo()
        {
            if (stack.Count > 0)
            {
                Shape lastDeleted = stack[0];
                stack.RemoveAt(0);
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[^1] = lastDeleted;
            }
        }
    }
}
