using Lab1.classes.Managers;
using Lab1.classes.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    public partial class MainForm : Form
    {
        private UndoRendoManager undoRedoManager = new UndoRendoManager();
        private Dictionary<FigureType, IFigureBuilder> figureBuilders;
        private IFigureBuilder activeBuilder;

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
            figureBuilders = new Dictionary<FigureType, IFigureBuilder>
            {
                { FigureType.Line, new LineBuilder() },
                { FigureType.Rectangle, new RectangleBuilder() },
                { FigureType.Ellipse, new EllipseBuilder() },
                { FigureType.Polygon, new PolygonBuilder() },
                { FigureType.BrLine, new BrLineBuilder() }
            };
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
            activeBuilder = null;
            undoRedoManager.ClearShapes();
            pictureBox.Invalidate();
        }

        private void buttonLine_Click(object sender, EventArgs e) => SetActiveBuilder(FigureType.Line);
        private void buttonRectangle_Click(object sender, EventArgs e) => SetActiveBuilder(FigureType.Rectangle);
        private void buttonEllipse_Click(object sender, EventArgs e) => SetActiveBuilder(FigureType.Ellipse);
        private void buttonPolygon_Click(object sender, EventArgs e) { SetActiveBuilder(FigureType.Polygon);
            if (activeBuilder.GetSelf() == true)
            {
                
                activeBuilder.Clear();
            }
        }
        private void buttonBrLine_Click(object sender, EventArgs e) { SetActiveBuilder(FigureType.BrLine);
            if (activeBuilder.GetSelf() == true)
            {
                
                activeBuilder.Clear();
            }
        }

        private void SetActiveBuilder(FigureType figure)
        {
            activeBuilder = figureBuilders.ContainsKey(figure) ? figureBuilders[figure] : null;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeBuilder == null) return;
            
            IsDrawing = true;
            undoRedoManager.ClearShapes();
            activeBuilder.OnMouseDown(new Point(e.X, e.Y), ref shapes, colorLine, colorBack, penWidth);
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawing && activeBuilder != null)
            {
                activeBuilder.OnMouseMove(new Point(e.X, e.Y), ref shapes);
                pictureBox.Invalidate();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDrawing && activeBuilder != null)
            {
                IsDrawing = false;
                activeBuilder.OnMouseUp(new Point(e.X, e.Y), ref shapes);
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
