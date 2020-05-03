using MyShapes;
using System;
using System.Collections.Generic;

namespace ShapesDrawing
{
    public interface ISerializer
    {
        void Serialize(IList<Shape> shapes, Type[] types);
        IList<Shape> Deserialize(Type[] types);
    }
}
