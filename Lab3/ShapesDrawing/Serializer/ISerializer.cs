using System.Collections.Generic;

namespace ShapesDrawing
{
    public interface ISerializer
    {
        void Serialize(IList<Shape> shapes);
        IList<Shape> Deserialize();
    }
}
