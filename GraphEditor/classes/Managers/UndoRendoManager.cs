using Lab1;
using System;
using System.Collections.Generic;

namespace Lab1.classes.Managers
{
    class UndoRendoManager
    {
        private List<CommonArray> stack = new List<CommonArray>();
        private CommonArray[] shapes = Array.Empty<CommonArray>(); 

        public CommonArray[] Shapes => shapes;
        public void ClearShapes()
        {
            stack.Clear();
            shapes = Array.Empty<CommonArray>();
        }
        public void SetShapes(CommonArray[] newShapes)
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
                CommonArray lastDeleted = stack[0];
                stack.RemoveAt(0);
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[^1] = lastDeleted;
            }
        }
    }
}
