using System;
using System.Drawing;
using System.Collections.Generic;
using Lab1.classes.Builders;
using Lab1.classes.Builders.Interfaces;
using System.Reflection;
using System.Diagnostics;

namespace Lab1.classes.Managers
{
    public class FigureBuilderManager
    {
        private readonly Dictionary<int, IFigureBuilder> builders;
        private IFigureBuilder currentBuilder;


        public FigureBuilderManager()
        {
            builders = new Dictionary<int, IFigureBuilder>();
            
        }
        public int GetDictSize()
        {
            return builders.Count();
        }
        public IFigureBuilder GetBuilder()
        {
            return currentBuilder;
        }
        public void RegisterBuilder(int index, IFigureBuilder builder)
        {
            builders[index] = builder;
        }

        public void SetFigure(int index)
        {
            currentBuilder = builders.TryGetValue(index, out var builder) ? builder : null;
        }

        public void LoadAllPlugins()
        {
            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginsPath))
            {
                Directory.CreateDirectory(pluginsPath); // Создаем папку, если её нет
                return;
            }

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
                            int newId = builders.Count;
                            builders[newId] = builder;
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Debug.WriteLine($"Ошибка загрузки {Path.GetFileName(dll)}: {ex.Message}");
                }
            }
        }


        public void HandleMouseDown(Point start, ref Shape[] shapes, Color lineColor, Color backColor, int penWidth)
        {
            currentBuilder?.OnMouseDown(start, ref shapes, lineColor, backColor, penWidth);
        }

        public void HandleMouseMove(Point current, ref Shape[] shapes)
        {
            currentBuilder?.OnMouseMove(current, ref shapes);
        }

        public void HandleMouseUp(Point end, ref Shape[] shapes)
        {
            currentBuilder?.OnMouseUp(end, ref shapes);
        }
    }
}
