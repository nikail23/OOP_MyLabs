using System.Collections.Generic;

namespace ShapesDrawing
{
    interface IDrawer
    {
        void DrawShapeList(IList<Shape> shapes);
    }
}
