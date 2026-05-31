namespace StudentDiary.UI.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            sarakstssToolStripMenuItem = new ToolStripMenuItem();
            uzdevumiToolStripMenuItem = new ToolStripMenuItem();
            studijuKursiToolStripMenuItem = new ToolStripMenuItem();
            termiņiToolStripMenuItem = new ToolStripMenuItem();
            piezīmesToolStripMenuItem = new ToolStripMenuItem();
            pasniedzējiToolStripMenuItem = new ToolStripMenuItem();
            statistikaToolStripMenuItem = new ToolStripMenuItem();
            panelContent = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sarakstssToolStripMenuItem, uzdevumiToolStripMenuItem, studijuKursiToolStripMenuItem, termiņiToolStripMenuItem, piezīmesToolStripMenuItem, pasniedzējiToolStripMenuItem, statistikaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // sarakstssToolStripMenuItem
            // 
            sarakstssToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            sarakstssToolStripMenuItem.Name = "sarakstssToolStripMenuItem";
            sarakstssToolStripMenuItem.Size = new Size(62, 20);
            sarakstssToolStripMenuItem.Text = "Saraksts";
            sarakstssToolStripMenuItem.Click += sarakstssToolStripMenuItem_Click;
            // 
            // uzdevumiToolStripMenuItem
            // 
            uzdevumiToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            uzdevumiToolStripMenuItem.Name = "uzdevumiToolStripMenuItem";
            uzdevumiToolStripMenuItem.Size = new Size(73, 20);
            uzdevumiToolStripMenuItem.Text = "Uzdevumi";
            uzdevumiToolStripMenuItem.Click += uzdevumiToolStripMenuItem_Click;
            // 
            // studijuKursiToolStripMenuItem
            // 
            studijuKursiToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            studijuKursiToolStripMenuItem.Name = "studijuKursiToolStripMenuItem";
            studijuKursiToolStripMenuItem.Size = new Size(85, 20);
            studijuKursiToolStripMenuItem.Text = "Studiju kursi";
            studijuKursiToolStripMenuItem.Click += studijuKursiToolStripMenuItem_Click;
            // 
            // termiņiToolStripMenuItem
            // 
            termiņiToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            termiņiToolStripMenuItem.Name = "termiņiToolStripMenuItem";
            termiņiToolStripMenuItem.Size = new Size(59, 20);
            termiņiToolStripMenuItem.Text = "Termiņi";
            termiņiToolStripMenuItem.Click += termiņiToolStripMenuItem_Click;
            // 
            // piezīmesToolStripMenuItem
            // 
            piezīmesToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            piezīmesToolStripMenuItem.Name = "piezīmesToolStripMenuItem";
            piezīmesToolStripMenuItem.Size = new Size(66, 20);
            piezīmesToolStripMenuItem.Text = "Piezīmes";
            piezīmesToolStripMenuItem.Click += piezīmesToolStripMenuItem_Click;
            // 
            // pasniedzējiToolStripMenuItem
            // 
            pasniedzējiToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            pasniedzējiToolStripMenuItem.Name = "pasniedzējiToolStripMenuItem";
            pasniedzējiToolStripMenuItem.Size = new Size(78, 20);
            pasniedzējiToolStripMenuItem.Text = "Pasniedzēji";
            pasniedzējiToolStripMenuItem.Click += pasniedzējiToolStripMenuItem_Click;
            // 
            // statistikaToolStripMenuItem
            // 
            statistikaToolStripMenuItem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            statistikaToolStripMenuItem.Name = "statistikaToolStripMenuItem";
            statistikaToolStripMenuItem.Size = new Size(67, 20);
            statistikaToolStripMenuItem.Text = "Statistika";
            statistikaToolStripMenuItem.Click += statistikaToolStripMenuItem_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 24);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(800, 426);
            panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContent);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Studenta dienasgrāmata";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem sarakstssToolStripMenuItem;
        private ToolStripMenuItem uzdevumiToolStripMenuItem;
        private ToolStripMenuItem termiņiToolStripMenuItem;
        private ToolStripMenuItem piezīmesToolStripMenuItem;
        private ToolStripMenuItem pasniedzējiToolStripMenuItem;
        private ToolStripMenuItem statistikaToolStripMenuItem;
        private Panel panelContent;
        private ToolStripMenuItem studijuKursiToolStripMenuItem;
    }
}