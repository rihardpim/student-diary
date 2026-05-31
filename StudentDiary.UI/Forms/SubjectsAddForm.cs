using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using StudentDiary.Core.Models;
using StudentDiary.Data;

namespace StudentDiary.UI.Forms
{
    public partial class SubjectsAddForm : Form // Forma studiju kursa pievienošanai un rediģēšanai
    {
        public Subject Subject { get; private set; }  // Studiju kursu objekts ar datiem (tikai lasīšana ārpus)
        public SubjectsAddForm() // Konstruktors jauna studiju kursa pievienošanai
        {
            InitializeComponent();
            this.Text = "Pievienot studiju kursu";
            Subject = new Subject();

            LoadTeachers();
        }

        public SubjectsAddForm(Subject subject) // Konstruktors esošā studiju kursa rediģēšanai
        {
            InitializeComponent();
            this.Text = "Labot studiju kursu";
            Subject = subject;

            LoadTeachers();

            textCode.Text = subject.Code;
            textName.Text = subject.Name;
            numericKp.Value = subject.CreditPoints;
            numericEcts.Value = subject.Ects;
            numericSemester.Value = subject.Semester;

            comboPart.SelectedItem = subject.Part;

            foreach (ComboBoxItem item in comboTeacher.Items)
            {
                if (item.Id == subject.TeacherId)
                {
                    comboTeacher.SelectedItem = item;
                    break;
                }
            }
        }

        private void LoadTeachers() // Ielādē pasniedzēju sarakstu no datu bāzes
        {
            comboTeacher.Items.Clear();

            comboTeacher.Items.Add(new ComboBoxItem
            {
                Id = 0,
                Name = "Nav"
            });

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, FullName FROM Teachers ORDER BY FullName";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboTeacher.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["FullName"].ToString()!
                });
            }

            comboTeacher.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e) // saglabā priekšmetu un aizver formu
        {
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Ievadiet priekšmeta nosaukumu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var teacher = (ComboBoxItem)comboTeacher.SelectedItem;

            Subject.Code = textCode.Text.Trim();
            Subject.Name = textName.Text.Trim();
            Subject.Part = comboPart.SelectedItem?.ToString() ?? "A";
            Subject.CreditPoints = (int)numericKp.Value;
            Subject.Ects = (int)numericEcts.Value;
            Subject.Semester = (int)numericSemester.Value;
            Subject.TeacherId = teacher.Id == 0 ? null : teacher.Id;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) // Atcel darbību un aizver formu
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}