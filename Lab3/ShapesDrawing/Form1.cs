﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesDrawing
{
    public partial class fmShapeDrawing : Form
    {
        Graphics graphic;
        Point startPoint;
        Point finishPoint;
        public int thickness = 1;
        public Color color = Color.Black;
        int tag = 3;
        Dictionary<int, Shape> shapesDictionary = new Dictionary<int, Shape>();
        List<Shape> demo = new List<Shape>();
        Service ShapesListManager = new Service();
        public fmShapeDrawing()
        {
            InitializeComponent();
        }
        private void DrawShapeList()
        {
            foreach (Shape shape in ShapesListManager.GetList())
            {
                shape.Draw(graphic);
            }
        }
        private void pbDrawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            finishPoint.X = e.X;
            finishPoint.Y = e.Y;
            AddShapesToDictionary();
            ShapesListManager.Add(shapesDictionary[tag]);
            shapesDictionary.Clear();
            DrawShapeList();
        }
        private void pbDrawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint.X = e.X;
            startPoint.Y = e.Y;
        }
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            tag = Convert.ToInt32(button.Tag);
        }
        private void fmShapeDrawing_Load(object sender, EventArgs e)
        {
            graphic = pbDrawingBoard.CreateGraphics();
            startPoint.X = 0;
            startPoint.Y = 0;
            finishPoint.X = 0;
            finishPoint.Y = 0;

            Pen pen = new Pen(color, thickness);
            demo.Add(new Line(new Point(10, 10), new Point(10, 100), Color.Black, 3));
            demo.Add(new Rectangle(new Point(30, 10), new Point(100, 100), Color.Red, 8));
            demo.Add(new Circle(new Point(130, 10), new Point(170, 100), Color.Brown, 4));
            demo.Add(new Square(new Point(200, 30), new Point(250, 100), Color.Yellow, 6));
            demo.Add(new Triangle(new Point(300, 30), new Point(350, 100), Color.Blue, 5));
            demo.Add(new Ellipse(new Point(400, 30), new Point(450, 100), Color.Green, 2));
        }
        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            thickness = Convert.ToInt32(cbThickness.Text);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dRes = ColorDialog.ShowDialog();
            if (dRes == DialogResult.OK)
            {
                pbColor.BackColor = ColorDialog.Color;
                color = ColorDialog.Color;
            }
        }
        private void btnDemo_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in demo)
                shape.Draw(graphic);
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
            ShapesListManager.ClearShapesList();
            ShapesListManager.ClearDeletedShapesList();
        }
        private void AddShapesToDictionary()
        {
            shapesDictionary.Add(1, new Circle(startPoint, finishPoint, color, thickness));
            shapesDictionary.Add(2, new Square(startPoint, finishPoint, color, thickness));
            shapesDictionary.Add(3, new Rectangle(startPoint, finishPoint, color, thickness));
            shapesDictionary.Add(4, new Triangle(startPoint, finishPoint, color, thickness));
            shapesDictionary.Add(5, new Ellipse(startPoint, finishPoint, color, thickness));
            shapesDictionary.Add(6, new Line(startPoint, finishPoint, color, thickness));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            ShapesListManager.Undo();
            DrawShapeList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            ShapesListManager.Redo();
            DrawShapeList();
        }
        private void btnSerializable_Click(object sender, EventArgs e)
        {
            ShapesListManager.SaveList();
        }
        private void btnDeserializable_Click(object sender, EventArgs e)
        {
            pbDrawingBoard.Refresh();
            ShapesListManager.LoadList();
            DrawShapeList();
        }
    }
}
