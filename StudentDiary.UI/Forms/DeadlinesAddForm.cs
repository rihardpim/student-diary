using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudentDiary.UI.Forms.SubjectsAddForm;
using StudentDiary.Core.Models;
using StudentDiary.Data;

namespace StudentDiary.UI.Forms
{
    // Forma termiņu pievienošanai un rediģēšanai
    public partial class DeadlinesAddForm : Form
    {
        // Termiņa objekts ar datiem (tikai lasīšana ārpus)
        public Deadline Deadline { get; private set; }

        public DeadlinesAddForm() // Jauna termiņa pievienošanas konstruktors
        {
            InitializeComponent();
            this.Text = "Pievienot termiņu";
            Deadline = new Deadline();

            LoadTypes();
            LoadSubjects();

            dateTimeDate.Value = DateTime.Today;
        }

        public DeadlinesAddForm(Deadline deadline) // Esošā termiņa rediģēšanas konstruktors
        {
            InitializeComponent();
            this.Text = "Labot termiņu";
            Deadline = deadline;

            LoadTypes();
            LoadSubjects();

            textTitle.Text = deadline.Title;
            textDescription.Text = deadline.Description;
            dateTimeDate.Value = deadline.Date;
            comboType.SelectedIndex = (int)deadline.Type;

            if (deadline.SubjectId != null)
            {
                foreach (ComboBoxItem item in comboSubject.Items)
                {
                    if (item.Id == deadline.SubjectId.Value)
                    {
                        comboSubject.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void LoadTypes() // Ielādē termiņu veidus combobox
        {
            comboType.Items.Clear();
            comboType.Items.Add("Eksāmens");
            comboType.Items.Add("Kursa darbs");
            comboType.Items.Add("Laboratorijas darbs");
            comboType.Items.Add("Tests");
            comboType.Items.Add("Cits");
            comboType.SelectedIndex = 0;
        }

        private void LoadSubjects() // Ielādē priekšmetu sarakstu no datu bāzes
        {
            comboSubject.Items.Clear();

            comboSubject.Items.Add(new ComboBoxItem
            {
                Id = 0,
                Name = "Nav norādīts"
            });

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText =
                "SELECT Id, Name FROM Subjects ORDER BY Name";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboSubject.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()
                });
            }

            comboSubject.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e) // Saglabāt datus un aizver formu
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                MessageBox.Show("Ievadiet nosaukumu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = (ComboBoxItem)comboSubject.SelectedItem;

            Deadline.Title = textTitle.Text.Trim();
            Deadline.Description = textDescription.Text.Trim();
            Deadline.Date = dateTimeDate.Value.Date;
            Deadline.Type = (DeadlineType)comboType.SelectedIndex;
            Deadline.SubjectId = subject.Id == 0 ? null : subject.Id;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) // Atcelt un aizver formu
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}