using MyShapes;
using System.Collections.Generic;
using System.Windows.Forms;

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
        void RefreshFormShapesList(ListView shapesListBox);
        void ShowShapeParameters(DataGridView parametersGrid, int shapeIndex);
        void ConfirmShapeParametersChange(DataGridView parametersGrid);
    }
}
