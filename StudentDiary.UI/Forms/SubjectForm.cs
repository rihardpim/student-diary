using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using StudentDiary.Core.Models;
using StudentDiary.Data;
using static StudentDiary.UI.Forms.SubjectsAddForm;

namespace StudentDiary.UI.Forms
{
    public partial class SubjectForm : Form // Forma studiju kursu un atzīmju pārvaldībai
    {
        private int selectedSubjectId = -1; // Pašreizēji izvēlētā priekšmeta ID
        private int editingGradeId = -1; // Rediģējamās atzīmes ID

        private bool isLoading = false; // Novērš SelectionChanged notikumu rekursīvu izsaukšanu
                                        // datu ielādes laikā

        public SubjectForm() // Inicializē formu
        {
            InitializeComponent();

            SetupSubjectsGrid();
            SetupGradesGrid();
            LoadSubjectsComboBox();
            LoadGradeTypes();

            isLoading = true;
            try
            {
                LoadSubjects();
            }
            finally
            {
                isLoading = false;
            }

            dateTimeGradeDate.Value = DateTime.Today;
        }

        private void SetupSubjectsGrid() // Konfigurē priekšmetu tabulas kolonnas
        {
            dataGridSubjects.Columns.Clear();
            dataGridSubjects.Columns.Add("Number", "№");
            dataGridSubjects.Columns.Add("Code", "Kods");
            dataGridSubjects.Columns.Add("Name", "Nosaukums");
            dataGridSubjects.Columns.Add("Part", "Daļa");
            dataGridSubjects.Columns.Add("Credits", "KP");
            dataGridSubjects.Columns.Add("Ects", "ECTS");
            dataGridSubjects.Columns.Add("Teacher", "Pasniedzējs");
            dataGridSubjects.Columns.Add("Average", "Vidējā atzīme");

            dataGridSubjects.Columns["Number"].Width = 35;
            dataGridSubjects.Columns["Code"].Width = 100;
            dataGridSubjects.Columns["Name"].Width = 150;
            dataGridSubjects.Columns["Part"].Width = 45;
            dataGridSubjects.Columns["Credits"].Width = 45;
            dataGridSubjects.Columns["Ects"].Width = 45;
            dataGridSubjects.Columns["Teacher"].Width = 200;
            dataGridSubjects.Columns["Average"].Width = 85;

            dataGridSubjects.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            foreach (DataGridViewColumn col in dataGridSubjects.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridSubjects.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
            dataGridSubjects.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
        }

        private void SetupGradesGrid() // Konfigurē atzīmju tabulas kolonnas
        {
            dataGridGrades.Columns.Clear();
            dataGridGrades.Columns.Add("Number", "№");
            dataGridGrades.Columns.Add("Value", "Atzīme");
            dataGridGrades.Columns.Add("Type", "Veids");
            dataGridGrades.Columns.Add("Date", "Datums");
            dataGridGrades.Columns.Add("Comment", "Komentārs");

            dataGridGrades.Columns["Number"].Width = 35;
            dataGridGrades.Columns["Value"].Width = 70;
            dataGridGrades.Columns["Type"].Width = 200;
            dataGridGrades.Columns["Date"].Width = 150;

            dataGridGrades.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dataGridGrades.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridGrades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
            dataGridGrades.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
        }

        private void LoadSubjectsComboBox() // Ielādē priekšmetu sarakstu atzīmju pievienošanas combobox
        {
            comboGradeSubject.Items.Clear();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name FROM Subjects ORDER BY Name";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboGradeSubject.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()!
                });
            }

