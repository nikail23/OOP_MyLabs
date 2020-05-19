using MyShapes;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace ShapesDrawing
{
    internal class Drawer : IDrawer
    {
        public const int CircleTag = 1;
        public const int SquareTag = 2;
        public const int RectangleTag = 3;
        public const int TriangleTag = 4;
        public const int EllipseTag = 5;
        public const int LineTag = 6;
        private const int DefaultThickness = 1;
        private const int DefaultShapeTag = 1;
        private static readonly Color DefaultColor = Color.Black;

        private Graphics graphic;
        private IDictionary<int, Shape> shapesDictionary;
        private List<Plugin> hierarchyPlugins;

        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public Color Color { get; set; }
        public int Thickness { get; set; }
        public int ShapeTag { get; set; }

        public Drawer(Graphics graphic, Dictionary<int, Shape> shapesDictionary)
        {
            Thickness = DefaultThickness;
            ShapeTag = DefaultShapeTag;
            Color = DefaultColor;
            this.graphic = graphic;
            this.shapesDictionary = shapesDictionary;
            hierarchyPlugins = new List<Plugin>();
        }
        public void DrawShapeList(IList<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape != null)
                {
                    shape.Draw(graphic);
                }
            }
        }
        private void AddShapesToDictionary()
        {
            shapesDictionary.Clear();
            var dictionaryFabrike = new ShapeDictionaryFabrike();
            shapesDictionary = dictionaryFabrike.GetShapesDictionary(StartPoint, FinishPoint, Color, Thickness);

            if (hierarchyPlugins != null)
            {
                var shapesDictionaryIndex = LineTag + 1;

                foreach (var plugin in hierarchyPlugins)
                    foreach (var type in plugin.TypesList)
                    {
                        var shape = (Shape)plugin.Assembly.CreateInstance(type.FullName, false, BindingFlags.CreateInstance, null, new object[] { StartPoint, FinishPoint, Color, Thickness, type.Name }, null, null);
                        shapesDictionary.Add(shapesDictionaryIndex, shape);
                        shapesDictionaryIndex++;
                    }
            }
        }
        public Shape CreateFigure()
        {
            AddShapesToDictionary();
            Shape shape = null;
            if (shapesDictionary.Count != 0)
            {
                shape = shapesDictionary[ShapeTag];
            }
            return shape;
        }

        public void InitializeHierarchyPlugin(Plugin plugin)
        {
            if (plugin != null)
                hierarchyPlugins.Add(plugin);
        }
    }
}
