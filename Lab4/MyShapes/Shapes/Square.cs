using System;
using System.Drawing;

namespace MyShapes
{
    [Serializable]
    public class Square : Rectangle
    {
        public Square() { }
        public Square(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name) { }

        protected override int Width
        {
            get
            {
                return Height;
            }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(Color.FromArgb(color), thickness);
            graphic.DrawRectangle(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Width);
        }
    }
}
