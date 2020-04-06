using MyShapes;
using System.Collections.Generic;
using System.Drawing;

namespace ShapesDrawing
{
    interface IDrawer
    {
        Point StartPoint { get; set; }
        Point FinishPoint { get; set; }
        int Thickness { get; set; }
        Color Color { get; set; }
        int ShapeTag { get; set; }

        void DrawShapeList(IList<Shape> shapes);
        Shape CreateFigure();
    }
}
