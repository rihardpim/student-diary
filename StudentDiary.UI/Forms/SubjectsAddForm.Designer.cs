namespace StudentDiary.UI.Forms
{
    partial class SubjectsAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textCode = new TextBox();
            textName = new TextBox();
            comboPart = new ComboBox();
            numericKp = new NumericUpDown();
            numericEcts = new NumericUpDown();
            numericSemester = new NumericUpDown();
            comboTeacher = new ComboBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numericKp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEcts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSemester).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Kods";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 53);
            label2.Margin = new Padding(10);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 2;
            label2.Text = "Nosaukums ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 96);
            label3.Margin = new Padding(10);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "Daļa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 139);
            label4.Margin = new Padding(10);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 6;
            label4.Text = "KP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 182);
            label5.Margin = new Padding(10);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 8;
            label5.Text = "ECTS";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 225);
            label6.Margin = new Padding(10);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 10;
            label6.Text = "Semestris";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 268);
            label7.Margin = new Padding(10);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 12;
            label7.Text = "Pasniedzējs";
            // 
            // textCode
            // 
            textCode.Location = new Point(105, 10);
            textCode.Margin = new Padding(10);
            textCode.Name = "textCode";
            textCode.Size = new Size(91, 23);
            textCode.TabIndex = 13;
            // 
            // textName
            // 
            textName.Location = new Point(105, 53);
            textName.Margin = new Padding(10);
            textName.Name = "textName";
            textName.Size = new Size(100, 23);
            textName.TabIndex = 14;
            // 
            // comboPart
            // 
            comboPart.FormattingEnabled = true;
            comboPart.Items.AddRange(new object[] { "A", "B", "C" });
            comboPart.Location = new Point(105, 96);
            comboPart.Margin = new Padding(10);
            comboPart.Name = "comboPart";
            comboPart.Size = new Size(98, 23);
            comboPart.TabIndex = 15;
            // 
            // numericKp
            // 
            numericKp.Location = new Point(105, 139);
            numericKp.Margin = new Padding(10);
            numericKp.Maximum = new decimal(new int[] { 18, 0, 0, 0 });
            numericKp.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericKp.Name = "numericKp";
            numericKp.Size = new Size(98, 23);
            numericKp.TabIndex = 16;
            numericKp.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericEcts
            // 
            numericEcts.Location = new Point(105, 182);
            numericEcts.Margin = new Padding(10);
            numericEcts.Maximum = new decimal(new int[] { 18, 0, 0, 0 });
            numericEcts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEcts.Name = "numericEcts";
            numericEcts.Size = new Size(98, 23);
            numericEcts.TabIndex = 17;
            numericEcts.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericSemester
            // 
            numericSemester.Location = new Point(105, 225);
            numericSemester.Margin = new Padding(10);
            numericSemester.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numericSemester.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericSemester.Name = "numericSemester";
            numericSemester.Size = new Size(98, 23);
            numericSemester.TabIndex = 18;
            numericSemester.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboTeacher
            // 
            comboTeacher.FormattingEnabled = true;
            comboTeacher.Location = new Point(105, 268);
            comboTeacher.Margin = new Padding(10);
            comboTeacher.Name = "comboTeacher";
            comboTeacher.Size = new Size(121, 23);
            comboTeacher.TabIndex = 19;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(10, 311);
            buttonSave.Margin = new Padding(10);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 20;
            buttonSave.Text = "Saglabāt";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(105, 311);
            buttonCancel.Margin = new Padding(10);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 21;
            buttonCancel.Text = "Atcelt";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 7);
            tableLayoutPanel1.Controls.Add(textCode, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonSave, 0, 7);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(comboTeacher, 1, 6);
            tableLayoutPanel1.Controls.Add(textName, 1, 1);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(numericSemester, 1, 5);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(numericEcts, 1, 4);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(comboPart, 1, 2);
            tableLayoutPanel1.Controls.Add(numericKp, 1, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(291, 370);
            tableLayoutPanel1.TabIndex = 22;
            // 
            // SubjectsAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            CancelButton = buttonCancel;
            ClientSize = new Size(291, 350);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SubjectsAddForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "SubjectsAddForm";
            ((System.ComponentModel.ISupportInitialize)numericKp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEcts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSemester).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textCode;
        private TextBox textName;
        private ComboBox comboPart;
        private NumericUpDown numericKp;
        private NumericUpDown numericEcts;
        private NumericUpDown numericSemester;
        private ComboBox comboTeacher;
        private Button buttonSave;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}