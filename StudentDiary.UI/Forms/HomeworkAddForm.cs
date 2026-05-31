using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentDiary.UI.Forms.SubjectsAddForm;
using StudentDiary.Core.Models;
using StudentDiary.Data;

namespace StudentDiary.UI.Forms
{
    public partial class HomeworkAddForm : Form  // Forma mājas darbu pievienošanai un rediģēšanai
    {
        // Mājas darba objekts ar datiem (tikai lasīšana ārpus)
        public Homework Homework { get; private set; }


        public HomeworkAddForm() // jauna mājas darba pievienošanai konstruktors
        {
            InitializeComponent();
            this.Text = "Pievienot mājas darbu";
            Homework = new Homework();

            LoadSubjects();
            LoadPriorities();

            dateDueDate.Value = DateTime.Today;
            dateDueDate.MinDate = DateTime.Today;
        }
        public HomeworkAddForm(Homework homework) // esošā mājas darba rediģēšanas konstruktors
        {
            InitializeComponent();
            this.Text = "Labot mājas darbu";
            Homework = homework;

            LoadSubjects();
            LoadPriorities();

            textTitle.Text = homework.Title;
            textDescription.Text = homework.Description;
            dateDueDate.Value = homework.DueDate;
            comboPriority.SelectedIndex = (int)homework.Priority;

            foreach (ComboBoxItem item in comboSubject.Items)
            {
                if (item.Id == homework.SubjectId)
                {
                    comboSubject.SelectedItem = item;
                    break;
                }
            }
        }

        private void LoadSubjects() // Ielādē priekšmetu sarakstu no datu bāzes combobox
        {
            comboSubject.Items.Clear();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name FROM Subjects ORDER BY Name";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboSubject.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()
                });
            }

            if (comboSubject.Items.Count > 0)
                comboSubject.SelectedIndex = 0;
        }

        private void LoadPriorities() // Ielādē prioritāšu sarakstu combobox
        {
            comboPriority.Items.Clear();
            comboPriority.Items.Add("Zema");
            comboPriority.Items.Add("Vidēja");
            comboPriority.Items.Add("Augsta");
            comboPriority.SelectedIndex = 1;
        }

        private void buttonSave_Click(object sender, EventArgs e) // Saglabā mājas darbu un aizver formu
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                MessageBox.Show("Ievadiet nosaukumu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboSubject.SelectedItem == null)
            {
                MessageBox.Show("Izvēlieties priekšmetu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = (ComboBoxItem)comboSubject.SelectedItem;

            Homework.Title = textTitle.Text.Trim();
            Homework.Description = textDescription.Text.Trim();
            Homework.DueDate = dateDueDate.Value.Date;
            Homework.Priority = (HomeworkPriority)comboPriority.SelectedIndex;
            Homework.SubjectId = subject.Id;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) // Atcel un aizver formu
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}