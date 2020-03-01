using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        List<Shape> shapes = new List<Shape>();
        List<Shape> deletedShapes = new List<Shape>();

        public fmShapeDrawing()
        {
            InitializeComponent();
        }

        private void pbDrawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            finishPoint.X = e.X;
            finishPoint.Y = e.Y;
            AddShapesToDictionary();
            shapes.Add(shapesDictionary[tag]); 
            foreach (Shape shape in shapes)
            {
                shape.Draw(graphic);
            }
            shapesDictionary.Clear();
        }

        private void pbDrawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint.X = e.X;
            startPoint.Y = e.Y;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // as Button;
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
            shapes.Clear();
            deletedShapes.Clear();
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
            if (shapes.Count != 0)
            {
                deletedShapes.Add(shapes[shapes.Count - 1]);
                shapes.RemoveAt(shapes.Count - 1);
                ClearDrawingBoard();
                foreach (Shape shape in shapes)
                    shape.Draw(graphic);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (deletedShapes.Count != 0)
            {
                shapes.Add(deletedShapes[deletedShapes.Count - 1]);
                deletedShapes.RemoveAt(deletedShapes.Count - 1);
                ClearDrawingBoard();
                foreach (Shape figure in shapes)
                    figure.Draw(graphic);
            }
        }
    }
}
