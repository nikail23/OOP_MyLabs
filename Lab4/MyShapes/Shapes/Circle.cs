using System;
using System.Drawing;

namespace MyShapes
{
    [Serializable]
    public class Circle : Ellipse
    {
        public Circle(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name)  { }
        
        protected override int Width
        {
            get
            {
                return Math.Abs(secondPoint.X - firstPoint.X);
            }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawEllipse(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Width);
        }
    }
}
