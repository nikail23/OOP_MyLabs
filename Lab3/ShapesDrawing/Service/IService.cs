using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawing
{
    interface IService
    {
        void ClearShapesList();
        void ClearDeletedShapesList();
        void Add(Shape shape);
        void Redo();
        void Undo();
        void LoadList();
        List<Shape> GetList();
        void SaveList();
    }
}
