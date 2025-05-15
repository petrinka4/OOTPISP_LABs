using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using Lab1.classes.Builders.Interfaces;

namespace Lab1.classes.Managers
{
    public class FigureBuilderManager
    {
        public  Dictionary<string, IFigureBuilder> builders { get;  }
        private IFigureBuilder currentBuilder;

        public FigureBuilderManager()
        {
            builders = new Dictionary<string, IFigureBuilder>();
        }

        public int GetDictSize()
        {
            return builders.Count;
        }

        public IFigureBuilder GetBuilder()
        {
            return currentBuilder;
        }

        public void RegisterBuilder(string key, IFigureBuilder builder)
        {
            builders[key] = builder;
        }

        public void SetFigure(string key)
        {
            currentBuilder = builders.TryGetValue(key, out var builder) ? builder : null;
        }

        public void LoadAllPlugins()
        {
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginsPath))
            {
                Directory.CreateDirectory(pluginsPath);
                return;
            }

            
            int nextIndex = builders.Count + 1;

            foreach (var dll in Directory.GetFiles(pluginsPath, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var builderTypes = assembly.GetTypes()
                        .Where(t => typeof(IFigureBuilder).IsAssignableFrom(t) && !t.IsAbstract);

                    foreach (var type in builderTypes)
                    {
                        if (Activator.CreateInstance(type) is IFigureBuilder builder)
                        {
                            
                            string key = type.Name.Replace("Builder", "");

                           
                            if (!builders.ContainsKey(key))
                                builders[key] = builder;
                            else
                                Debug.WriteLine($"Билдер с ключом {key} уже зарегистрирован.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка загрузки {Path.GetFileName(dll)}: {ex.Message}");
                }
            }

        }
        

        public void HandleMouseDown(Point start, ref CommonArray[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            currentBuilder?.OnMouseDown(start, ref shapes, lineColor, backColor, penWidth);
        }

        public void HandleMouseMove(Point current, ref CommonArray[] shapes, bool isDrawing)
        {
            currentBuilder?.OnMouseMove(current, ref shapes,isDrawing);
        }

        public void HandleMouseUp(Point end, ref CommonArray[] shapes)
        {
            currentBuilder?.OnMouseUp(end, ref shapes);
        }
    }
}
