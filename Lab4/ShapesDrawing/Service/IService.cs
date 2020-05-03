using MyShapes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public interface IService
    {
        void ClearShapesList();
        void ClearDeletedShapesList();
        void Add(Shape shape);
        void Redo();
        void Undo();
        void LoadList();
        IList<Shape> GetList();
        void SaveList();
        void InitializePluginTypes(Type[] pluginTypes);
        void RefreshFormShapesList(ListBox shapesListBox);
        void ShowShapeParameters(DataGridView parametersGrid, int shapeIndex);
        void ConfirmShapeParametersChange(DataGridView parametersGrid);
    }
}
