using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    class Triangle : Shape
    {
        Point[] points;
        Point firstTrianglePoint, secondTrianglePoint, thirdTrianglePoint;
        public Triangle(Point firstPoint, Point secondPoint, Color color, int thickness) : base(firstPoint, secondPoint, color, thickness) {}

        public override void Draw(Graphics graphics)
        {
            CheckCondition();
            graphics.DrawPolygon(pen, points);
        }

        public void CheckCondition()
        {
            if ((firstPoint.X < secondPoint.X) && (firstPoint.Y < secondPoint.Y))
            {
                firstTrianglePoint.X = Math.Abs((firstPoint.X - secondPoint.X) / 2) + firstPoint.X;
                firstTrianglePoint.Y = firstPoint.Y;
                secondTrianglePoint.X = firstPoint.X;
                secondTrianglePoint.Y = secondPoint.Y;
                thirdTrianglePoint.X = secondPoint.X;
                thirdTrianglePoint.Y = secondPoint.Y;
            }
            else if ((firstPoint.X < secondPoint.X) && (firstPoint.Y > secondPoint.Y))
            {
                firstTrianglePoint.X = Math.Abs((firstPoint.X - secondPoint.X) / 2) + firstPoint.X;
                firstTrianglePoint.Y = secondPoint.Y;
                secondTrianglePoint.X = firstPoint.X;
                secondTrianglePoint.Y = firstPoint.Y;
                thirdTrianglePoint.X = secondPoint.X;
                thirdTrianglePoint.Y = firstPoint.Y;
            }
            else if ((firstPoint.X > secondPoint.X) && (firstPoint.Y < secondPoint.Y))
            {
                firstTrianglePoint.X = firstPoint.X - Math.Abs((firstPoint.X - secondPoint.X) / 2);
                firstTrianglePoint.Y = firstPoint.Y;
                secondTrianglePoint.X = secondPoint.X;
                secondTrianglePoint.Y = secondPoint.Y;
                thirdTrianglePoint.X = firstPoint.X;
                thirdTrianglePoint.Y = secondPoint.Y;
            }
            else
            {
                firstTrianglePoint.X = firstPoint.X - Math.Abs((firstPoint.X - secondPoint.X) / 2);
                firstTrianglePoint.Y = secondPoint.Y;
                secondTrianglePoint.X = secondPoint.X;
                secondTrianglePoint.Y = firstPoint.Y;
                thirdTrianglePoint.X = firstPoint.X;
                thirdTrianglePoint.Y = firstPoint.Y;
            }
            points = new Point[] { firstTrianglePoint, secondTrianglePoint, thirdTrianglePoint };
        } 
    }
}
