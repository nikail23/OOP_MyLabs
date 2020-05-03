using MyShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace ShapesDrawing
{
    interface IDrawer
    {
        Point StartPoint { get; set; }
        Point FinishPoint { get; set; }
        int Thickness { get; set; }
        Color Color { get; set; }
        int ShapeTag { get; set; }


        void InitializeShapePlugin(Plugin shapePlugin);
        void DrawShapeList(IList<Shape> shapes);
        Shape CreateFigure();
    }
}
