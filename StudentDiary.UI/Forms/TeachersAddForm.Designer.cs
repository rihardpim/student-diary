namespace StudentDiary.UI.Forms
{
    partial class TeachersAddForm
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
            textFullName = new TextBox();
            textPhone = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textEmail = new TextBox();
            textClassroom = new TextBox();
            label4 = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            label1.Margin = new Padding(10);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Vārds, uzvārds";
            // 
            // textFullName
            // 
            textFullName.Location = new Point(113, 10);
            textFullName.Margin = new Padding(10);
            textFullName.Name = "textFullName";
            textFullName.Size = new Size(125, 23);
            textFullName.TabIndex = 1;
            // 
            // textPhone
            // 
            textPhone.Location = new Point(113, 96);
            textPhone.Margin = new Padding(10);
            textPhone.Name = "textPhone";
            textPhone.Size = new Size(125, 23);
            textPhone.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 96);
            label2.Margin = new Padding(10);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 2;
            label2.Text = "Tālrunis";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 53);
            label3.Margin = new Padding(10);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 2;
            label3.Text = "Emai";
            // 
            // textEmail
            // 
            textEmail.Location = new Point(113, 53);
            textEmail.Margin = new Padding(10);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(125, 23);
            textEmail.TabIndex = 3;
            // 
            // textClassroom
            // 
            textClassroom.Location = new Point(113, 139);
            textClassroom.Margin = new Padding(10);
            textClassroom.Name = "textClassroom";
            textClassroom.Size = new Size(125, 23);
            textClassroom.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Azure;
            label4.Location = new Point(10, 139);
            label4.Margin = new Padding(10);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 4;
            label4.Text = "Auditorija";
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.Teal;
            buttonSave.Cursor = Cursors.Hand;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(10, 182);
            buttonSave.Margin = new Padding(10);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Saglabāt";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.Teal;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(113, 182);
            buttonCancel.Margin = new Padding(10);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Atcelt";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonCancel, 1, 4);
            tableLayoutPanel1.Controls.Add(textFullName, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonSave, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(textClassroom, 1, 3);
            tableLayoutPanel1.Controls.Add(textEmail, 1, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(textPhone, 1, 2);
            tableLayoutPanel1.Location = new Point(12, 21);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(256, 217);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // TeachersAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            CancelButton = buttonCancel;
            ClientSize = new Size(286, 249);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TeachersAddForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "TeachersAddForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox textFullName;
        private TextBox textPhone;
        private Label label2;
        private Label label3;
        private TextBox textEmail;
        private TextBox textClassroom;
        private Label label4;
        private Button buttonSave;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}