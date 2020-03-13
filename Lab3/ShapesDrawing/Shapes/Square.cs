﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShapesDrawing
{
    [Serializable]
    class Square : Rectangle
    {
        public Square(Point firstPoint, Point secondPoint, Color color, int thickness) : base(firstPoint, secondPoint, color, thickness) {}

        public override int Width
        {
            get
            {
                return Height;
            }
        }

        public override void Draw(Graphics graphic)
        {
            Pen pen = new Pen(color, thickness);
            graphic.DrawRectangle(pen, topLeft.X, topLeft.Y, Width, Width);
        }
    }
}
