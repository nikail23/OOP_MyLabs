using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MyShapes
{
    [Serializable]
    [DataContract]
    public class Ellipse : Rectangle
    {
        public Ellipse() { }
        public Ellipse(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name)  { }
       
        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(Color.FromArgb(color), thickness);
            graphic.DrawEllipse(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Height);
        }
    }
}
