using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    class Line : Shape
    {
        public Line(Point firstPoint, Point secondPoint, Color color, int thickness) : base(firstPoint, secondPoint, color, thickness) {}

        public override void Draw(Graphics graphic)
        {
            graphic.DrawLine(pen, firstPoint, secondPoint);
        }
    }

}
