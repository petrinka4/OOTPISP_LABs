using Lab1.classes.Managers;
using Lab1.classes.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection.PortableExecutable;
using Lab1.classes.Builders.Interfaces;

namespace Lab1
{
    public partial class MainForm : Form
    {
        private UndoRendoManager undoRedoManager = new UndoRendoManager();
        private FigureBuilderManager figureBuilderManager = new FigureBuilderManager();
        private Dictionary<int, IFigureBuilder> figureBuilders;

        public Color colorLine = Color.White;
        public Color colorBack = Color.White;
        public int penWidth = 10;

        private Shape[] shapes = new Shape[0];
        private bool IsDrawing = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeBuilders();
        }

        private void InitializeBuilders()
        {
           
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
            shapes = Array.Empty<Shape>();
            
            undoRedoManager.ClearShapes();
            pictureBox.Invalidate();
        }

        private void buttonLine_Click(object sender, EventArgs e) => figureBuilderManager.SetFigure(0);
        private void buttonRectangle_Click(object sender, EventArgs e) => figureBuilderManager.SetFigure(1);
        private void buttonEllipse_Click(object sender, EventArgs e) => figureBuilderManager.SetFigure(2);
        private void buttonPolygon_Click(object sender, EventArgs e) { figureBuilderManager.SetFigure(3);
            IFigureBuilder activeBuilder = figureBuilderManager.GetBuilder();
            activeBuilder.isCreated=false;
            
        }
        private void buttonBrLine_Click(object sender, EventArgs e) { figureBuilderManager.SetFigure(4);
            IFigureBuilder activeBuilder = figureBuilderManager.GetBuilder();
            activeBuilder.isCreated = false;
            
        }

        

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
                   
            IsDrawing = true;
            undoRedoManager.ClearShapes();
            figureBuilderManager.HandleMouseDown(new Point(e.X, e.Y), ref shapes, colorLine, colorBack, penWidth);
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                figureBuilderManager.HandleMouseMove(new Point(e.X, e.Y), ref shapes);
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDrawing)
            {
                IsDrawing = false;
                figureBuilderManager.HandleMouseUp(new Point(e.X, e.Y), ref shapes);
                pictureBox.Invalidate();
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog { AllowFullOpen = false, ShowHelp = true, Color = colorLine };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                colorLine = dlg.Color;
                buttonColorLine.BackColor = dlg.Color;
            }
        }

        private void buttonColorBack_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog { AllowFullOpen = false, ShowHelp = true, Color = colorBack };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                colorBack = dlg.Color;
                buttonColorBack.BackColor = dlg.Color;
            }
        }

        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            penWidth = trackBarWidth.Value;
        }

        private void buttonCtrlZ_Click(object sender, EventArgs e)
        {
            undoRedoManager.SetShapes(shapes);
            undoRedoManager.Undo();
            shapes = undoRedoManager.Shapes;
            pictureBox.Invalidate();
        }

        private void buttonCtrlY_Click(object sender, EventArgs e)
        {
            undoRedoManager.SetShapes(shapes);
            undoRedoManager.Redo();
            shapes = undoRedoManager.Shapes;
            pictureBox.Invalidate();
        }
    }
}
