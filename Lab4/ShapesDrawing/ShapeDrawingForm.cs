﻿using MyShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public partial class ShapeDrawingForm : Form
    {
        private IDrawer shapesDrawer;
        private IShapesListManager shapesListManager;
        private IPluginsManager pluginsManager;

        public ShapeDrawingForm(IShapesListManager shapesListManager, IPluginsManager pluginsManager)
        {
            this.shapesListManager = shapesListManager;
            this.pluginsManager = pluginsManager;
            InitializeComponent();
        }

        private void DrawingBoardPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            shapesDrawer.FinishPoint = new Point(e.X, e.Y);
            shapesListManager.Add(shapesDrawer.CreateFigure());
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void DrawingBoardPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            shapesDrawer.StartPoint = new Point(e.X, e.Y);
        }

        private void ShapeDrawingForm_Load(object sender, EventArgs e)
        {
            shapesDrawer = new Drawer(DrawingBoardPictureBox.CreateGraphics(), new Dictionary<int, Shape>());
        }

        private void ThicknessComboBox_TextUpdate(object sender, EventArgs e)
        {
            shapesDrawer.Thickness = (Convert.ToInt32(ThicknessComboBox.Text));
        }

        private void ColorPictureBox_Click(object sender, EventArgs e)
        {
            var dialogResult = ColorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ColorPictureBox.BackColor = ColorDialog.Color;
                shapesDrawer.Color = ColorDialog.Color;
            }
        }

        private void ClearDrawingBoard()
        {
            DrawingBoardPictureBox.Controls.Clear();
            DrawingBoardPictureBox.Invalidate();
            DrawingBoardPictureBox.Update();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearDrawingBoard();
            shapesListManager.ClearShapesList();
            shapesListManager.ClearDeletedShapesList();
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            DrawingBoardPictureBox.Refresh();
            shapesListManager.Undo();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            DrawingBoardPictureBox.Refresh();
            shapesListManager.Redo();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private bool CheckFunctionalPluginsListBox()
        {
            if ((CheckedFunctionalPluginsListBox.Items.Count > 0) && (CheckedFunctionalPluginsListBox.CheckedItems.Count > 0))
            {
                return true;
            }
            return false;
        }

        private void SerializeButton_Click(object sender, EventArgs e)
        {
            if (CheckFunctionalPluginsListBox())
            {
                var selectedIndex = CheckedFunctionalPluginsListBox.CheckedIndices[0];
                shapesListManager.SaveList(selectedIndex);
            }
            else
            {
                shapesListManager.SaveList();
            }
        }

        private void DeserializeButton_Click(object sender, EventArgs e)
        {
            DrawingBoardPictureBox.Refresh();
            if (CheckFunctionalPluginsListBox())
            {
                var selectedIndex = CheckedFunctionalPluginsListBox.CheckedIndices[0];
                shapesListManager.LoadList(selectedIndex);
            }
            else
            {
                shapesListManager.LoadList();
            }
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void ShapeParametersGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DrawingBoardPictureBox.Refresh();
            shapesListManager.ConfirmShapeParametersChange(shapeParametersGrid);
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void ShapeParametersGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            const int colorColumnIndex = 1;
            const int colorRowIndex = 5;
            if ((e.ColumnIndex == colorColumnIndex) && (e.RowIndex == colorRowIndex))
            {
                var dialogResult = ColorDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    shapeParametersGrid[colorColumnIndex, colorRowIndex].Style.BackColor = ColorDialog.Color;
                }
            }
            DrawingBoardPictureBox.Refresh();
            shapesListManager.ConfirmShapeParametersChange(shapeParametersGrid);
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void ShapesTypesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            shapesDrawer.ShapeTag = ShapesTypesListBox.SelectedIndex + 1;
        }

        private void CurrentShapesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentShapesListBox.SelectedIndex > -1)
                shapesListManager.ShowShapeParameters(shapeParametersGrid, CurrentShapesListBox.SelectedIndex);
        }

        private bool GetLibraryPath(ref string libraryPath)
        {
            const string FileDialogFilter = "Dynamic library files (*.dll)|*.dll";

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FileDialogFilter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                libraryPath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        private List<IShapeListSerializer> GetIncludedSerializers()
        {
            var serializers = new List<IShapeListSerializer>();
            foreach (var plugin in pluginsManager.SerializerPlugins)
            {
                foreach (var type in plugin.TypesList)
                {
                    var serializer = (IShapeListSerializer)plugin.Assembly.CreateInstance(type.FullName);
                    serializers.Add(serializer);
                }
            }
            return serializers;
        }

        private void ConnectPluginButton_Click(object sender, EventArgs e)
        {
            var pluginPath = "";

            if (GetLibraryPath(ref pluginPath))
            {
                if (pluginsManager.TryAddHierarchyPlugin(pluginPath, ShapesTypesListBox))
                {
                    shapesListManager.InitializeHierarchyPluginTypes(pluginsManager.GetAllHierarchyPluginsTypes());
                    shapesDrawer.InitializeHierarchyPlugin(pluginsManager.CurrentPlugin);
                }
                if (pluginsManager.TryAddSerializerPlugin(pluginPath, CheckedFunctionalPluginsListBox))
                {
                    var serializers = GetIncludedSerializers();
                    shapesListManager.InitializeIncludedSerializers(serializers);
                }
            }
        }
    }
}
