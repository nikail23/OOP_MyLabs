using System;
using System.Collections.Generic;
using System.Drawing;

namespace ShapesDrawing
{
    class Drawer : IDrawer
    {
        private const int DefaultThickness = 1;
        private const int DefaultShapeTag = 1;
        private static readonly Color DefaultColor = Color.Black;
        private Graphics graphic;
        private Point startPoint;
        private Point finishPoint;
        private int thickness;
        private Color color;
        private int shapeTag;
        IDictionary<int, Shape> shapesDictionary;
        public Drawer(Graphics graphic, Dictionary<int, Shape> shapesDictionary)
        {
            this.graphic = graphic;
            thickness = DefaultThickness;
            shapeTag = DefaultShapeTag;
            color = DefaultColor;
            this.shapesDictionary = shapesDictionary;
        }
        public void DrawShapeList(IList<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(graphic);
            }
        }
        public void SetStartPoint(int x, int y)
        {
            startPoint.X = x;
            startPoint.Y = y;
        }
        public void SetFinishPoint(int x, int y)
        {
            if (new Point(x, y) != startPoint)
            {
                finishPoint.X = x;
                finishPoint.Y = y;
            }    
        }
        public void SetThickness(int thickness)
        {
            if (thickness > 0)
                this.thickness = thickness;
        }
        public void SetColor(Color color)
        {
            if (color != null)
                this.color = color;
        }
        public void SetTag(int tag)
        {
            if ((tag >= 0) && (tag <= 6))
                this.shapeTag = tag;
        }
        private void AddShapesToDictionary()
        {
            shapesDictionary.Add(1, new Circle(startPoint, finishPoint, color, thickness, "Circle"));
            shapesDictionary.Add(2, new Square(startPoint, finishPoint, color, thickness, "Square"));
            shapesDictionary.Add(3, new Rectangle(startPoint, finishPoint, color, thickness, "Rectangle"));
            shapesDictionary.Add(4, new Triangle(startPoint, finishPoint, color, thickness, "Triangle"));
            shapesDictionary.Add(5, new Ellipse(startPoint, finishPoint, color, thickness, "Ellipse"));
            shapesDictionary.Add(6, new Line(startPoint, finishPoint, color, thickness, "Line"));
        }
        public Shape CreateFigure()
        {
            AddShapesToDictionary();
            Shape shape = shapesDictionary[shapeTag];
            shapesDictionary.Clear();
            return shape;
        }
    }
}
