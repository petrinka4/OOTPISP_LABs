﻿using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    enum FigureType
    {
        None,
        Line,
        Rectangle,
        Ellipse,
        Polygon,
        BrLine
    }


    public partial class MainForm : Form
    {
        public Color colorLine = Color.White;
        public Color colorBack = Color.White;
        public int penWidth = 10;
        private FigureType _curFigure;
        private FigureType CurFigure
        {
            get => _curFigure;
            set
            {
                if (_curFigure == FigureType.BrLine && value != FigureType.BrLine)
                {
                    pointsBrLine = new Point[0];
                }
                _curFigure = value;
            }
        }

        private Shape[] shapes = new Shape[0];
        int StartX, StartY, EndX, EndY;
        Shape CurShape = new Line(Color.Black, 5, new Point(20, 20), new Point(40, 100));
        Point[] pointsBrLine = new Point[0];
        List<Shape> stack = new List<Shape>();
        bool IsDrawing;
        bool IsDrawingBrLine = false;
        public MainForm()
        {
            InitializeComponent();
            CurFigure = FigureType.None;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            shapes = new Shape[0];
            CurFigure = FigureType.None;
            pictureBox.Invalidate();
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            CurFigure = FigureType.Line;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            CurFigure = FigureType.Rectangle;
        }

        private void buttonEllipse_Click(object sender, EventArgs e)
        {
            CurFigure = FigureType.Ellipse;
        }

        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            CurFigure = FigureType.Polygon;
        }

        private void buttonBrLine_Click(object sender, EventArgs e)
        {
            CurFigure = FigureType.BrLine;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            StartX = e.X;
            StartY = e.Y;
            if (CurFigure == FigureType.BrLine && pointsBrLine.Length == 0)
            {
                Point newPoint = new Point(StartX, StartY);
                Point[] newArray = new Point[pointsBrLine.Length + 1];
                Array.Copy(pointsBrLine, newArray, pointsBrLine.Length);
                newArray[newArray.Length - 1] = newPoint;
                pointsBrLine = newArray;
            }
            if (CurFigure != FigureType.None)
            {
                IsDrawing = true;
                Array.Resize(ref shapes, shapes.Length + 1);
            }
            if (CurFigure == FigureType.BrLine)
            {
                Point[] newArray = new Point[pointsBrLine.Length + 1];
                Array.Copy(pointsBrLine, newArray, pointsBrLine.Length);

                pointsBrLine = newArray;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrawing = false;
            int temp;
            EndX = e.X;
            EndY = e.Y;
            switch (CurFigure)
            {
                case FigureType.Line:
                    CurShape = new Line(colorLine, penWidth, new Point(StartX, StartY), new Point(EndX, EndY));

                    shapes[^1] = CurShape;
                    pictureBox.Invalidate();
                    break;

                case FigureType.Rectangle:
                    if (StartX > EndX)
                    {
                        temp = StartX;
                        StartX = EndX;
                        EndX = temp;
                    }
                    if (StartY > EndY)
                    {
                        temp = StartY;
                        StartY = EndY;
                        EndY = temp;
                    }

                    shapes[^1] = new RectangleF(colorLine, colorBack, penWidth, new Point(StartX, StartY), EndX - StartX, EndY - StartY);
                    pictureBox.Invalidate();
                    break;

                case FigureType.Ellipse:

                    shapes[^1] = new Ellipse(colorLine, colorBack, penWidth, new Point(StartX, StartY), EndX - StartX, EndY - StartY);
                    pictureBox.Invalidate();
                    break;

                case FigureType.Polygon:

                    Point[] pointsPolygon = new Point[]
                    {
                        new Point((EndX + StartX) / 2, StartY),
                        new Point(EndX, StartY + (EndY - StartY) * 4 / 10),
                        new Point(StartX + (EndX - StartX) * 8 / 10, EndY),
                        new Point(StartX + (EndX - StartX) * 2 / 10, EndY),
                        new Point(StartX, StartY + (EndY - StartY) * 4 / 10)
                    };
                    shapes[^1] = new Polygon(colorLine, colorBack, penWidth, pointsPolygon);
                    pictureBox.Invalidate();
                    break;

                case FigureType.BrLine:

                    Point newPoint = new Point(EndX, EndY);
                    pointsBrLine[^1] = newPoint;

                    shapes[^1] = new BrokenLine(colorLine, penWidth, pointsBrLine);
                    pictureBox.Invalidate();
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                int temp;
                EndX = e.X;
                EndY = e.Y;

                switch (CurFigure)
                {
                    case FigureType.Line:
                        CurShape = new Line(colorLine, penWidth, new Point(StartX, StartY), new Point(EndX, EndY));

                        shapes[^1] = CurShape;
                        pictureBox.Invalidate();
                        break;

                    case FigureType.Rectangle:
                        bool isRotateX = false;
                        bool isRotateY = false;
                        if (StartX > EndX)
                        {
                            temp = StartX;
                            StartX = EndX;
                            EndX = temp;
                            isRotateX = true;

                        }
                        if (StartY > EndY)
                        {
                            temp = StartY;
                            StartY = EndY;
                            EndY = temp;
                            isRotateY = true;
                        }

                        shapes[^1] = new RectangleF(colorLine, colorBack, penWidth, new Point(StartX, StartY), EndX - StartX, EndY - StartY);
                        pictureBox.Invalidate();
                        if (isRotateX)
                        {
                            temp = StartX;
                            StartX = EndX;
                            EndX = temp;
                            isRotateX = false;
                        }
                        if (isRotateY)
                        {
                            temp = StartY;
                            StartY = EndY;
                            EndY = temp;
                            isRotateY = false;
                        }
                        break;

                    case FigureType.Ellipse:

                        shapes[^1] = new Ellipse(colorLine, colorBack, penWidth, new Point(StartX, StartY), EndX - StartX, EndY - StartY);
                        pictureBox.Invalidate();
                        break;

                    case FigureType.Polygon:

                        Point[] pointsPolygon = new Point[]
                        {
                        new Point((EndX + StartX) / 2, StartY),
                        new Point(EndX, StartY + (EndY - StartY) * 4 / 10),
                        new Point(StartX + (EndX - StartX) * 8 / 10, EndY),
                        new Point(StartX + (EndX - StartX) * 2 / 10, EndY),
                        new Point(StartX, StartY + (EndY - StartY) * 4 / 10)
                        };
                        shapes[^1] = new Polygon(colorLine, colorBack, penWidth, pointsPolygon);
                        pictureBox.Invalidate();
                        break;

                    case FigureType.BrLine:

                        Point newPoint = new Point(EndX, EndY);
                        pointsBrLine[^1] = newPoint;

                        shapes[^1] = new BrokenLine(colorLine, penWidth, pointsBrLine);
                        pictureBox.Invalidate();
                        break;
                }
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = colorLine;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                colorLine = MyDialog.Color;
            buttonColorLine.BackColor = MyDialog.Color;
        }

        private void buttonColorBack_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = colorBack;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                colorBack = MyDialog.Color;
            buttonColorBack.BackColor = MyDialog.Color;
        }

        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            penWidth = trackBarWidth.Value;
        }

        private void buttonCtrlZ_Click(object sender, EventArgs e)
        {
            if (shapes.Length > 0)
            {
                stack.Insert(0, shapes[^1]);
                Array.Resize(ref shapes, shapes.Length - 1);
                pictureBox.Invalidate();
            }

        }

        private void buttonCtrlY_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                Shape lastDeleted = stack[0];
                stack.RemoveAt(0);
                Array.Resize(ref shapes, shapes.Length + 1);
                shapes[^1] = lastDeleted;
                pictureBox.Invalidate();
            }
        }
    }
}