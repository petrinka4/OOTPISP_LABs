using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class CommonArray : Shape
    {
        public Point[] Points { get; set; }

        public CommonArray(Color penColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.Points = points;
        }
    }
}
