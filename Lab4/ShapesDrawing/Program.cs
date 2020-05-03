using MyShapes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapesDrawing
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(
                new ShapeDrawingForm(
                    new Service(
                        new ShapeXmlSerializer(),
                        new List<Shape>(),
                        new List<Shape>()
                    ),
                    new PluginsManager(
                        new List<Plugin>(),
                        new PluginScanner()
                    )
                )
            );
        }
    }
}
