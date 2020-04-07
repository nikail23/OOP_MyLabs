using MyShapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public partial class ShapeDrawingForm : Form
    {
        private static readonly string projectPath = Directory.GetCurrentDirectory();
        IDrawer shapesDrawer;
        IService shapesListManager;
        IPluginScanner pluginScanner;
        public ShapeDrawingForm()
        {
            shapesListManager = new Service(new BinarySerializer(), new List<Shape>(), new List<Shape>());
            pluginScanner = new PluginScanner();
            InitializeComponent();
        }
        private void PbDrawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            shapesDrawer.FinishPoint = new Point(e.X, e.Y);
            shapesListManager.Add(shapesDrawer.CreateFigure());
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }
        private void PbDrawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            shapesDrawer.StartPoint = new Point(e.X, e.Y);
        }
        private void FmShapeDrawing_Load(object sender, EventArgs e)
        {
            shapesDrawer = new Drawer(pbDrawingBoard.CreateGraphics(), new Dictionary<int, Shape>());
            string[] pluginsList = pluginScanner.GetPluginsList(projectPath + "\\Plugins");
            
        }
        private void ComboBox1_TextUpdate(object sender, EventArgs e)
        {
            shapesDrawer.Thickness = (Convert.ToInt32(cbThickness.Text));
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dRes = ColorDialog.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                pbColor.BackColor = ColorDialog.Color;
                shapesDrawer.Color = ColorDialog.Color;
            }
        }
        private void ClearDrawingBoard()
        {
            pbDrawingBoard.Controls.Clear();
            pbDrawingBoard.Invalidate();
            pbDrawingBoard.Update();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearDrawingBoard();
            shapesListManager.ClearShapesList();
            shapesListManager.ClearDeletedShapesList();
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.Undo();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.Redo();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }
        private void BtnSerializable_Click(object sender, EventArgs e)
        {
            shapesListManager.SaveList();
        }
        private void BtnDeserializable_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.LoadList();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void ShapeParametersGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.ConfirmShapeParametersChange(shapeParametersGrid);
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(CurrentShapesListBox);
        }

        private void ShapeParametersGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            const int colorColumnIndex = 1;
            const int colorRowIndex = 5;
            if ((e.ColumnIndex == colorColumnIndex) &&(e.RowIndex == colorRowIndex))
            {
                DialogResult dialogResult = ColorDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    shapeParametersGrid[colorColumnIndex, colorRowIndex].Style.BackColor = ColorDialog.Color;
                }
            }
            pbDrawingBoard.Refresh();
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
    }
}
