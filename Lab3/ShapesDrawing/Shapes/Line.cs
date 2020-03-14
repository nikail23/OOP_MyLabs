using System;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Line : Shape
    {
        public Color color;
        public int thickness;
        public Line(Point firstPoint, Point secondPoint, Color color, int thickness, String name) : base(firstPoint, secondPoint, name)
        {
            this.thickness = thickness;
            this.color = color;
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawLine(pen, firstPoint, secondPoint);
        }
    }

}
