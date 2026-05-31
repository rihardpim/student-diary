namespace StudentDiary.UI.Forms
{
    partial class ScheduleInfoForm
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
            labelCode = new Label();
            labelType = new Label();
            labelGroup = new Label();
            labelDay = new Label();
            labelWeek = new Label();
            labelRoom = new Label();
            labelTeacher = new Label();
            buttonCLose = new Button();
            buttonCancel = new Button();
            buttonReschedule = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCode.Location = new Point(13, 13);
            labelCode.Margin = new Padding(3);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(56, 21);
            labelCode.TabIndex = 0;
            labelCode.Text = "label1";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(13, 43);
            labelType.Margin = new Padding(3);
            labelType.Name = "labelType";
            labelType.Size = new Size(38, 15);
            labelType.TabIndex = 1;
            labelType.Text = "label1";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(13, 73);
            labelGroup.Margin = new Padding(3);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(38, 15);
            labelGroup.TabIndex = 2;
            labelGroup.Text = "label1";
            // 
            // labelDay
            // 
            labelDay.AutoSize = true;
            labelDay.Location = new Point(13, 103);
            labelDay.Margin = new Padding(3);
            labelDay.Name = "labelDay";
            labelDay.Size = new Size(38, 15);
            labelDay.TabIndex = 3;
            labelDay.Text = "label1";
            // 
            // labelWeek
            // 
            labelWeek.AutoSize = true;
            labelWeek.Location = new Point(13, 133);
            labelWeek.Margin = new Padding(3);
            labelWeek.Name = "labelWeek";
            labelWeek.Size = new Size(38, 15);
            labelWeek.TabIndex = 4;
            labelWeek.Text = "label1";
            // 
            // labelRoom
            // 
            labelRoom.AutoSize = true;
            labelRoom.Location = new Point(13, 163);
            labelRoom.Margin = new Padding(3);
            labelRoom.Name = "labelRoom";
            labelRoom.Size = new Size(38, 15);
            labelRoom.TabIndex = 5;
            labelRoom.Text = "label1";
            // 
            // labelTeacher
            // 
            labelTeacher.AutoSize = true;
            labelTeacher.Location = new Point(13, 193);
            labelTeacher.Margin = new Padding(3);
            labelTeacher.Name = "labelTeacher";
            labelTeacher.Size = new Size(38, 15);
            labelTeacher.TabIndex = 6;
            labelTeacher.Text = "label1";
            // 
            // buttonCLose
            // 
            buttonCLose.Anchor = AnchorStyles.Right;
            buttonCLose.BackColor = Color.Teal;
            buttonCLose.Cursor = Cursors.Hand;
            buttonCLose.FlatAppearance.BorderSize = 0;
            buttonCLose.FlatStyle = FlatStyle.Flat;
            buttonCLose.ForeColor = Color.White;
            buttonCLose.Location = new Point(183, 234);
            buttonCLose.Name = "buttonCLose";
            buttonCLose.Size = new Size(75, 23);
            buttonCLose.TabIndex = 7;
            buttonCLose.Text = "Aizvērt";
            buttonCLose.UseVisualStyleBackColor = false;
            buttonCLose.Click += buttonClose_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Right;
            buttonCancel.BackColor = Color.Teal;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Location = new Point(94, 234);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(72, 23);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Atcelt";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonReschedule
            // 
            buttonReschedule.Anchor = AnchorStyles.Right;
            buttonReschedule.BackColor = Color.Teal;
            buttonReschedule.Cursor = Cursors.Hand;
            buttonReschedule.FlatAppearance.BorderSize = 0;
            buttonReschedule.FlatStyle = FlatStyle.Flat;
            buttonReschedule.ForeColor = Color.White;
            buttonReschedule.Location = new Point(13, 234);
            buttonReschedule.Name = "buttonReschedule";
            buttonReschedule.Size = new Size(75, 23);
            buttonReschedule.TabIndex = 9;
            buttonReschedule.Text = "Pārcelt";
            buttonReschedule.UseVisualStyleBackColor = false;
            buttonReschedule.Click += buttonReschedule_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(buttonCLose, 3, 7);
            tableLayoutPanel1.Controls.Add(buttonCancel, 2, 7);
            tableLayoutPanel1.Controls.Add(buttonReschedule, 1, 7);
            tableLayoutPanel1.Controls.Add(labelCode, 1, 0);
            tableLayoutPanel1.Controls.Add(labelType, 1, 1);
            tableLayoutPanel1.Controls.Add(labelGroup, 1, 2);
            tableLayoutPanel1.Controls.Add(labelDay, 1, 3);
            tableLayoutPanel1.Controls.Add(labelWeek, 1, 4);
            tableLayoutPanel1.Controls.Add(labelRoom, 1, 5);
            tableLayoutPanel1.Controls.Add(labelTeacher, 1, 6);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            tableLayoutPanel1.Size = new Size(271, 281);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // ScheduleInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Azure;
            CancelButton = buttonCLose;
            ClientSize = new Size(524, 646);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ScheduleInfoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Informācija";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCode;
        private Label labelType;
        private Label labelGroup;
        private Label labelDay;
        private Label labelWeek;
        private Label labelRoom;
        private Label labelTeacher;
        private Button buttonCLose;
        private Button buttonCancel;
        private Button buttonReschedule;
        private TableLayoutPanel tableLayoutPanel1;
    }
}