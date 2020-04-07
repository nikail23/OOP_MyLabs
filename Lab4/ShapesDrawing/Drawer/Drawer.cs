using MyShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using Rectangle = MyShapes.Rectangle;

namespace ShapesDrawing
{
    class Drawer : IDrawer
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
            this.graphic = graphic;
            Thickness = DefaultThickness;
            ShapeTag = DefaultShapeTag;
            Color = DefaultColor;
            this.shapesDictionary = shapesDictionary;
        }
        public void DrawShapeList(IList<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(graphic);
            }
        }
        private void AddShapesToDictionary()
        {
            
            shapesDictionary.Add(CircleTag, new Circle(StartPoint, FinishPoint, Color, Thickness, "Circle"));
            shapesDictionary.Add(SquareTag, new Square(StartPoint, FinishPoint, Color, Thickness, "Square"));
            shapesDictionary.Add(RectangleTag, new Rectangle(StartPoint, FinishPoint, Color, Thickness, "Rectangle"));
            shapesDictionary.Add(TriangleTag, new Triangle(StartPoint, FinishPoint, Color, Thickness, "Triangle"));
            shapesDictionary.Add(EllipseTag, new Ellipse(StartPoint, FinishPoint, Color, Thickness, "Ellipse"));
            shapesDictionary.Add(LineTag, new Line(StartPoint, FinishPoint, Color, Thickness, "Line"));
        }
        public Shape CreateFigure()
        {
            AddShapesToDictionary();
            Shape shape = shapesDictionary[ShapeTag];
            shapesDictionary.Clear();
            return shape;
        }
    }
}
