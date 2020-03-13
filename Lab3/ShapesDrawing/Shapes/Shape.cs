using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    public abstract class Shape : IDraw
    {
        public Point firstPoint;
        public Point secondPoint;
        public Shape(Point firstPoint, Point secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
        }

        public abstract void Draw(Graphics graphic);
    }
    interface IDraw 
    {
        void Draw(Graphics graphic);
    }
}
