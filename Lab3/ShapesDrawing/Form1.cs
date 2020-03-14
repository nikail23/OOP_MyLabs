using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public partial class fmShapeDrawing : Form
    {
        Drawer shapesDrawer;
        Service shapesListManager = new Service(new BinarySerializer(), new List<Shape>(), new List<Shape>());
        public fmShapeDrawing()
        {
            InitializeComponent();
        }
        private void pbDrawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            shapesDrawer.SetFinishPoint(e.X, e.Y);
            shapesListManager.Add(shapesDrawer.CreateFigure());
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(shapesListView);
        }
        private void pbDrawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            shapesDrawer.SetStartPoint(e.X, e.Y);
        }
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            shapesDrawer.SetTag(Convert.ToInt32(button.Tag));
        }
        private void fmShapeDrawing_Load(object sender, EventArgs e)
        {
            shapesDrawer = new Drawer(pbDrawingBoard.CreateGraphics(), new Dictionary<int, Shape>());
        }
        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            shapesDrawer.SetThickness(Convert.ToInt32(cbThickness.Text));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dRes = ColorDialog.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                pbColor.BackColor = ColorDialog.Color;
                shapesDrawer.SetColor(ColorDialog.Color);
            }
        }
        private void ClearDrawingBoard()
        {
            pbDrawingBoard.Controls.Clear();
            pbDrawingBoard.Invalidate();
            pbDrawingBoard.Update();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearDrawingBoard();
            shapesListManager.ClearShapesList();
            shapesListManager.ClearDeletedShapesList();
            shapesListManager.RefreshFormShapesList(shapesListView);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.Undo();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(shapesListView);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.Redo();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(shapesListView);
        }
        private void btnSerializable_Click(object sender, EventArgs e)
        {
            shapesListManager.SaveList();
        }
        private void btnDeserializable_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.LoadList();
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(shapesListView);
        }

        private void shapesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            shapesListManager.OpenShapeCharacteristics(shapeParametersGrid, shapesListView.SelectedIndices[0]);
        }

        private void shapeParametersGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            pbDrawingBoard.Refresh();
            shapesListManager.EditShape(shapeParametersGrid);
            shapesDrawer.DrawShapeList(shapesListManager.GetList());
            shapesListManager.RefreshFormShapesList(shapesListView);
        }
    }
}
