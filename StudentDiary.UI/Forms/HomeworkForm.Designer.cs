namespace StudentDiary.UI.Forms
{
    partial class HomeworkForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            label1 = new Label();
            buttonToday = new Button();
            comboSubject = new ComboBox();
            buttonPrev = new Button();
            labelWeek = new Label();
            buttonNext = new Button();
            dataGridView1 = new DataGridView();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 50);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(button1, 6, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonToday, 5, 0);
            tableLayoutPanel1.Controls.Add(comboSubject, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonPrev, 2, 0);
            tableLayoutPanel1.Controls.Add(labelWeek, 3, 0);
            tableLayoutPanel1.Controls.Add(buttonNext, 4, 0);
            tableLayoutPanel1.Location = new Point(-10, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 50);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Teal;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(576, 13);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Pievienot";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonAdd_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(3, 17);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Studiju kurss";
            // 
            // buttonToday
            // 
            buttonToday.Anchor = AnchorStyles.None;
            buttonToday.BackColor = Color.Teal;
            buttonToday.Cursor = Cursors.Hand;
            buttonToday.FlatAppearance.BorderSize = 0;
            buttonToday.FlatStyle = FlatStyle.Flat;
            buttonToday.ForeColor = Color.White;
            buttonToday.Location = new Point(350, 13);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new Size(75, 23);
            buttonToday.TabIndex = 5;
            buttonToday.Text = "Šodien";
            buttonToday.UseVisualStyleBackColor = false;
            buttonToday.Click += buttonToday_Click;
            // 
            // comboSubject
            // 
            comboSubject.Anchor = AnchorStyles.None;
            comboSubject.DropDownHeight = 400;
            comboSubject.DropDownWidth = 400;
            comboSubject.FormattingEnabled = true;
            comboSubject.IntegralHeight = false;
            comboSubject.Location = new Point(84, 13);
            comboSubject.Name = "comboSubject";
            comboSubject.Size = new Size(121, 23);
            comboSubject.TabIndex = 1;
            comboSubject.SelectedIndexChanged += comboSubject_SelectedIndexChanged;
            // 
            // buttonPrev
            // 
            buttonPrev.Anchor = AnchorStyles.None;
            buttonPrev.BackColor = Color.Teal;
            buttonPrev.Cursor = Cursors.Hand;
            buttonPrev.FlatAppearance.BorderSize = 0;
            buttonPrev.FlatStyle = FlatStyle.Flat;
            buttonPrev.ForeColor = Color.White;
            buttonPrev.Location = new Point(211, 13);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(24, 23);
            buttonPrev.TabIndex = 2;
            buttonPrev.Text = "◄";
            buttonPrev.UseVisualStyleBackColor = false;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // labelWeek
            // 
            labelWeek.Anchor = AnchorStyles.None;
            labelWeek.AutoSize = true;
            labelWeek.Location = new Point(241, 17);
            labelWeek.Name = "labelWeek";
            labelWeek.Size = new Size(73, 15);
            labelWeek.TabIndex = 4;
            labelWeek.Text = "12.34- 12.34";
            // 
            // buttonNext
            // 
            buttonNext.Anchor = AnchorStyles.None;
            buttonNext.BackColor = Color.Teal;
            buttonNext.Cursor = Cursors.Hand;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.ForeColor = Color.White;
            buttonNext.Location = new Point(320, 13);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(24, 23);
            buttonNext.TabIndex = 3;
            buttonNext.Text = "►";
            buttonNext.UseVisualStyleBackColor = false;
            buttonNext.Click += buttonNext_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.Gainsboro;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(10, 60);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 100;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(780, 380);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            // 
            // HomeworkForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "HomeworkForm";
            Padding = new Padding(10);
            Text = "HomeworkForm";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox comboSubject;
        private Button button1;
        private Button buttonToday;
        private Label labelWeek;
        private Button buttonNext;
        private Button buttonPrev;
        private DataGridView dataGridView1;
        private ToolTip toolTip1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}