namespace StudentDiary.UI.Forms
{
    partial class ScheduleAddForm
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
            comboGroups = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboStartTime = new ComboBox();
            textEndTime = new TextBox();
            comboSubject = new ComboBox();
            comboType = new ComboBox();
            textRoom = new TextBox();
            comboWeek = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            radioRecurring = new RadioButton();
            radioSingle = new RadioButton();
            panelRecurring = new Panel();
            comboDay = new ComboBox();
            label10 = new Label();
            panelSingle = new Panel();
            dateTimeDate = new DateTimePicker();
            label11 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            panelRecurring.SuspendLayout();
            panelSingle.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(475, 370);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 37;
            buttonCancel.Text = "Atcelt";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(394, 370);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 36;
            buttonSave.Text = "Saglabāt";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // comboGroups
            // 
            comboGroups.Anchor = AnchorStyles.None;
            comboGroups.FormattingEnabled = true;
            comboGroups.Location = new Point(190, 341);
            comboGroups.Name = "comboGroups";
            comboGroups.Size = new Size(96, 23);
            comboGroups.TabIndex = 35;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(26, 345);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 28;
            label7.Text = "Grupa";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(28, 316);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 27;
            label6.Text = "Telpa";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(28, 287);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 26;
            label5.Text = "Veids";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(8, 258);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 25;
            label4.Text = "Studiju kurss";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(411, 229);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 24;
            label3.Text = "Beigas";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(21, 229);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 23;
            label2.Text = "Sākums";
            // 
            // comboStartTime
            // 
            comboStartTime.Anchor = AnchorStyles.None;
            comboStartTime.FormattingEnabled = true;
            comboStartTime.Location = new Point(187, 225);
            comboStartTime.Name = "comboStartTime";
            comboStartTime.Size = new Size(102, 23);
            comboStartTime.TabIndex = 39;
            comboStartTime.SelectedIndexChanged += comboStartTime_SelectedIndexChanged;
            // 
            // textEndTime
            // 
            textEndTime.Anchor = AnchorStyles.None;
            textEndTime.Location = new Point(475, 225);
            textEndTime.Name = "textEndTime";
            textEndTime.ReadOnly = true;
            textEndTime.Size = new Size(100, 23);
            textEndTime.TabIndex = 40;
            // 
            // comboSubject
            // 
            comboSubject.Anchor = AnchorStyles.None;
            comboSubject.FormattingEnabled = true;
            comboSubject.Location = new Point(187, 254);
            comboSubject.Name = "comboSubject";
            comboSubject.Size = new Size(102, 23);
            comboSubject.TabIndex = 41;
            // 
            // comboType
            // 
            comboType.Anchor = AnchorStyles.None;
            comboType.FormattingEnabled = true;
            comboType.Location = new Point(187, 283);
            comboType.Name = "comboType";
            comboType.Size = new Size(102, 23);
            comboType.TabIndex = 42;
            // 
            // textRoom
            // 
            textRoom.Anchor = AnchorStyles.None;
            textRoom.Location = new Point(188, 312);
            textRoom.Name = "textRoom";
            textRoom.Size = new Size(100, 23);
            textRoom.TabIndex = 43;
            // 
            // comboWeek
            // 
            comboWeek.FormattingEnabled = true;
            comboWeek.Location = new Point(65, 47);
            comboWeek.Name = "comboWeek";
            comboWeek.Size = new Size(96, 23);
            comboWeek.TabIndex = 45;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 52);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 44;
            label8.Text = "Nedēļa";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Location = new Point(28, 34);
            label9.Name = "label9";
            label9.Size = new Size(35, 15);
            label9.TabIndex = 46;
            label9.Text = "Veids";
            // 
            // radioRecurring
            // 
            radioRecurring.AutoSize = true;
            radioRecurring.Checked = true;
            radioRecurring.Location = new Point(6, 14);
            radioRecurring.Name = "radioRecurring";
            radioRecurring.Size = new Size(165, 19);
            radioRecurring.TabIndex = 47;
            radioRecurring.TabStop = true;
            radioRecurring.Text = "Katru nedēļu / pēc nedēļas";
            radioRecurring.UseVisualStyleBackColor = true;
            radioRecurring.CheckedChanged += radiobRecurring_CheckedChanged;
            // 
            // radioSingle
            // 
            radioSingle.AutoSize = true;
            radioSingle.Location = new Point(6, 39);
            radioSingle.Name = "radioSingle";
            radioSingle.Size = new Size(82, 19);
            radioSingle.TabIndex = 48;
            radioSingle.Text = "Vienreizējs";
            radioSingle.UseVisualStyleBackColor = true;
            radioSingle.CheckedChanged += radioSingle_CheckedChanged;
            // 
            // panelRecurring
            // 
            panelRecurring.Anchor = AnchorStyles.None;
            panelRecurring.Controls.Add(comboDay);
            panelRecurring.Controls.Add(label10);
            panelRecurring.Controls.Add(label8);
            panelRecurring.Controls.Add(comboWeek);
            panelRecurring.Location = new Point(141, 81);
            panelRecurring.Name = "panelRecurring";
            panelRecurring.Size = new Size(195, 88);
            panelRecurring.TabIndex = 49;
            // 
            // comboDay
            // 
            comboDay.FormattingEnabled = true;
            comboDay.Location = new Point(65, 4);
            comboDay.Name = "comboDay";
            comboDay.Size = new Size(96, 23);
            comboDay.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 12);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 0;
            label10.Text = "Dienas";
            // 
            // panelSingle
            // 
            panelSingle.Anchor = AnchorStyles.None;
            panelSingle.Controls.Add(dateTimeDate);
            panelSingle.Controls.Add(label11);
            panelSingle.Location = new Point(89, 175);
            panelSingle.Name = "panelSingle";
            panelSingle.Size = new Size(299, 44);
            panelSingle.TabIndex = 50;
            panelSingle.Visible = false;
            // 
            // dateTimeDate
            // 
            dateTimeDate.Location = new Point(89, 12);
            dateTimeDate.Name = "dateTimeDate";
            dateTimeDate.Size = new Size(200, 23);
            dateTimeDate.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 18);
            label11.Name = "label11";
            label11.Size = new Size(49, 15);
            label11.TabIndex = 0;
            label11.Text = "Datums";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(groupBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(comboGroups, 1, 7);
            tableLayoutPanel1.Controls.Add(textRoom, 1, 6);
            tableLayoutPanel1.Controls.Add(panelSingle, 1, 2);
            tableLayoutPanel1.Controls.Add(comboType, 1, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 0);
            tableLayoutPanel1.Controls.Add(comboSubject, 1, 4);
            tableLayoutPanel1.Controls.Add(textEndTime, 3, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(comboStartTime, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 2, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 5);
            tableLayoutPanel1.Controls.Add(label6, 0, 6);
            tableLayoutPanel1.Controls.Add(label7, 0, 7);
            tableLayoutPanel1.Controls.Add(panelRecurring, 1, 1);
            tableLayoutPanel1.Controls.Add(buttonCancel, 3, 8);
            tableLayoutPanel1.Controls.Add(buttonSave, 2, 8);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(5);
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(570, 732);
            tableLayoutPanel1.TabIndex = 51;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(radioRecurring);
            groupBox1.Controls.Add(radioSingle);
            groupBox1.Location = new Point(154, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(169, 67);
            groupBox1.TabIndex = 52;
            groupBox1.TabStop = false;
            // 
            // ScheduleAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            CancelButton = buttonCancel;
            ClientSize = new Size(594, 421);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MaximizeBox = false;
            Name = "ScheduleAddForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ScheduleAddForm";
            panelRecurring.ResumeLayout(false);
            panelRecurring.PerformLayout();
            panelSingle.ResumeLayout(false);
            panelSingle.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCancel;
        private Button buttonSave;
        private ComboBox comboGroups;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboStartTime;
        private TextBox textEndTime;
        private ComboBox comboSubject;
        private ComboBox comboType;
        private TextBox textRoom;
        private ComboBox comboWeek;
        private Label label8;
        private Label label9;
        private RadioButton radioRecurring;
        private RadioButton radioSingle;
        private Panel panelRecurring;
        private ComboBox comboDay;
        private Label label10;
        private Panel panelSingle;
        private Label label11;
        private DateTimePicker dateTimeDate;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
    }
}