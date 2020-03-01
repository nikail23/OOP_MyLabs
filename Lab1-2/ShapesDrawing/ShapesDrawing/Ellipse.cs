using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    class Ellipse : Rectangle
    {
        public Ellipse(Point firstPoint, Point secondPoint, Color color, int thickness) : base(firstPoint, secondPoint, color, thickness) {}

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(pen, topLeft.X, topLeft.Y, Width, Height);
        }
    }
}
