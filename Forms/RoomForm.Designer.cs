namespace InteriorDesigner
{
    partial class RoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        private Label lblWidth;
        private Label lblLength;
        private Label lblHeight;

        private NumericUpDown numWidth;
        private NumericUpDown numLength;
        private NumericUpDown numHeight;

        private Button btnCreate;
        private Button btnCancel;

        private ComboBox cmbTemplates;
        private Label lblTemplate;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWidth = new Label();
            lblLength = new Label();
            lblHeight = new Label();
            numWidth = new NumericUpDown();
            numLength = new NumericUpDown();
            numHeight = new NumericUpDown();
            btnCreate = new Button();
            btnCancel = new Button();
            cmbTemplates = new ComboBox();
            lblTemplate = new Label();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            SuspendLayout();
            // 
            // lblWidth
            // 
            lblWidth.Location = new Point(20, 70);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(100, 23);
            lblWidth.TabIndex = 2;
            lblWidth.Text = "Ширина";
            // 
            // lblLength
            // 
            lblLength.Location = new Point(20, 110);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(100, 23);
            lblLength.TabIndex = 3;
            lblLength.Text = "Длина";
            // 
            // lblHeight
            // 
            lblHeight.Location = new Point(20, 150);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(100, 23);
            lblHeight.TabIndex = 4;
            lblHeight.Text = "Высота";
            // 
            // numWidth
            // 
            numWidth.Location = new Point(120, 70);
            numWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(120, 27);
            numWidth.TabIndex = 5;
            numWidth.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // numLength
            // 
            numLength.Location = new Point(120, 110);
            numLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLength.Name = "numLength";
            numLength.Size = new Size(120, 27);
            numLength.TabIndex = 6;
            numLength.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numHeight
            // 
            numHeight.Location = new Point(120, 150);
            numHeight.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numHeight.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(120, 27);
            numHeight.TabIndex = 7;
            numHeight.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(40, 220);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 40);
            btnCreate.TabIndex = 8;
            btnCreate.Text = "Создать";
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(170, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbTemplates
            // 
            cmbTemplates.Items.AddRange(new object[] { "Однокомнатная квартира", "Двухкомнатная квартира", "Офис", "Студия" });
            cmbTemplates.Location = new Point(120, 18);
            cmbTemplates.Name = "cmbTemplates";
            cmbTemplates.Size = new Size(180, 28);
            cmbTemplates.TabIndex = 1;
            cmbTemplates.SelectedIndexChanged += cmbTemplates_SelectedIndexChanged;
            // 
            // lblTemplate
            // 
            lblTemplate.Location = new Point(20, 20);
            lblTemplate.Name = "lblTemplate";
            lblTemplate.Size = new Size(100, 23);
            lblTemplate.TabIndex = 0;
            lblTemplate.Text = "Шаблон";
            // 
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 290);
            Controls.Add(lblTemplate);
            Controls.Add(cmbTemplates);
            Controls.Add(lblWidth);
            Controls.Add(lblLength);
            Controls.Add(lblHeight);
            Controls.Add(numWidth);
            Controls.Add(numLength);
            Controls.Add(numHeight);
            Controls.Add(btnCreate);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RoomForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Создание помещения";
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}