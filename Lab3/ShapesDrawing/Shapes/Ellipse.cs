using System;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Ellipse : Rectangle
    {
        public Ellipse(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name)  { }
        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawEllipse(pen, topLeft.X, topLeft.Y, Width, Height);
        }
    }
}
