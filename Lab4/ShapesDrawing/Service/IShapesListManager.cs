using MyShapes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public interface IShapesListManager
    {
        void ClearShapesList();
        void ClearDeletedShapesList();
        void Add(Shape shape);
        void Redo();
        void Undo();
        void LoadList();
        void LoadList(int serializerIndex);
        IList<Shape> GetList();
        void SaveList();
        void SaveList(int serializerIndex);
        void InitializeHierarchyPluginTypes(Type[] pluginTypes);
        void InitializeIncludedSerializers(List<IShapeListSerializer> serializers);
        void RefreshFormShapesList(ListBox shapesListBox);
        void ShowShapeParameters(DataGridView parametersGrid, int shapeIndex);
        void ConfirmShapeParametersChange(DataGridView parametersGrid);
    }
}
