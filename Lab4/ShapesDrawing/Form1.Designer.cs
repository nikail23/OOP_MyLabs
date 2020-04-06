namespace ShapesDrawing
{
    partial class ShapeDrawingForm
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
            this.ShapesTypesListBox = new System.Windows.Forms.ListBox();
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
            this.pbDrawingBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbDrawingBoard_MouseDown);
            this.pbDrawingBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbDrawingBoard_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ShapesTypesListBox);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.btnDeserializable);
            this.panel1.Controls.Add(this.btnSerializable);
            this.panel1.Controls.Add(this.btnRedo);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.pbColor);
            this.panel1.Controls.Add(this.lblThickness);
            this.panel1.Controls.Add(this.cbThickness);
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
            this.btnDeserializable.Click += new System.EventHandler(this.BtnDeserializable_Click);
            // 
            // btnSerializable
            // 
            this.btnSerializable.Location = new System.Drawing.Point(2, 417);
            this.btnSerializable.Name = "btnSerializable";
            this.btnSerializable.Size = new System.Drawing.Size(103, 23);
            this.btnSerializable.TabIndex = 8;
            this.btnSerializable.Text = "Сохранить";
            this.btnSerializable.UseVisualStyleBackColor = true;
            this.btnSerializable.Click += new System.EventHandler(this.BtnSerializable_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(3, 388);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(102, 23);
            this.btnRedo.TabIndex = 9;
            this.btnRedo.Text = "Вперед";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 330);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(3, 359);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(102, 23);
            this.btnUndo.TabIndex = 8;
            this.btnUndo.Text = "Назад";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Black;
            this.pbColor.Location = new System.Drawing.Point(28, 245);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(53, 50);
            this.pbColor.TabIndex = 9;
            this.pbColor.TabStop = false;
            this.pbColor.Click += new System.EventHandler(this.PictureBox1_Click);
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
            this.cbThickness.TextChanged += new System.EventHandler(this.ComboBox1_TextUpdate);
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
            this.shapeParametersGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapeParametersGrid_CellEndEdit);
            this.shapeParametersGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ShapeParametersGrid_CellMouseUp);
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
            this.shapesListView.SelectedIndexChanged += new System.EventHandler(this.ShapesListView_SelectedIndexChanged);
            // 
            // ShapesTypesListBox
            // 
            this.ShapesTypesListBox.FormattingEnabled = true;
            this.ShapesTypesListBox.Location = new System.Drawing.Point(2, 3);
            this.ShapesTypesListBox.Name = "ShapesTypesListBox";
            this.ShapesTypesListBox.Size = new System.Drawing.Size(103, 173);
            this.ShapesTypesListBox.TabIndex = 15;
            this.ShapesTypesListBox.SelectedIndexChanged += new System.EventHandler(this.ShapesTypesListBox_SelectedIndexChanged);
            // 
            // ShapeDrawingForm
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
            this.Name = "ShapeDrawingForm";
            this.Text = "Лабораторная 1-2. Рисование фигур.";
            this.Load += new System.EventHandler(this.FmShapeDrawing_Load);
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
        private System.Windows.Forms.ListBox ShapesTypesListBox;
    }
}

