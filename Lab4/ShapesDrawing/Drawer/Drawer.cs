using MyShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using Rectangle = MyShapes.Rectangle;

namespace ShapesDrawing
{
    class Drawer : IDrawer
    {
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
            shapesDictionary.Add(1, new Circle(StartPoint, FinishPoint, Color, Thickness, "Circle"));
            shapesDictionary.Add(2, new Square(StartPoint, FinishPoint, Color, Thickness, "Square"));
            shapesDictionary.Add(3, new Rectangle(StartPoint, FinishPoint, Color, Thickness, "Rectangle"));
            shapesDictionary.Add(4, new Triangle(StartPoint, FinishPoint, Color, Thickness, "Triangle"));
            shapesDictionary.Add(5, new Ellipse(StartPoint, FinishPoint, Color, Thickness, "Ellipse"));
            shapesDictionary.Add(6, new Line(StartPoint, FinishPoint, Color, Thickness, "Line"));
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
