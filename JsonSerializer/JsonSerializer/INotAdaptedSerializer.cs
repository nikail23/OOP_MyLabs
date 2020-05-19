using MyShapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotAdaptedJsonSerializerNamespace
{
    public interface INotAdaptedSerializer
    {
        void Serialize(string savePath, IList<Shape> shapes);
        IList<Shape> Deserialize(string loadPath);
    }
}
