using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentDiary.Data;

namespace StudentDiary.UI.Forms
{
    public partial class MainForm : Form // Galvenā forma, navigācija un panelis kurā atvērtas pārsejas formas
    {
        private Form currentForm; // Pašreizējā atvērtā forma panelContent iekšienē

        public MainForm() // Inicializē galveno formu
        {
            InitializeComponent();

            DatabaseCreation.Initialize();
            OpenForm(new ScheduleForm());
        }


        private void OpenForm(Form form) // Atver norādīto formu galvenā loga panelContent iekšienē
        {
            if (currentForm != null)
                currentForm.Close();

            currentForm = form;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelContent.Controls.Clear();
            panelContent.Controls.Add(form);
            form.Show();
        }

        // Izvēlnes punkti - katrs atver savu formu


        private void sarakstssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new ScheduleForm());
        }

        private void uzdevumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new HomeworkForm());
        }

        private void termiņiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new DeadlinesForm());
        }

        private void piezīmesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new NotesForm());
        }

        private void pasniedzējiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new TeachersForm());
        }

        private void statistikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new StatisticsForm());
        }

        private void studijuKursiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new SubjectForm());
        }
    }
}
