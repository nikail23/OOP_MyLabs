using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawing
{
    interface ISerializer
    {
        void Serialize(List<Shape> shapes);
        List<Shape> Deserialize();
    }
}