            if (comboGradeSubject.Items.Count > 0)
                comboGradeSubject.SelectedIndex = 0;
        }

        private void LoadGradeTypes() // Ielādē atzīmju veidus combobox
        {
            comboGradeType.Items.Clear();
            comboGradeType.Items.Add("Eksāmens");
            comboGradeType.Items.Add("Tests");
            comboGradeType.Items.Add("Laboratorijas darbs");
            comboGradeType.Items.Add("Mājas darbs");
            comboGradeType.Items.Add("Mutiskā atbilde");
            comboGradeType.SelectedIndex = 0;
        }

        private void LoadSubjects() // Ielādē priekšmetu sarakstu no datubāzes
        {
            dataGridSubjects.Rows.Clear();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Subjects.Id, Code, Name,
                       Part, CreditPoints, Ects,
                       Semester, Teachers.FullName,
                       AVG(CAST(Grades.Value AS REAL)) AS AvgGrade
                FROM Subjects
                LEFT JOIN Teachers ON Subjects.TeacherId = Teachers.Id
                LEFT JOIN Grades   ON Grades.SubjectId = Subjects.Id
                GROUP BY Subjects.Id
                ORDER BY Subjects.Semester, Subjects.Name
            ";

            int rowNumber = 1;
            int lastSemester = 0;

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int semester = Convert.ToInt32(reader["Semester"]);

                if (semester != lastSemester)
                {
                    int sepRow = dataGridSubjects.Rows.Add(
                        "", "", $"── {semester}. semestris ──",
                        "", "", "", "", ""
                    );
                    dataGridSubjects.Rows[sepRow].DefaultCellStyle.BackColor =
                        System.Drawing.Color.FromArgb(230, 230, 230);
                    dataGridSubjects.Rows[sepRow].DefaultCellStyle.Font = new System.Drawing.Font(
                            dataGridSubjects.Font,
                            System.Drawing.FontStyle.Bold);
                    lastSemester = semester;
                }

                string avgText = reader["AvgGrade"] == DBNull.Value ? "—" : $"{Convert.ToDouble(reader["AvgGrade"]):F2}";

                int row = dataGridSubjects.Rows.Add(
                    rowNumber++,
                    reader["Code"] == DBNull.Value ? "" : reader["Code"].ToString(),
                    reader["Name"].ToString(),
                    reader["Part"] == DBNull.Value ? "" : reader["Part"].ToString(),
                    Convert.ToInt32(reader["CreditPoints"]),
                    Convert.ToInt32(reader["Ects"]),
                    reader["FullName"] == DBNull.Value ? "-" : reader["FullName"].ToString(),
                    avgText
                );

                dataGridSubjects.Rows[row].Tag = Convert.ToInt32(reader["Id"]);
            }
            dataGridSubjects.Refresh();
            dataGridSubjects.ClearSelection();
            dataGridSubjects.CurrentCell = null;
        }
        // Apstrādā priekšmeta izvēli tabulā
        private void dataGridSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (dataGridSubjects.CurrentRow == null || dataGridSubjects.CurrentRow.Tag == null)
            {
                dataGridGrades.Rows.Clear();
                labelGradesTitle.Text = "Izvēlieties priekšmetu";
                selectedSubjectId = -1;
                return;
            }

            selectedSubjectId = (int)dataGridSubjects.CurrentRow.Tag;

            string name = dataGridSubjects.CurrentRow.Cells["Name"].Value?.ToString() ?? "";
            labelGradesTitle.Text = $"Atzīmes: {name}";

            foreach (ComboBoxItem item in comboGradeSubject.Items)
            {
                if (item.Id == selectedSubjectId)
                {
                    comboGradeSubject.SelectedItem = item;
                    break;
                }
            }
            LoadGrades(selectedSubjectId);
            ClearGradePanel();
        }

        // Apstrādā atzīmes izvēli tabulā
        private void dataGridGrades_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (dataGridGrades.CurrentRow == null || dataGridGrades.CurrentRow.Tag == null)
            {
                ClearGradePanel();
                return;
            }
            int id = (int)dataGridGrades.CurrentRow.Tag;
            FillGradePanel(id);
        }

        // Aizpilda atzīmes pievienošanas paneli ar izvēlētās atzīmes datiem
        private void FillGradePanel(int gradeId)
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, Value, Type, Date, Comment, SubjectId
                FROM Grades WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", gradeId);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return;

            editingGradeId = Convert.ToInt32(reader["Id"]);
            numericGradeValue.Value = Convert.ToInt32(reader["Value"]);
            comboGradeType.SelectedIndex = Convert.ToInt32(reader["Type"]);
            dateTimeGradeDate.Value = DateTime.Parse(reader["Date"].ToString());
            textGradeComment.Text = reader["Comment"] == DBNull.Value ? "" : reader["Comment"].ToString();

            int subjectId = Convert.ToInt32(reader["SubjectId"]);
            foreach (ComboBoxItem item in comboGradeSubject.Items)
            {
                if (item.Id == subjectId)
                {
                    comboGradeSubject.SelectedItem = item;
                    break;
                }
            }
            buttonSaveGrade.Text = "Labot atzīmi";
        }
        private void ClearGradePanel() // Notīra atzīmes pievienošanas paneli
        {
            editingGradeId = -1;
            numericGradeValue.Value = 1;
            comboGradeType.SelectedIndex = 0;
            dateTimeGradeDate.Value = DateTime.Today;
            textGradeComment.Text = "";
            buttonSaveGrade.Text = "Saglabāt atzīmi";

            if (selectedSubjectId != -1)
            {
                foreach (ComboBoxItem item in comboGradeSubject.Items)
                {
                    if (item.Id == selectedSubjectId)
                    {
                        comboGradeSubject.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void LoadGrades(int subjectId) // Ielādē izvēlētā priekšmeta atzīmes no datubāzes
        {
            isLoading = true;
            try
            {
                dataGridGrades.Rows.Clear();

                string[] types =
                {
                    "Eksāmens", "Tests", "Laboratorijas darbs",
                    "Mājas darbs", "Mutiskā atbilde"
                };

                using var connection = DatabaseCreation.GetConnection();
                using var cmd = connection.CreateCommand();

                cmd.CommandText = @"
                    SELECT Id, Value, Type, Date, Comment
                    FROM Grades
                    WHERE SubjectId = @SubjectId
                    ORDER BY Date DESC
                ";
                cmd.Parameters.AddWithValue("@SubjectId", subjectId);

                int rowNumber = 1;
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = Convert.ToInt32(reader["Value"]);
                    int typeIndex = Convert.ToInt32(reader["Type"]);
                    string typeName = typeIndex >= 0 && typeIndex < types.Length ? types[typeIndex] : "-";

                    int row = dataGridGrades.Rows.Add(
                        rowNumber++,
                        value,
                        typeName,
                        DateTime.Parse(reader["Date"].ToString()).ToString("dd.MM.yyyy"),
                        reader["Comment"] == DBNull.Value ? "" : reader["Comment"].ToString()
                    );

                    dataGridGrades.Rows[row].Tag = Convert.ToInt32(reader["Id"]);

                    System.Drawing.Color rowColor;
                    if (value <= 3)
                        rowColor = System.Drawing.Color.FromArgb(255, 200, 200);
                    else
                        rowColor = System.Drawing.Color.FromArgb(255, 220, 180);

                    dataGridGrades.Rows[row].DefaultCellStyle.BackColor = rowColor;
                }
            }
            finally
            {
                isLoading = false;
            }
            dataGridGrades.Refresh();
            dataGridGrades.ClearSelection();
            dataGridGrades.CurrentCell = null;
        }
        private void buttonSaveGrade_Click(object sender, EventArgs e) // Saglabā vai atjaunina atzīmi
        {
            if (comboGradeSubject.SelectedItem == null)
            {
                MessageBox.Show("Izvēlieties priekšmetu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = (ComboBoxItem)comboGradeSubject.SelectedItem;
            int value = (int)numericGradeValue.Value;
            int type = comboGradeType.SelectedIndex;
            DateTime date = dateTimeGradeDate.Value.Date;
            string comment = textGradeComment.Text.Trim();

            if (editingGradeId == -1)
                SaveNewGrade(value, type, date, comment, subject.Id);
            else
                UpdateExistingGrade(editingGradeId, value, type, date, comment, subject.Id);

            isLoading = true;
            try
            {
                LoadSubjects();
            }
            finally
            {
                isLoading = false;
            }

            LoadGrades(subject.Id);
            labelGradesTitle.Text = $"Atzīmes: {subject}";
            ClearGradePanel();
        }
        // Notīra atzīmes pievienošanas paneli
        private void buttonClearGrade_Click(object sender, EventArgs e)
        {
            ClearGradePanel();
            dataGridGrades.ClearSelection();
        }
        private void buttonDeleteGrade_Click(object sender, EventArgs e) // Dzēš izvēlēto atzīmi
        {
            if (dataGridGrades.CurrentRow == null || dataGridGrades.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties atzīmi!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Dzēst izvēlēto atzīmi?",
                "Apstiprinājums", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridGrades.CurrentRow.Tag;
                DeleteGrade(id);

                isLoading = true;
                try
                {
                    LoadSubjects();
                }
                finally
                {
                    isLoading = false;
                }

                if (selectedSubjectId != -1)
                    LoadGrades(selectedSubjectId);

                ClearGradePanel();
            }
        }

        // Atver jauna priekšmeta pievienošanas dialogu
        private void buttonAddSubject_Click(object sender, EventArgs e)
        {
            var dialog = new SubjectsAddForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddSubject(dialog.Subject);

                isLoading = true;
                try
                {
                    LoadSubjects();
                }
                finally
                {
                    isLoading = false;
                }

                LoadSubjectsComboBox();
            }
        }

        // Atver izvēlētā priekšmeta rediģēšanas dialogu
        private void buttonEditSubject_Click(object sender, EventArgs e)
        {
            if (dataGridSubjects.CurrentRow == null || dataGridSubjects.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties priekšmetu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dataGridSubjects.CurrentRow.Tag;
            var dialog = new SubjectsAddForm(GetSubjectById(id));
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UpdateSubject(dialog.Subject);

                isLoading = true;
                try
                {
                    LoadSubjects();
                }
                finally
                {
                    isLoading = false;
                }

                LoadSubjectsComboBox();
            }
        }

        // Dzēš izvēlēto priekšmetu un visas tā atzīmes
        private void buttonDeleteSubject_Click(object sender, EventArgs e)
        {
            if (dataGridSubjects.CurrentRow == null || dataGridSubjects.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties priekšmetu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Dzēst priekšmetu? Visas atzīmes arī tiks dzēstas!",
                "Apstiprinājums", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridSubjects.CurrentRow.Tag;
                DeleteSubject(id);

                isLoading = true;
                try
                {
                    LoadSubjects();
                }
                finally
                {
                    isLoading = false;
                }

                LoadSubjectsComboBox();
                dataGridGrades.Rows.Clear();
                labelGradesTitle.Text = "Izvēlieties priekšmetu";
                selectedSubjectId = -1;
                ClearGradePanel();
            }
        }

        // SQL metodi

        // Saglabā jaunu atzīmi datu bāzē
        private void SaveNewGrade(int value, int type, DateTime date, string comment, int subjectId)
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Grades (Value, Type, Date, Comment, SubjectId)
                VALUES (@Value, @Type, @Date, @Comment, @SubjectId)
            ";

            cmd.Parameters.AddWithValue("@Value", value);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Comment", comment);
            cmd.Parameters.AddWithValue("@SubjectId", subjectId);

            cmd.ExecuteNonQuery();
        }

        // Atjaunina esošās atzīmes datus datu bāzē
        private void UpdateExistingGrade(int id, int value, int type, DateTime date, string comment, int subjectId)
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Grades
                SET Value = @Value,
                    Type = @Type,
                    Date = @Date,
                    Comment = @Comment,
                    SubjectId = @SubjectId
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Value", value);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Comment", comment);
            cmd.Parameters.AddWithValue("@SubjectId", subjectId);

            cmd.ExecuteNonQuery();
        }

        private void DeleteGrade(int id) // Dzēš atzīmi no datu bāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Grades WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        private void AddSubject(Subject subject) // Saglabā jaunu priekšmetu datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Subjects
                    (Code, Name, Part, CreditPoints, Ects, Semester, TeacherId)
                VALUES
                    (@Code, @Name, @Part, @Credits, @Ects, @Semester, @TeacherId)
            ";

            cmd.Parameters.AddWithValue("@Code", subject.Code);
            cmd.Parameters.AddWithValue("@Name", subject.Name);
            cmd.Parameters.AddWithValue("@Part", subject.Part);
            cmd.Parameters.AddWithValue("@Credits", subject.CreditPoints);
            cmd.Parameters.AddWithValue("@Ects", subject.Ects);
            cmd.Parameters.AddWithValue("@Semester", subject.Semester);
            cmd.Parameters.AddWithValue("@TeacherId", subject.TeacherId.HasValue
                                                        ? subject.TeacherId.Value
                                                        : DBNull.Value);

            cmd.ExecuteNonQuery();
        }


        private void UpdateSubject(Subject subject) // Atjaunina esošā priekšmeta datus datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Subjects
                SET Code = @Code,
                    Name = @Name,
                    Part = @Part,
                    CreditPoints = @Credits,
                    Ects = @Ects,
                    Semester = @Semester,
                    TeacherId = @TeacherId
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", subject.Id);
            cmd.Parameters.AddWithValue("@Code", subject.Code);
            cmd.Parameters.AddWithValue("@Name", subject.Name);
            cmd.Parameters.AddWithValue("@Part", subject.Part);
            cmd.Parameters.AddWithValue("@Credits", subject.CreditPoints);
            cmd.Parameters.AddWithValue("@Ects", subject.Ects);
            cmd.Parameters.AddWithValue("@Semester", subject.Semester);
            cmd.Parameters.AddWithValue("@TeacherId", subject.TeacherId.HasValue
                                                        ? subject.TeacherId.Value
                                                        : DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        private void DeleteSubject(int id) // Dzēš priekšmetu no datubāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Subjects WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        private Subject GetSubjectById(int id) // Iegūst priekšmeta datus no datu bāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, Code, Name, Part,
                       CreditPoints, Ects, Semester, TeacherId
                FROM Subjects WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            return new Subject
            {
                Id = Convert.ToInt32(reader["Id"]),
                Code = reader["Code"] == DBNull.Value ? "" : reader["Code"].ToString(),
                Name = reader["Name"].ToString(),
                Part = reader["Part"] == DBNull.Value ? "" : reader["Part"].ToString(),
                CreditPoints = Convert.ToInt32(reader["CreditPoints"]),
                Ects = Convert.ToInt32(reader["Ects"]),
                Semester = Convert.ToInt32(reader["Semester"]),
                TeacherId = reader["TeacherId"] == DBNull.Value ? null : Convert.ToInt32(reader["TeacherId"])
            };
        }
    }
}