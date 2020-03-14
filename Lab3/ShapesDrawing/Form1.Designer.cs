namespace ShapesDrawing
{
    partial class fmShapeDrawing
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbDrawingBoard = new System.Windows.Forms.PictureBox();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editButton = new System.Windows.Forms.Button();
            this.btnDeserializable = new System.Windows.Forms.Button();
            this.btnSerializable = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.lblThickness = new System.Windows.Forms.Label();
            this.cbThickness = new System.Windows.Forms.ComboBox();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeParametersGrid = new System.Windows.Forms.DataGridView();
            this.charColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shapesListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawingBoard)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapeParametersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDrawingBoard
            // 
            this.pbDrawingBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDrawingBoard.Location = new System.Drawing.Point(128, 12);
            this.pbDrawingBoard.Name = "pbDrawingBoard";
            this.pbDrawingBoard.Size = new System.Drawing.Size(689, 585);
            this.pbDrawingBoard.TabIndex = 0;
            this.pbDrawingBoard.TabStop = false;
            this.pbDrawingBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDrawingBoard_MouseDown);
            this.pbDrawingBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDrawingBoard_MouseUp);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Location = new System.Drawing.Point(3, 3);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(102, 23);
            this.btnRectangle.TabIndex = 1;
            this.btnRectangle.Tag = "3";
            this.btnRectangle.Text = "Прямоугольник";
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(3, 32);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(102, 23);
            this.btnLine.TabIndex = 2;
            this.btnLine.Tag = "6";
            this.btnLine.Text = "Линия";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Location = new System.Drawing.Point(3, 148);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(102, 23);
            this.btnEllipse.TabIndex = 3;
            this.btnEllipse.Tag = "5";
            this.btnEllipse.Text = "Эллипсоид";
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(3, 61);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(102, 23);
            this.btnTriangle.TabIndex = 4;
            this.btnTriangle.Tag = "4";
            this.btnTriangle.Text = "Треугольник";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Location = new System.Drawing.Point(3, 119);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(102, 23);
            this.btnSquare.TabIndex = 5;
            this.btnSquare.Tag = "2";
            this.btnSquare.Text = "Квадрат";
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(3, 90);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(102, 23);
            this.btnCircle.TabIndex = 6;
            this.btnCircle.Tag = "1";
            this.btnCircle.Text = "Круг";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.btnDeserializable);
            this.panel1.Controls.Add(this.btnSerializable);
            this.panel1.Controls.Add(this.btnRedo);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.pbColor);
            this.panel1.Controls.Add(this.lblThickness);
            this.panel1.Controls.Add(this.cbThickness);
            this.panel1.Controls.Add(this.btnRectangle);
            this.panel1.Controls.Add(this.btnEllipse);
            this.panel1.Controls.Add(this.btnSquare);
            this.panel1.Controls.Add(this.btnCircle);
            this.panel1.Controls.Add(this.btnLine);
            this.panel1.Controls.Add(this.btnTriangle);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 585);
            this.panel1.TabIndex = 7;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(2, 475);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(103, 23);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // btnDeserializable
            // 
            this.btnDeserializable.Location = new System.Drawing.Point(2, 446);
            this.btnDeserializable.Name = "btnDeserializable";
            this.btnDeserializable.Size = new System.Drawing.Size(103, 23);
            this.btnDeserializable.TabIndex = 13;
            this.btnDeserializable.Text = "Загрузить";
            this.btnDeserializable.UseVisualStyleBackColor = true;
            this.btnDeserializable.Click += new System.EventHandler(this.btnDeserializable_Click);
            // 
            // btnSerializable
            // 
            this.btnSerializable.Location = new System.Drawing.Point(2, 417);
            this.btnSerializable.Name = "btnSerializable";
            this.btnSerializable.Size = new System.Drawing.Size(103, 23);
            this.btnSerializable.TabIndex = 8;
            this.btnSerializable.Text = "Сохранить";
            this.btnSerializable.UseVisualStyleBackColor = true;
            this.btnSerializable.Click += new System.EventHandler(this.btnSerializable_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(3, 388);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(102, 23);
            this.btnRedo.TabIndex = 9;
            this.btnRedo.Text = "Вперед";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(3, 359);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(102, 23);
            this.btnUndo.TabIndex = 8;
            this.btnUndo.Text = "Назад";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Black;
            this.pbColor.Location = new System.Drawing.Point(28, 245);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(53, 50);
            this.pbColor.TabIndex = 9;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblThickness
            // 
            this.lblThickness.AutoSize = true;
            this.lblThickness.Location = new System.Drawing.Point(25, 183);
            this.lblThickness.Name = "lblThickness";
            this.lblThickness.Size = new System.Drawing.Size(53, 13);
            this.lblThickness.TabIndex = 8;
            this.lblThickness.Text = "Толщина";
            // 
            // cbThickness
            // 
            this.cbThickness.FormattingEnabled = true;
            this.cbThickness.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbThickness.Location = new System.Drawing.Point(3, 199);
            this.cbThickness.Name = "cbThickness";
            this.cbThickness.Size = new System.Drawing.Size(102, 21);
            this.cbThickness.TabIndex = 7;
            this.cbThickness.Text = "1";
            this.cbThickness.TextChanged += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(882, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Список фигур";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(882, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Характеристики";
            // 
            // shapeParametersGrid
            // 
            this.shapeParametersGrid.AllowUserToAddRows = false;
            this.shapeParametersGrid.AllowUserToDeleteRows = false;
            this.shapeParametersGrid.AllowUserToResizeColumns = false;
            this.shapeParametersGrid.AllowUserToResizeRows = false;
            this.shapeParametersGrid.ColumnHeadersHeight = 25;
            this.shapeParametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shapeParametersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.charColumn,
            this.valueColumn});
            this.shapeParametersGrid.Location = new System.Drawing.Point(823, 284);
            this.shapeParametersGrid.MultiSelect = false;
            this.shapeParametersGrid.Name = "shapeParametersGrid";
            this.shapeParametersGrid.RowHeadersVisible = false;
            this.shapeParametersGrid.Size = new System.Drawing.Size(199, 313);
            this.shapeParametersGrid.TabIndex = 11;
            this.shapeParametersGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.shapeParametersGrid_CellEndEdit);
            // 
            // charColumn
            // 
            this.charColumn.HeaderText = "Характеристика";
            this.charColumn.Name = "charColumn";
            this.charColumn.ReadOnly = true;
            this.charColumn.Width = 125;
            // 
            // valueColumn
            // 
            this.valueColumn.HeaderText = "Значение";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.Width = 70;
            // 
            // shapesListView
            // 
            this.shapesListView.HideSelection = false;
            this.shapesListView.Location = new System.Drawing.Point(823, 45);
            this.shapesListView.Name = "shapesListView";
            this.shapesListView.Size = new System.Drawing.Size(199, 199);
            this.shapesListView.TabIndex = 12;
            this.shapesListView.UseCompatibleStateImageBehavior = false;
            this.shapesListView.SelectedIndexChanged += new System.EventHandler(this.shapesListView_SelectedIndexChanged);
            // 
            // fmShapeDrawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.shapesListView);
            this.Controls.Add(this.shapeParametersGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbDrawingBoard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmShapeDrawing";
            this.Text = "Лабораторная 1-2. Рисование фигур.";
            this.Load += new System.EventHandler(this.fmShapeDrawing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawingBoard)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapeParametersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDrawingBoard;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblThickness;
        private System.Windows.Forms.ComboBox cbThickness;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnSerializable;
        private System.Windows.Forms.Button btnDeserializable;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView shapeParametersGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn charColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.ListView shapesListView;
    }
}

