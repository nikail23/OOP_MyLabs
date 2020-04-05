using System.Collections.Generic;

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
        IList<Shape> GetList();
        void SaveList();
    }
}
