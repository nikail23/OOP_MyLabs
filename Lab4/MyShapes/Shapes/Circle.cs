using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MyShapes
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(Shape))]
    public class Circle : Ellipse
    {
        public Circle() { }
        public Circle(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name) { }

        [DataMember]
        protected override int Width
        {
            get
            {
                return Math.Abs(secondPoint.X - firstPoint.X);
            }
            set { }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(Color.FromArgb(color), thickness);
            graphic.DrawEllipse(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Width);
        }
    }
}
