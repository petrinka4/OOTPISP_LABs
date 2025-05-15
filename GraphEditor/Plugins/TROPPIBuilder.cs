using Lab1;
using System;
using System.Drawing;
using Lab1.classes.Builders.Interfaces;
using System.Collections.Generic;



    public class TROPPIBuilder : IFigureBuilder
    {
   
        public bool isCreated { get; set; } = false;

        private TROPPI troppi;
        private Point start;
        private Color lineColor, fillColor;
        private int penWidth;

        public void OnMouseDown(Point start, ref CommonArray[] shapes, Color lineColor, Color backColor, int penWidth)
        {


        this.start = start;
            this.lineColor = lineColor;
            fillColor = backColor;
            this.penWidth = penWidth;
            isCreated = true;
            

            troppi = new TROPPI(lineColor, backColor, penWidth, new Point[] { start, start });
            Array.Resize(ref shapes, shapes.Length + 1);
            shapes[shapes.Length - 1] = troppi;

        }

        public void OnMouseMove(Point current, ref CommonArray[] shapes, bool isDrawing)
        {
       
        
            shapes[^1] = new TROPPI(lineColor, fillColor, penWidth, new Point[] { start, current });
        }

    public void OnMouseUp(Point end, ref CommonArray[] shapes)
    {
        

        shapes[^1] = new TROPPI(lineColor, fillColor, penWidth, new Point[] { start, end });
    }




}