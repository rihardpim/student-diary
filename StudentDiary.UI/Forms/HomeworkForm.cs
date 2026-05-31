using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentDiary.Core.Models;
using StudentDiary.Data;

namespace StudentDiary.UI.Forms
{
    public partial class HomeworkForm : Form // Forma mājas darbu pārvaldībai
    {
        private DateTime currentWeekStart;
        private readonly string[] dayNames =
            {
                "Pirmdiena", "Otrdiena", "Trešdiena",
                "Ceturtdiena", "Piektdiena", "Sestdiena", "Svētdiena"
            };

        public HomeworkForm() // iestata kalendāra skatu un ielādē mājas darbus
        {
            InitializeComponent();
            currentWeekStart = GetMonday(DateTime.Today);

            SetupGrid();
            LoadSubjectsFilter();
            LoadHomeworks();
            UpdateWeekLabel();

        }

        private DateTime GetMonday(DateTime date) // Atgriež norādītā datuma pirmdienu
        {
            DayOfWeek day = date.DayOfWeek;
            int dayNumber = day == DayOfWeek.Sunday ? 7 : (int)day;
            int daysToMonday = dayNumber - 1;

            return date.AddDays(-daysToMonday).Date;
        }

        private void SetupGrid() // Izveido kalendāra kolonnas
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor =
                dataGridView1.DefaultCellStyle.ForeColor;

            for (int i = 0; i < 7; i++)
            {
                DateTime dayDate = currentWeekStart.AddDays(i);
                dataGridView1.Columns.Add(
                    $"Day{i + 1}",
                    $"{dayNames[i]}\n{dayDate:dd.MM}"
                );
                dataGridView1.Columns[$"Day{i + 1}"].DefaultCellStyle.WrapMode =
                    DataGridViewTriState.True;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSubjectsFilter() // Ielādē priekšmetu sarakstu filtra combobox
        {
            comboSubject.Items.Clear();
            comboSubject.Items.Add(new ComboBoxItem
            {
                Id = 0,
                Name = "Visi priekšmeti"
            });

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name FROM Subjects ORDER BY Name";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboSubject.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()!
                });
            }

