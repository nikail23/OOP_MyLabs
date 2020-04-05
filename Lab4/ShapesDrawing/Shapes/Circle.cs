using System;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Circle : Ellipse
    {
        public Circle(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name)  { }
        public override int Width
        {
            get
            {
                return Math.Abs(secondPoint.X - firstPoint.X);
            }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawEllipse(pen, topLeft.X, topLeft.Y, Width, Width);
        }
    }
}
