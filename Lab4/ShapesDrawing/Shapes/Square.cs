using System;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Square : Rectangle
    {
        public Square(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name) { }

        public override int Width
        {
            get
            {
                return Height;
            }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawRectangle(pen, topLeft.X, topLeft.Y, Width, Width);
        }
    }
}
