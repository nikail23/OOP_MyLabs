using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Line : Shape
    {
        public Color color;
        public int thickness;
        public Line(Point firstPoint, Point secondPoint, Color color, int thickness) : base(firstPoint, secondPoint)
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
