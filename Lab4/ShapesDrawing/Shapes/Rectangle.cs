using System;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Rectangle : Shape
    {
        public Color color;
        public int thickness;
        public Rectangle(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, name)
        {
            this.color = color;
            this.thickness = thickness;
        }
        public virtual int Width
        {
            get
            {
                return Math.Abs(secondPoint.X - firstPoint.X);
            }
        }
        public int Height
        {
            get
            {
                return Math.Abs(secondPoint.Y - firstPoint.Y);
            }
        }
        public Point topLeft
        {
            get
            {
                int x = Math.Min(firstPoint.X, secondPoint.X);
                int y = Math.Min(firstPoint.Y, secondPoint.Y);
                return new Point(x, y);
            }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawRectangle(pen, topLeft.X, topLeft.Y, Width, Height);
        }
    }
}
