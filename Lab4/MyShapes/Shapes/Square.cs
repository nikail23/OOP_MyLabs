using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace MyShapes
{
    [Serializable]
    [DataContract]
    public class Square : Rectangle
    {
        public Square() { }
        public Square(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, color, thickness, name) { }

        [DataMember]
        protected override int Width
        {
            get
            {
                return Height;
            }
            set { }
        }

        public override void Draw(Graphics graphic)
        {
            var pen = new Pen(Color.FromArgb(color), thickness);
            graphic.DrawRectangle(pen, TopLeftPoint.X, TopLeftPoint.Y, Width, Width);
        }
    }
}
