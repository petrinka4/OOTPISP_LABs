using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab1.classes.Builders;
using Lab1.classes.Builders.Interfaces;
using Lab1.classes.Managers;
using Newtonsoft.Json.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace Lab1
{
    public partial class MainForm : Form
    {
        private UndoRendoManager undoRedoManager = new UndoRendoManager();
        private FigureBuilderManager figureBuilderManager = new FigureBuilderManager();
        private CommonArray[] shapes = new CommonArray[0];
        public bool IsDrawing = false;
        public Color colorLine = Color.White;
        public Color colorBack = Color.White;
        public int penWidth = 10;

        public MainForm()
        {
            InitializeComponent();
            InitializeBuilders();
        }

        private void InitializeBuilders()
        {
            figureBuilderManager.RegisterBuilder("Line", new LineBuilder());
            figureBuilderManager.RegisterBuilder("RectangleF", new RectangleBuilder());
            figureBuilderManager.RegisterBuilder("Ellipse", new EllipseBuilder());
            figureBuilderManager.RegisterBuilder("Polygon", new PolygonBuilder());
            figureBuilderManager.RegisterBuilder("BrokenLine", new BrLineBuilder());

            figureBuilderManager.LoadAllPlugins();
            LoadButtons(figureBuilderManager);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
                shape.Draw(e.Graphics);
        }
        private void LoadButtons(FigureBuilderManager figureBuilderManager)
        {

            comboBoxPlugins.Items.Clear();


            var pluginKeys = figureBuilderManager.builders.Keys.Skip(5);


            foreach (var key in pluginKeys)
            {
                comboBoxPlugins.Items.Add(key);
            }
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
            if (!IsDrawing) return;
            figureBuilderManager.HandleMouseMove(new Point(e.X, e.Y), ref shapes, IsDrawing);
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IsDrawing) return;
            IsDrawing = false;
            figureBuilderManager.HandleMouseUp(new Point(e.X, e.Y), ref shapes);
            pictureBox.Invalidate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            shapes = Array.Empty<CommonArray>();
            undoRedoManager.ClearShapes();
            pictureBox.Invalidate();
        }

        private void buttonLine_Click(object sender, EventArgs e) => figureBuilderManager.SetFigure("Line");
        private void buttonRectangle_Click(object sender, EventArgs e) => figureBuilderManager.SetFigure("RectangleF");
        private void buttonEllipse_Click(object sender, EventArgs e) => figureBuilderManager.SetFigure("Ellipse");
        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            figureBuilderManager.SetFigure("Polygon");
            figureBuilderManager.GetBuilder().isCreated = false;
        }

        private void buttonBrLine_Click(object sender, EventArgs e)
        {
            figureBuilderManager.SetFigure("BrokenLine");
            figureBuilderManager.GetBuilder().isCreated = false;
        }

        private void drawButton_Click(object sender, EventArgs e) => pictureBox.Invalidate();

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

        private void buttonColor_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog { Color = colorLine };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                colorLine = dlg.Color;
                buttonColorLine.BackColor = dlg.Color;
            }
        }

        private void buttonColorBack_Click(object sender, EventArgs e)
        {
            var dlg = new ColorDialog { Color = colorBack };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                colorBack = dlg.Color;
                buttonColorBack.BackColor = dlg.Color;
            }
        }

        private void trackBarWidth_Scroll(object sender, EventArgs e) => penWidth = trackBarWidth.Value;

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JSON-файлы (*.json)|*.json";
            saveFileDialog1.Title = "Сохранить фигуры";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            var arr = new JArray();
            foreach (var s in shapes)
            {
                var o = new JObject
                {
                    ["Type"] = s.GetType().Name,
                    ["penColor"] = s.penColor.ToArgb(),
                    ["brushColor"] = s.brushColor.ToArgb(),
                    ["penWidth"] = s.penWidth
                };

                var pts = new JArray();


                foreach (var pt in s.points)
                {
                    pts.Add(new JObject { ["X"] = pt.X, ["Y"] = pt.Y });
                }

                o["Points"] = pts;
                arr.Add(o);
            }
            File.WriteAllText(saveFileDialog1.FileName, arr.ToString(Formatting.Indented));
        }


        private void lOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JSON‑файлы (*.json)|*.json";
            openFileDialog1.Title = "Загрузить фигуры";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            var arr = JArray.Parse(File.ReadAllText(openFileDialog1.FileName));
            shapes = Array.Empty<CommonArray>();

            foreach (JObject o in arr)
            {
                string typeName = (string)o["Type"];
                Color lineColor = Color.FromArgb((int)o["penColor"]);
                Color backColor = Color.FromArgb((int)o["brushColor"]);
                int pw = (int)o["penWidth"];
                var ptsToken = (JArray)o["Points"];

                figureBuilderManager.SetFigure(typeName);
                var builder = figureBuilderManager.GetBuilder();
                try
                {
                    builder.isCreated = false;
                }
                catch { }

                var first = (JObject)ptsToken[0];
                var start = new Point((int)first["X"], (int)first["Y"]);
                figureBuilderManager.HandleMouseDown(start, ref shapes, lineColor, backColor, pw);

                for (int i = 1; i < ptsToken.Count; i++)
                {
                    var token = (JObject)ptsToken[i];
                    var pt = new Point((int)token["X"], (int)token["Y"]);
                    figureBuilderManager.HandleMouseMove(pt, ref shapes, false);
                }

                var last = (JObject)ptsToken.Last;
                var end = new Point((int)last["X"], (int)last["Y"]);
                figureBuilderManager.HandleMouseUp(end, ref shapes);
            }

            pictureBox.Invalidate();
        }

        

        private void comboBoxPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKey = comboBoxPlugins.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedKey))
            {
                figureBuilderManager.SetFigure(selectedKey);
            }
        }
    }
}
