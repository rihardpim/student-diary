namespace StudentDiary.UI.Forms
{
    partial class NotesForm
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
            panel1 = new Panel();
            listNotes = new ListBox();
            textSearch = new TextBox();
            panel2 = new Panel();
            textContent = new TextBox();
            textTags = new TextBox();
            textTitle = new TextBox();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonNew = new Button();
            labelDate = new Label();
            buttonSave = new Button();
            buttonDelete = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(listNotes);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 430);
            panel1.TabIndex = 0;
            // 
            // listNotes
            // 
            listNotes.BackColor = SystemColors.Menu;
            listNotes.Dock = DockStyle.Fill;
            listNotes.DrawMode = DrawMode.OwnerDrawFixed;
            listNotes.FormattingEnabled = true;
            listNotes.ItemHeight = 35;
            listNotes.Location = new Point(0, 0);
            listNotes.Name = "listNotes";
            listNotes.Size = new Size(250, 430);
            listNotes.TabIndex = 1;
            listNotes.DrawItem += listNotes_DrawItem;
            listNotes.SelectedIndexChanged += listNotes_SelectedIndexChanged;
            // 
            // textSearch
            // 
            textSearch.Location = new Point(215, 32);
            textSearch.Name = "textSearch";
            textSearch.PlaceholderText = "Meklēt...";
            textSearch.Size = new Size(100, 23);
            textSearch.TabIndex = 0;
            textSearch.TextChanged += textSearch_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(textContent);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(260, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(530, 363);
            panel2.TabIndex = 1;
            // 
            // textContent
            // 
            textContent.BackColor = Color.Snow;
            textContent.Dock = DockStyle.Fill;
            textContent.Location = new Point(0, 0);
            textContent.Multiline = true;
            textContent.Name = "textContent";
            textContent.Size = new Size(530, 363);
            textContent.TabIndex = 1;
            // 
            // textTags
            // 
            textTags.Location = new Point(109, 32);
            textTags.Name = "textTags";
            textTags.PlaceholderText = "Tags...";
            textTags.Size = new Size(100, 23);
            textTags.TabIndex = 2;
            // 
            // textTitle
            // 
            textTitle.Location = new Point(3, 32);
            textTitle.Name = "textTitle";
            textTitle.PlaceholderText = "Virsraksts...";
            textTitle.Size = new Size(100, 23);
            textTitle.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Azure;
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(260, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(530, 67);
            panel3.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(buttonNew, 0, 0);
            tableLayoutPanel1.Controls.Add(labelDate, 3, 0);
            tableLayoutPanel1.Controls.Add(textSearch, 2, 1);
            tableLayoutPanel1.Controls.Add(buttonSave, 1, 0);
            tableLayoutPanel1.Controls.Add(textTags, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonDelete, 2, 0);
            tableLayoutPanel1.Controls.Add(textTitle, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(530, 67);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // buttonNew
            // 
            buttonNew.BackColor = Color.Teal;
            buttonNew.Cursor = Cursors.Hand;
            buttonNew.FlatAppearance.BorderSize = 0;
            buttonNew.FlatStyle = FlatStyle.Flat;
            buttonNew.ForeColor = Color.White;
            buttonNew.Location = new Point(3, 3);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(75, 23);
            buttonNew.TabIndex = 6;
            buttonNew.Text = "Jauna";
            buttonNew.UseVisualStyleBackColor = false;
            buttonNew.Click += buttonNew_Click;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(321, 0);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(0, 15);
            labelDate.TabIndex = 9;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Teal;
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(109, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Saglabāt";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.Teal;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(215, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Dzēst";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // NotesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "NotesForm";
            Padding = new Padding(10);
            Text = "Piezīmes";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListBox listNotes;
        private TextBox textSearch;
        private Panel panel2;
        private TextBox textTags;
        private TextBox textContent;
        private TextBox textTitle;
        private Panel panel3;
        private Label labelDate;
        private Button buttonDelete;
        private Button buttonNew;
        private Button buttonSave;
        private TableLayoutPanel tableLayoutPanel1;
    }
}