namespace StudentDiary.UI.Forms
{
    partial class SubjectForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            dataGridSubjects = new DataGridView();
            panel3 = new Panel();
            buttonDeleteGrade = new Button();
            dataGridGrades = new DataGridView();
            panel2 = new Panel();
            labelGradesTitle = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonDeleteSubject = new Button();
            buttonAddSubject = new Button();
            buttonEditSubject = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonClearGrade = new Button();
            comboGradeSubject = new ComboBox();
            buttonSaveGrade = new Button();
            label4 = new Label();
            textGradeComment = new TextBox();
            numericGradeValue = new NumericUpDown();
            label7 = new Label();
            label5 = new Label();
            comboGradeType = new ComboBox();
            label6 = new Label();
            dateTimeGradeDate = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSubjects).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridGrades).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradeValue).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(10, 10);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Azure;
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(780, 430);
            splitContainer1.SplitterDistance = 524;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 50);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dataGridSubjects);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel3);
            splitContainer2.Panel2.Controls.Add(dataGridGrades);
            splitContainer2.Panel2.Controls.Add(panel2);
            splitContainer2.Size = new Size(524, 380);
            splitContainer2.SplitterDistance = 170;
            splitContainer2.TabIndex = 1;
            // 
            // dataGridSubjects
            // 
            dataGridSubjects.AllowUserToAddRows = false;
            dataGridSubjects.AllowUserToDeleteRows = false;
            dataGridSubjects.AllowUserToResizeColumns = false;
            dataGridSubjects.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = Color.DodgerBlue;
            dataGridSubjects.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridSubjects.BackgroundColor = Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.SteelBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Window;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridSubjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Lavender;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridSubjects.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridSubjects.Dock = DockStyle.Fill;
            dataGridSubjects.EnableHeadersVisualStyles = false;
            dataGridSubjects.Location = new Point(0, 0);
            dataGridSubjects.MultiSelect = false;
            dataGridSubjects.Name = "dataGridSubjects";
            dataGridSubjects.ReadOnly = true;
            dataGridSubjects.RowHeadersVisible = false;
            dataGridSubjects.RowTemplate.Height = 30;
            dataGridSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridSubjects.Size = new Size(524, 170);
            dataGridSubjects.TabIndex = 0;
            dataGridSubjects.SelectionChanged += dataGridSubjects_SelectionChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Azure;
            panel3.Controls.Add(buttonDeleteGrade);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 156);
            panel3.Name = "panel3";
            panel3.Size = new Size(524, 50);
            panel3.TabIndex = 3;
            // 
            // buttonDeleteGrade
            // 
            buttonDeleteGrade.BackColor = Color.Teal;
            buttonDeleteGrade.Cursor = Cursors.Hand;
            buttonDeleteGrade.FlatAppearance.BorderSize = 0;
            buttonDeleteGrade.FlatStyle = FlatStyle.Flat;
            buttonDeleteGrade.ForeColor = Color.White;
            buttonDeleteGrade.Location = new Point(10, 15);
            buttonDeleteGrade.Name = "buttonDeleteGrade";
            buttonDeleteGrade.Size = new Size(102, 23);
            buttonDeleteGrade.TabIndex = 0;
            buttonDeleteGrade.Text = "Dzēst atzīmi";
            buttonDeleteGrade.UseVisualStyleBackColor = false;
            buttonDeleteGrade.Click += buttonDeleteGrade_Click;
            // 
            // dataGridGrades
            // 
            dataGridGrades.AllowUserToAddRows = false;
            dataGridGrades.AllowUserToDeleteRows = false;
            dataGridGrades.AllowUserToResizeColumns = false;
            dataGridGrades.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionForeColor = Color.DodgerBlue;
            dataGridGrades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridGrades.BackgroundColor = Color.Gainsboro;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.SteelBlue;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.Window;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridGrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Lavender;
            dataGridViewCellStyle6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = Color.DodgerBlue;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridGrades.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridGrades.Dock = DockStyle.Fill;
            dataGridGrades.EnableHeadersVisualStyles = false;
            dataGridGrades.Location = new Point(0, 50);
            dataGridGrades.MultiSelect = false;
            dataGridGrades.Name = "dataGridGrades";
            dataGridGrades.ReadOnly = true;
            dataGridGrades.RowHeadersVisible = false;
            dataGridGrades.RowTemplate.Height = 30;
            dataGridGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridGrades.Size = new Size(524, 156);
            dataGridGrades.TabIndex = 1;
            dataGridGrades.SelectionChanged += dataGridGrades_SelectionChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelGradesTitle);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(524, 50);
            panel2.TabIndex = 2;
            // 
            // labelGradesTitle
            // 
            labelGradesTitle.AutoSize = true;
            labelGradesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelGradesTitle.Location = new Point(30, 17);
            labelGradesTitle.Name = "labelGradesTitle";
            labelGradesTitle.Size = new Size(190, 21);
            labelGradesTitle.TabIndex = 0;
            labelGradesTitle.Text = "Izvēlieties studiju kursu";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(524, 50);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(buttonDeleteSubject, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonAddSubject, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonEditSubject, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(524, 50);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // buttonDeleteSubject
            // 
            buttonDeleteSubject.Anchor = AnchorStyles.Left;
            buttonDeleteSubject.BackColor = Color.Teal;
            buttonDeleteSubject.Cursor = Cursors.Hand;
            buttonDeleteSubject.FlatAppearance.BorderSize = 0;
            buttonDeleteSubject.FlatStyle = FlatStyle.Flat;
            buttonDeleteSubject.ForeColor = Color.White;
            buttonDeleteSubject.Location = new Point(200, 13);
            buttonDeleteSubject.Margin = new Padding(10);
            buttonDeleteSubject.Name = "buttonDeleteSubject";
            buttonDeleteSubject.Size = new Size(75, 23);
            buttonDeleteSubject.TabIndex = 6;
            buttonDeleteSubject.Text = "Dzēst";
            buttonDeleteSubject.UseVisualStyleBackColor = false;
            buttonDeleteSubject.Click += buttonDeleteSubject_Click;
            // 
            // buttonAddSubject
            // 
            buttonAddSubject.Anchor = AnchorStyles.None;
            buttonAddSubject.BackColor = Color.Teal;
            buttonAddSubject.Cursor = Cursors.Hand;
            buttonAddSubject.FlatAppearance.BorderSize = 0;
            buttonAddSubject.FlatStyle = FlatStyle.Flat;
            buttonAddSubject.ForeColor = Color.White;
            buttonAddSubject.Location = new Point(10, 13);
            buttonAddSubject.Margin = new Padding(10);
            buttonAddSubject.Name = "buttonAddSubject";
            buttonAddSubject.Size = new Size(75, 23);
            buttonAddSubject.TabIndex = 4;
            buttonAddSubject.Text = "Pievienot";
            buttonAddSubject.UseVisualStyleBackColor = false;
            buttonAddSubject.Click += buttonAddSubject_Click;
            // 
            // buttonEditSubject
            // 
            buttonEditSubject.Anchor = AnchorStyles.None;
            buttonEditSubject.BackColor = Color.Teal;
            buttonEditSubject.Cursor = Cursors.Hand;
            buttonEditSubject.FlatAppearance.BorderSize = 0;
            buttonEditSubject.FlatStyle = FlatStyle.Flat;
            buttonEditSubject.ForeColor = Color.White;
            buttonEditSubject.Location = new Point(105, 13);
            buttonEditSubject.Margin = new Padding(10);
            buttonEditSubject.Name = "buttonEditSubject";
            buttonEditSubject.Size = new Size(75, 23);
            buttonEditSubject.TabIndex = 5;
            buttonEditSubject.Text = "Labot";
            buttonEditSubject.UseVisualStyleBackColor = false;
            buttonEditSubject.Click += buttonEditSubject_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.Controls.Add(buttonClearGrade, 1, 5);
            tableLayoutPanel2.Controls.Add(comboGradeSubject, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonSaveGrade, 0, 5);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(textGradeComment, 1, 4);
            tableLayoutPanel2.Controls.Add(numericGradeValue, 1, 1);
            tableLayoutPanel2.Controls.Add(label7, 0, 4);
            tableLayoutPanel2.Controls.Add(label5, 0, 2);
            tableLayoutPanel2.Controls.Add(comboGradeType, 1, 2);
            tableLayoutPanel2.Controls.Add(label6, 0, 3);
            tableLayoutPanel2.Controls.Add(dateTimeGradeDate, 1, 3);
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 37);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(252, 390);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // buttonClearGrade
            // 
            buttonClearGrade.Anchor = AnchorStyles.None;
            buttonClearGrade.BackColor = Color.Teal;
            buttonClearGrade.Cursor = Cursors.Hand;
            buttonClearGrade.FlatStyle = FlatStyle.Flat;
            buttonClearGrade.ForeColor = Color.White;
            buttonClearGrade.Location = new Point(149, 356);
            buttonClearGrade.Name = "buttonClearGrade";
            buttonClearGrade.Size = new Size(75, 23);
            buttonClearGrade.TabIndex = 12;
            buttonClearGrade.Text = "Notīrīt";
            buttonClearGrade.UseVisualStyleBackColor = false;
            buttonClearGrade.Click += buttonClearGrade_Click;
            // 
            // comboGradeSubject
            // 
            comboGradeSubject.Anchor = AnchorStyles.None;
            comboGradeSubject.DropDownWidth = 400;
            comboGradeSubject.FormattingEnabled = true;
            comboGradeSubject.Location = new Point(126, 23);
            comboGradeSubject.Name = "comboGradeSubject";
            comboGradeSubject.Size = new Size(121, 23);
            comboGradeSubject.TabIndex = 2;
            // 
            // buttonSaveGrade
            // 
            buttonSaveGrade.Anchor = AnchorStyles.None;
            buttonSaveGrade.BackColor = Color.Teal;
            buttonSaveGrade.Cursor = Cursors.Hand;
            buttonSaveGrade.FlatStyle = FlatStyle.Flat;
            buttonSaveGrade.ForeColor = Color.White;
            buttonSaveGrade.Location = new Point(23, 356);
            buttonSaveGrade.Name = "buttonSaveGrade";
            buttonSaveGrade.Size = new Size(75, 23);
            buttonSaveGrade.TabIndex = 11;
            buttonSaveGrade.Text = "Saglabāt";
            buttonSaveGrade.UseVisualStyleBackColor = false;
            buttonSaveGrade.Click += buttonSaveGrade_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(38, 96);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 3;
            label4.Text = "Atzīme";
            // 
            // textGradeComment
            // 
            textGradeComment.Anchor = AnchorStyles.None;
            textGradeComment.Location = new Point(126, 299);
            textGradeComment.Name = "textGradeComment";
            textGradeComment.Size = new Size(121, 23);
            textGradeComment.TabIndex = 10;
            // 
            // numericGradeValue
            // 
            numericGradeValue.Anchor = AnchorStyles.None;
            numericGradeValue.Location = new Point(126, 92);
            numericGradeValue.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericGradeValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericGradeValue.Name = "numericGradeValue";
            numericGradeValue.Size = new Size(120, 23);
            numericGradeValue.TabIndex = 4;
            numericGradeValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(28, 303);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 9;
            label7.Text = "Komentārs";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(43, 165);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 5;
            label5.Text = "Veids";
            // 
            // comboGradeType
            // 
            comboGradeType.Anchor = AnchorStyles.None;
            comboGradeType.FormattingEnabled = true;
            comboGradeType.Location = new Point(126, 161);
            comboGradeType.Name = "comboGradeType";
            comboGradeType.Size = new Size(121, 23);
            comboGradeType.TabIndex = 6;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(36, 234);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 7;
            label6.Text = "Datums";
            // 
            // dateTimeGradeDate
            // 
            dateTimeGradeDate.Anchor = AnchorStyles.None;
            dateTimeGradeDate.Location = new Point(125, 230);
            dateTimeGradeDate.Name = "dateTimeGradeDate";
            dateTimeGradeDate.Size = new Size(122, 23);
            dateTimeGradeDate.TabIndex = 8;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(23, 27);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 1;
            label3.Text = "Studiju kurss";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 13);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 0;
            label2.Text = "Pievienot / Labot atzīmi";
            // 
            // SubjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "SubjectForm";
            Padding = new Padding(10);
            Text = "SubjectForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridSubjects).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridGrades).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericGradeValue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private SplitContainer splitContainer2;
        private DataGridView dataGridSubjects;
        private Label labelGradesTitle;
        private Button buttonDeleteSubject;
        private Button buttonAddSubject;
        private Button buttonEditSubject;
        private Panel panel3;
        private Button buttonDeleteGrade;
        private DataGridView dataGridGrades;
        private Panel panel2;
        private Label label2;
        private TextBox textGradeComment;
        private Label label7;
        private DateTimePicker dateTimeGradeDate;
        private Label label6;
        private ComboBox comboGradeType;
        private Label label5;
        private NumericUpDown numericGradeValue;
        private Label label4;
        private ComboBox comboGradeSubject;
        private Label label3;
        private Button buttonClearGrade;
        private Button buttonSaveGrade;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}