namespace StudentDiary.UI.Forms
{
    partial class StatisticsForm
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
            labelTotalGrades = new Label();
            labelAvgGrade = new Label();
            tabControl1 = new TabControl();
            tabBar = new TabPage();
            tabLine = new TabPage();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(labelTotalGrades);
            panel1.Controls.Add(labelAvgGrade);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 120);
            panel1.TabIndex = 0;
            // 
            // labelTotalGrades
            // 
            labelTotalGrades.AutoSize = true;
            labelTotalGrades.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelTotalGrades.Location = new Point(58, 64);
            labelTotalGrades.Name = "labelTotalGrades";
            labelTotalGrades.Size = new Size(51, 21);
            labelTotalGrades.TabIndex = 1;
            labelTotalGrades.Text = "label1";
            // 
            // labelAvgGrade
            // 
            labelAvgGrade.AutoSize = true;
            labelAvgGrade.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelAvgGrade.Location = new Point(58, 30);
            labelAvgGrade.Name = "labelAvgGrade";
            labelAvgGrade.Size = new Size(51, 21);
            labelAvgGrade.TabIndex = 0;
            labelAvgGrade.Text = "label1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabBar);
            tabControl1.Controls.Add(tabLine);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(10, 130);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(780, 310);
            tabControl1.TabIndex = 1;
            // 
            // tabBar
            // 
            tabBar.Location = new Point(4, 24);
            tabBar.Name = "tabBar";
            tabBar.Padding = new Padding(3);
            tabBar.Size = new Size(772, 282);
            tabBar.TabIndex = 0;
            tabBar.Text = "Atzīmes";
            tabBar.UseVisualStyleBackColor = true;
            // 
            // tabLine
            // 
            tabLine.Location = new Point(4, 24);
            tabLine.Name = "tabLine";
            tabLine.Padding = new Padding(3);
            tabLine.Size = new Size(772, 282);
            tabLine.TabIndex = 1;
            tabLine.Text = "Dinamika";
            tabLine.UseVisualStyleBackColor = true;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Name = "StatisticsForm";
            Padding = new Padding(10);
            Text = "StatisticsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelAvgGrade;
        private Label labelTotalGrades;
        private TabControl tabControl1;
        private TabPage tabBar;
        private TabPage tabLine;
    }
}