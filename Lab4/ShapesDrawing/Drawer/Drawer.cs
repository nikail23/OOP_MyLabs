using MyShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using Rectangle = MyShapes.Rectangle;

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
        private int thickness;
        private Color color;
        private int shapeTag;
        private List<Plugin> plugins; 

        private Point finishPoint;
        public Point StartPoint { get; set; }
        public Point FinishPoint
        {
            get
            {
                return finishPoint;
            }
            set
            {
                if (value != StartPoint)
                    finishPoint = value;
            }
        }
        public int Thickness
        {
            get
            {
                return thickness;
            }
            set
            {
                if (value > 0)
                    thickness = value;
            }
        }
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != null)
                    color = value;
            }
        }
        public int ShapeTag
        {
            get
            {
                return shapeTag;
            }
            set
            {
                if (value > 0)
                    shapeTag = value;
            }
        }

        public Drawer(Graphics graphic, Dictionary<int, Shape> shapesDictionary)
        {
            Thickness = DefaultThickness;
            ShapeTag = DefaultShapeTag;
            Color = DefaultColor;
            this.graphic = graphic;
            this.shapesDictionary = shapesDictionary;          
            plugins = new List<Plugin>();
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
        public void AddShapesToDictionary()
        {
            shapesDictionary.Clear();
            shapesDictionary.Add(CircleTag, new Circle(StartPoint, FinishPoint, Color, Thickness, "Circle"));
            shapesDictionary.Add(SquareTag, new Square(StartPoint, FinishPoint, Color, Thickness, "Square"));
            shapesDictionary.Add(RectangleTag, new Rectangle(StartPoint, FinishPoint, Color, Thickness, "Rectangle"));
            shapesDictionary.Add(TriangleTag, new Triangle(StartPoint, FinishPoint, Color, Thickness, "Triangle"));
            shapesDictionary.Add(EllipseTag, new Ellipse(StartPoint, FinishPoint, Color, Thickness, "Ellipse"));
            shapesDictionary.Add(LineTag, new Line(StartPoint, FinishPoint, Color, Thickness, "Line"));

            if (plugins != null)
            {
                var shapesDictionaryIndex = LineTag + 1;

                foreach (var plugin in plugins)
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

        public void InitializeShapePlugin(Plugin plugin)
        {
            if (plugin != null)
                plugins.Add(plugin);
        }
    }
}
