using System;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    public abstract class Shape
    {
        public Point firstPoint;
        public Point secondPoint;
        public String name;
        public Shape(Point firstPoint, Point secondPoint, String name)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.name = name;
        }
        public abstract void Draw(Graphics graphic);
    }
}
