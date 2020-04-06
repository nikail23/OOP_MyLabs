using System;
using System.Drawing;

namespace MyShapes
{
    [Serializable]
    public class Ellipse : Rectangle
    {
        public Ellipse(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name)  { }
       
        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawEllipse(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Height);
        }
    }
}
