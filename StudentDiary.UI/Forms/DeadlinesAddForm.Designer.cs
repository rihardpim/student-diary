namespace StudentDiary.UI.Forms
{
    partial class DeadlinesAddForm
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
            buttonCancel = new Button();
            buttonSave = new Button();
            textDescription = new TextBox();
            textTitle = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimeDate = new DateTimePicker();
            comboType = new ComboBox();
            comboSubject = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.DarkCyan;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(90, 211);
            buttonCancel.Margin = new Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 37;
            buttonCancel.Text = "Atcelt";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.DarkCyan;
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(4, 211);
            buttonSave.Margin = new Padding(4, 3, 4, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(78, 23);
            buttonSave.TabIndex = 36;
            buttonSave.Text = "Saglabāt";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // textDescription
            // 
            textDescription.Location = new Point(90, 32);
            textDescription.Margin = new Padding(4, 3, 4, 3);
            textDescription.Multiline = true;
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(231, 86);
            textDescription.TabIndex = 30;
            // 
            // textTitle
            // 
            textTitle.Location = new Point(90, 3);
            textTitle.Margin = new Padding(4, 3, 4, 3);
            textTitle.Name = "textTitle";
            textTitle.Size = new Size(152, 23);
            textTitle.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 179);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 26;
            label5.Text = "Studiju kurss";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 150);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 25;
            label4.Text = "Veids";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 121);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 24;
            label3.Text = "Datums";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 29);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 23;
            label2.Text = "Apraksts";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 22;
            label1.Text = "Nosaukums";
            // 
            // dateTimeDate
            // 
            dateTimeDate.Location = new Point(90, 124);
            dateTimeDate.Margin = new Padding(4, 3, 4, 3);
            dateTimeDate.Name = "dateTimeDate";
            dateTimeDate.Size = new Size(200, 23);
            dateTimeDate.TabIndex = 38;
            // 
            // comboType
            // 
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(90, 153);
            comboType.Margin = new Padding(4, 3, 4, 3);
            comboType.Name = "comboType";
            comboType.Size = new Size(169, 23);
            comboType.TabIndex = 39;
            // 
            // comboSubject
            // 
            comboSubject.DropDownWidth = 400;
            comboSubject.FormattingEnabled = true;
            comboSubject.Location = new Point(90, 182);
            comboSubject.Margin = new Padding(4, 3, 4, 3);
            comboSubject.Name = "comboSubject";
            comboSubject.Size = new Size(169, 23);
            comboSubject.TabIndex = 40;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(textTitle, 1, 0);
            tableLayoutPanel1.Controls.Add(comboSubject, 1, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(comboType, 1, 3);
            tableLayoutPanel1.Controls.Add(textDescription, 1, 1);
            tableLayoutPanel1.Controls.Add(dateTimeDate, 1, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 6);
            tableLayoutPanel1.Controls.Add(buttonSave, 0, 6);
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(370, 260);
            tableLayoutPanel1.TabIndex = 41;
            // 
            // DeadlinesAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            CancelButton = buttonCancel;
            ClientSize = new Size(342, 250);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "DeadlinesAddForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "DeadlinesAddForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private TextBox textDescription;
        private TextBox textTitle;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimeDate;
        private ComboBox comboType;
        private ComboBox comboSubject;
        private TableLayoutPanel tableLayoutPanel1;
    }
}