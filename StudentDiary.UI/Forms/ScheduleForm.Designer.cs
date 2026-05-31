namespace StudentDiary.UI.Forms
{
    partial class ScheduleForm
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
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonAdd = new Button();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonPrevWeek = new Button();
            buttonToday = new Button();
            labelWeek = new Label();
            buttonNextWeek = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.Gainsboro;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(10, 60);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(780, 330);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(10, 390);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 50);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Location = new Point(-7, 15);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(241, 100);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.None;
            buttonEdit.BackColor = Color.Teal;
            buttonEdit.Cursor = Cursors.Hand;
            buttonEdit.FlatAppearance.BorderSize = 0;
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.ForeColor = Color.White;
            buttonEdit.Location = new Point(338, 13);
            buttonEdit.Margin = new Padding(10);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 4;
            buttonEdit.Text = "Labot";
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Left;
            buttonDelete.BackColor = Color.Teal;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(433, 13);
            buttonDelete.Margin = new Padding(10);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Dzēst";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.None;
            buttonAdd.BackColor = Color.Teal;
            buttonAdd.Cursor = Cursors.Hand;
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(243, 13);
            buttonAdd.Margin = new Padding(10);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Pievienot";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Azure;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(10, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(780, 50);
            panel2.TabIndex = 7;
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
            tableLayoutPanel1.Controls.Add(buttonDelete, 6, 0);
            tableLayoutPanel1.Controls.Add(buttonEdit, 5, 0);
            tableLayoutPanel1.Controls.Add(buttonPrevWeek, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonToday, 3, 0);
            tableLayoutPanel1.Controls.Add(buttonAdd, 4, 0);
            tableLayoutPanel1.Controls.Add(labelWeek, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonNextWeek, 2, 0);
            tableLayoutPanel1.Location = new Point(-10, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 50);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonPrevWeek
            // 
            buttonPrevWeek.Anchor = AnchorStyles.None;
            buttonPrevWeek.BackColor = Color.Teal;
            buttonPrevWeek.Cursor = Cursors.Hand;
            buttonPrevWeek.FlatAppearance.BorderSize = 0;
            buttonPrevWeek.FlatStyle = FlatStyle.Flat;
            buttonPrevWeek.ForeColor = Color.White;
            buttonPrevWeek.Location = new Point(10, 13);
            buttonPrevWeek.Margin = new Padding(10);
            buttonPrevWeek.Name = "buttonPrevWeek";
            buttonPrevWeek.Size = new Size(22, 23);
            buttonPrevWeek.TabIndex = 1;
            buttonPrevWeek.Text = "◄";
            buttonPrevWeek.UseVisualStyleBackColor = false;
            buttonPrevWeek.Click += buttonPrevWeek_Click;
            // 
            // buttonToday
            // 
            buttonToday.Anchor = AnchorStyles.None;
            buttonToday.BackColor = Color.Teal;
            buttonToday.Cursor = Cursors.Hand;
            buttonToday.FlatAppearance.BorderSize = 0;
            buttonToday.FlatStyle = FlatStyle.Flat;
            buttonToday.ForeColor = Color.White;
            buttonToday.Location = new Point(154, 13);
            buttonToday.Margin = new Padding(10);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new Size(69, 23);
            buttonToday.TabIndex = 2;
            buttonToday.Text = "Šodien";
            buttonToday.UseVisualStyleBackColor = false;
            buttonToday.Click += buttonToday_Click;
            // 
            // labelWeek
            // 
            labelWeek.Anchor = AnchorStyles.None;
            labelWeek.AutoSize = true;
            labelWeek.Location = new Point(52, 17);
            labelWeek.Margin = new Padding(10);
            labelWeek.Name = "labelWeek";
            labelWeek.Size = new Size(37, 15);
            labelWeek.TabIndex = 3;
            labelWeek.Text = "label1";
            // 
            // buttonNextWeek
            // 
            buttonNextWeek.Anchor = AnchorStyles.None;
            buttonNextWeek.BackColor = Color.Teal;
            buttonNextWeek.Cursor = Cursors.Hand;
            buttonNextWeek.FlatAppearance.BorderSize = 0;
            buttonNextWeek.FlatStyle = FlatStyle.Flat;
            buttonNextWeek.ForeColor = Color.White;
            buttonNextWeek.Location = new Point(109, 13);
            buttonNextWeek.Margin = new Padding(10);
            buttonNextWeek.Name = "buttonNextWeek";
            buttonNextWeek.Size = new Size(25, 23);
            buttonNextWeek.TabIndex = 0;
            buttonNextWeek.Text = "►";
            buttonNextWeek.UseVisualStyleBackColor = false;
            buttonNextWeek.Click += buttonNextWeek_Click;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "ScheduleForm";
            Padding = new Padding(10);
            Text = "ScheduleForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonAdd;
        private Panel panel2;
        private Button buttonToday;
        private Button buttonPrevWeek;
        private Button buttonNextWeek;
        private Label labelWeek;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}