            comboSubject.SelectedIndex = 0;
        }

        private void LoadHomeworks()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 7; i++)
            {
                DateTime dayDate = currentWeekStart.AddDays(i);
                dataGridView1.Columns[$"Day{i + 1}"].HeaderText =
                    $"{dayNames[i]}\n{dayDate:dd.MM}";
                dataGridView1.Columns[$"Day{i + 1}"]
                    .HeaderCell.Style.BackColor =
                    dayDate.Date == DateTime.Today
                        ? System.Drawing.Color.FromArgb(100, 180, 255)
                        : System.Drawing.Color.Empty;
            }

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            string sql = @"
                SELECT Homeworks.Id, Homeworks.Title,
                       Homeworks.DueDate, Homeworks.IsCompleted,
                       Homeworks.Priority, Subjects.Name, Homeworks.Description
                FROM Homeworks
                JOIN Subjects ON Homeworks.SubjectId = Subjects.Id
                WHERE Homeworks.DueDate BETWEEN @From AND @To
            ";

            if (comboSubject.SelectedItem is ComboBoxItem item && item.Id != 0)
                sql += " AND Homeworks.SubjectId = @SubjectId";

            sql += " ORDER BY Homeworks.DueDate ASC";
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@From", currentWeekStart.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@To", currentWeekStart.AddDays(6).ToString("yyyy-MM-dd"));

            if (comboSubject.SelectedItem is ComboBoxItem selected && selected.Id != 0)
                cmd.Parameters.AddWithValue("@SubjectId", selected.Id);

            var columnRowIndex = new Dictionary<string, int>();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dueDate = DateTime.Parse(reader["DueDate"].ToString()!);
                bool isCompleted = Convert.ToInt32(reader["IsCompleted"]) == 1;
                var priority = (HomeworkPriority)Convert.ToInt32(reader["Priority"]);
                int id = Convert.ToInt32(reader["Id"]);
                string title = reader["Title"].ToString()!;
                string subjectName = reader["Name"].ToString()!;

                int dayOfWeek = dueDate.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)dueDate.DayOfWeek;
                string colName = $"Day{dayOfWeek}";

                if (!dataGridView1.Columns.Contains(colName))
                    continue;

                if (!columnRowIndex.ContainsKey(colName))
                    columnRowIndex[colName] = 0;

                int rowIndex = columnRowIndex[colName];

                while (dataGridView1.Rows.Count <= rowIndex)
                    dataGridView1.Rows.Add();

                dataGridView1.Rows[rowIndex].Height = 200;

                string statusIcon = isCompleted ? "✓ " : "";
                string text = $"{statusIcon}{subjectName}\n{title}";

                dataGridView1.Rows[rowIndex].Cells[colName].Value = text;
                dataGridView1.Rows[rowIndex].Cells[colName].Tag = id;

                string description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString()!;

                if (!string.IsNullOrWhiteSpace(description))
                {
                    dataGridView1.Rows[rowIndex].Cells[colName].ToolTipText = description;
                }

                System.Drawing.Color cellColor;
                if (isCompleted)
                {
                    cellColor = System.Drawing.Color.FromArgb(180, 180, 180);
                }
                else
                {
                    switch (priority)
                    {
                        case HomeworkPriority.High:
                            cellColor = System.Drawing.Color.FromArgb(200, 80, 80);
                            break;
                        case HomeworkPriority.Medium:
                            cellColor = System.Drawing.Color.FromArgb(50, 140, 80);
                            break;
                        default:
                            cellColor = System.Drawing.Color.FromArgb(100, 160, 220);
                            break;
                    }
                }

                dataGridView1.Rows[rowIndex].Cells[colName].Style.BackColor = cellColor;
                dataGridView1.Rows[rowIndex].Cells[colName].Style.ForeColor = System.Drawing.Color.White;

                columnRowIndex[colName] = rowIndex + 1;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Apstrādā klikšķi uz šūnas
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Tag == null)
                return;

            int id = (int)cell.Tag;
            ShowHomeworkMenu(id, cell);
        }

        private void ShowHomeworkMenu(int id, DataGridViewCell? cell) // Rāda konteksta izvēlni izvēlētajam uzdevumam
        {
            bool isCompleted = GetHomeworkIsCompleted(id);

            var menu = new ContextMenuStrip();

            var itemEdit = new ToolStripMenuItem("✏ Labot");
            itemEdit.Tag = id;
            itemEdit.Click += (s, e) =>
            {
                var dialog = new HomeworkAddForm(GetHomeworkById(id));
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UpdateHomework(dialog.Homework);
                    LoadHomeworks();
                }
            };

            if (!isCompleted)
            {
                var itemComplete = new ToolStripMenuItem("✓ Atzīmēt kā izpildītu");
                itemComplete.Click += (s, e) =>
                {
                    MarkCompleted(id);
                    LoadHomeworks();
                };
                menu.Items.Add(itemComplete);
            }
            else
            {
                var itemCancel = new ToolStripMenuItem("↩ Atcelt izpildi");
                itemCancel.Click += (s, e) =>
                {
                    MarkUncompleted(id);
                    LoadHomeworks();
                };
                menu.Items.Add(itemCancel);
            }

            var itemDelete = new ToolStripMenuItem("🗑 Dzēst");
            itemDelete.Click += (s, e) =>
            {
                var result = MessageBox.Show("Dzēst šo uzdevumu?", 
                    "Apstiprinājums", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteHomework(id);
                    LoadHomeworks();
                }
            };

            menu.Items.Add(itemEdit);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(itemDelete);

            menu.Show(dataGridView1, dataGridView1.PointToClient(Cursor.Position));
        }

        private bool GetHomeworkIsCompleted(int id) // Atgriež vai uzdevums ir izpildīts
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "SELECT IsCompleted FROM Homeworks WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }
        private void buttonPrev_Click(object sender, EventArgs e) // Pāriet uz iepriekšējo nedēļu
        {
            currentWeekStart = currentWeekStart.AddDays(-7);
            SetupGrid();
            LoadHomeworks();
            UpdateWeekLabel();
        }

        private void buttonNext_Click(object sender, EventArgs e) // Pāriet uz nākamo nedēļu
        {
            currentWeekStart = currentWeekStart.AddDays(7);
            SetupGrid();
            LoadHomeworks();
            UpdateWeekLabel();
        }

        private void buttonToday_Click(object sender, EventArgs e) // Atgriežas uz šo nedēļu
        {
            currentWeekStart = GetMonday(DateTime.Today);
            SetupGrid();
            LoadHomeworks();
            UpdateWeekLabel();
        }

        private void UpdateWeekLabel() // Atjaunina nedēļas datuma uzrakstu virs kalendāra
        {
            DateTime weekEnd = currentWeekStart.AddDays(6);
            labelWeek.Text = $"{currentWeekStart:dd.MM} – {weekEnd:dd.MM}";
        }

        // Ielādē mājas darbus no jauna pēc priekšmeta filtra maiņas
        private void comboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHomeworks();
        }

        private void buttonAdd_Click(object sender, EventArgs e) // Atver pievienošanas formu
        {
            var dialog = new HomeworkAddForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveHomework(dialog.Homework);
                LoadHomeworks();
            }
        }

        // SQL metodi
        private void SaveHomework(Homework homework) // Saglabā jaunu mājas darbu datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Homeworks
                    (Title, Description, DueDate, IsCompleted, Priority, SubjectId)
                VALUES
                    (@Title, @Description, @DueDate, 0, @Priority, @SubjectId)
            ";

            cmd.Parameters.AddWithValue("@Title", homework.Title);
            cmd.Parameters.AddWithValue("@Description", homework.Description);
            cmd.Parameters.AddWithValue("@DueDate", homework.DueDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Priority", (int)homework.Priority);
            cmd.Parameters.AddWithValue("@SubjectId", homework.SubjectId);
            cmd.ExecuteNonQuery();
        }

        private void UpdateHomework(Homework homework) // Atjaunina esošā mājas darba datus datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Homeworks
                SET Title       = @Title,
                    Description = @Description,
                    DueDate     = @DueDate,
                    Priority    = @Priority,
                    SubjectId   = @SubjectId
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", homework.Id);
            cmd.Parameters.AddWithValue("@Title", homework.Title);
            cmd.Parameters.AddWithValue("@Description", homework.Description);
            cmd.Parameters.AddWithValue("@DueDate", homework.DueDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Priority", (int)homework.Priority);
            cmd.Parameters.AddWithValue("@SubjectId", homework.SubjectId);
            cmd.ExecuteNonQuery();
        }

        private void MarkCompleted(int id) // Nosaka, ka isCompleted ir izpildīts datu bāze.
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Homeworks SET IsCompleted = 1 WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
        private void MarkUncompleted(int id) // Nosaka, ka isCompleted ir neizpildīts datu bāze.
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE Homeworks SET IsCompleted = 0 WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }
        private void DeleteHomework(int id) // Dzēš uzdevumu no datu bāzes
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Homeworks WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }

        private Homework GetHomeworkById(int id) // Iegūst mājas darba datus no datu bāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, Title, Description, DueDate,
                       IsCompleted, Priority, SubjectId
                FROM Homeworks WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            return new Homework
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"].ToString()!,
                Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                DueDate = DateTime.Parse(reader["DueDate"].ToString()),
                IsCompleted = Convert.ToInt32(reader["IsCompleted"]) == 1,
                Priority = (HomeworkPriority)Convert.ToInt32(reader["Priority"]),
                SubjectId = Convert.ToInt32(reader["SubjectId"])
            };
        }
    }
}