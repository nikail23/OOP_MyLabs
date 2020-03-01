using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    public abstract class Shape : IDraw
    {
        public Point firstPoint;
        public Point secondPoint;
        public Pen pen { get; set; }
        public Shape(Point firstPoint, Point secondPoint, Color color, int thickness)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.pen = new Pen(color, thickness);
        }

        public abstract void Draw(Graphics graphic);
    }
    interface IDraw
    {
        Pen pen { get; set; }
        void Draw(Graphics graphic);
    }
}
