using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1.classes.Managers
{
    internal class SerializationUtils
    {
        public static void SaveShapes(string filePath, IEnumerable<CommonArray> shapes)
        {
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

            File.WriteAllText(filePath, arr.ToString(Formatting.Indented));
        }

        public static void LoadShapes(string filePath, ref CommonArray[] shapes, PictureBox pictureBox, FigureBuilderManager figureBuilderManager)
        {
            var arr = JArray.Parse(File.ReadAllText(filePath));
            shapes = Array.Empty<CommonArray>();

            foreach (JObject o in arr)
            {
                string typeName = (string)o["Type"];
                Color lineColor = Color.FromArgb((int)o["penColor"]);
                Color backColor = Color.FromArgb((int)o["brushColor"]);
                int pw = (int)o["penWidth"];
                var ptsToken = (JArray)o["Points"];

                if (!figureBuilderManager.builders.ContainsKey(typeName))
                {
                    MessageBox.Show($"Неизвестный тип фигуры: {typeName}", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                figureBuilderManager.SetFigure(typeName);
                var builder = figureBuilderManager.GetBuilder();
                try { builder.isCreated = false; } catch { }

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
    }
}
