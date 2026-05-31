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
    public partial class DeadlinesForm : Form // Forma studenta termiņu pārvaldībai
    {
        public DeadlinesForm() // Inicializē formu un ielādē termiņu sarakstu
        {
            InitializeComponent();

            SetupGrid();
            LoadDeadlines();
            dataGridView1.ClearSelection();
        }

        private void SetupGrid() // Konfigurē tabulas kolonnas un to platumu
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Number", "№");
            dataGridView1.Columns.Add("Title", "Nosaukums");
            dataGridView1.Columns.Add("Subject", "Studiju kurss");
            dataGridView1.Columns.Add("Date", "Datums");
            dataGridView1.Columns.Add("DaysLeft", "Atlikušas dienas");
            dataGridView1.Columns.Add("Type", "Veids");
            dataGridView1.Columns.Add("Description", "Apraksts");

            dataGridView1.Columns["Number"].Width = 40;
            dataGridView1.Columns["Title"].Width = 250;
            dataGridView1.Columns["Subject"].Width = 250;
            dataGridView1.Columns["Date"].Width = 250;
            dataGridView1.Columns["DaysLeft"].Width = 120;
            dataGridView1.Columns["Type"].Width = 250;

            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void LoadDeadlines() // Ielādē visus termiņus no datubāzes un attēlo tabulā
        {
            dataGridView1.Rows.Clear();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Deadlines.Id, Deadlines.Title,
                       Deadlines.Description, Deadlines.Date,
                       Deadlines.Type, Subjects.Name
                FROM Deadlines
                LEFT JOIN Subjects ON Deadlines.SubjectId = Subjects.Id
                ORDER BY Deadlines.Date
            ";

            int rowNumber = 1;
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = DateTime.Parse(reader["Date"].ToString());
                var deadlineType = (DeadlineType)Convert.ToInt32(reader["Type"]);
                int daysLeft = (date.Date - DateTime.Today).Days;

                string daysText;
                if (daysLeft < 0)
                    daysText = "Nokavēts";
                else if (daysLeft == 0)
                    daysText = "Šodien!";
                else
                    daysText = $"{daysLeft} dienas";

                int row = dataGridView1.Rows.Add(
                    rowNumber++,
                    reader["Title"].ToString(),
                    reader["Name"] == DBNull.Value ? "" : reader["Name"].ToString(),
                    date.ToString("dd.MM.yyyy"),
                    daysText,
                    GetDeadlineTypeName(deadlineType),
                    reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString()
                );

                dataGridView1.Rows[row].Tag = Convert.ToInt32(reader["Id"]);

                Color rowColor;
                if (daysLeft < 0)
                    rowColor = Color.FromArgb(220, 220, 220);
                else if (daysLeft == 0)
                    rowColor = Color.FromArgb(255, 150, 150); 
                else if (daysLeft <= 3)
                    rowColor = Color.FromArgb(255, 200, 200); 
                else if (daysLeft <= 7)
                    rowColor = Color.FromArgb(255, 235, 180); 
                else
                    rowColor = Color.White;                   

                dataGridView1.Rows[row].DefaultCellStyle.BackColor = rowColor;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private string GetDeadlineTypeName(DeadlineType type) // Atgriež termiņa veida nosaukumu
        {
            switch (type)
            {
                case DeadlineType.Exam: 
                    return "Eksāmens";
                case DeadlineType.Coursework: 
                    return "Studiju darbs";
                case DeadlineType.Lab: 
                    return "Laboratorijas darbs";
                case DeadlineType.Test: 
                    return "Tests";
                case DeadlineType.Other: 
                    return "Cits";
                default: 
                    return "Cits";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e) //Atver pievienošanas formu un saglabā jaunu termiņu
        {
            var dialog = new DeadlinesAddForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddDeadline(dialog.Deadline);
                LoadDeadlines();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) // Atver rediģēšanas formu izvēlētajam termiņam
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties termiņu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dataGridView1.CurrentRow.Tag;
            var dialog = new DeadlinesAddForm(GetDeadlineById(id));
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UpdateDeadline(dialog.Deadline);
                LoadDeadlines();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) // Dzēš izvēlēto termiņu
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties termiņu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Dzēst izvēlēto termiņu?",
                "Apstiprinājums",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridView1.CurrentRow.Tag;
                DeleteDeadline(id);
                LoadDeadlines();
            }
        }

        // SQL metodes

        private void AddDeadline(Deadline deadline) // Pievieno jaunu termiņu datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Deadlines
                    (Title, Description, Date, Type, SubjectId)
                VALUES
                    (@Title, @Description, @Date, @Type, @SubjectId)
            ";

            cmd.Parameters.AddWithValue("@Title", deadline.Title);
            cmd.Parameters.AddWithValue("@Description", deadline.Description);
            cmd.Parameters.AddWithValue("@Date", deadline.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Type", (int)deadline.Type);
            cmd.Parameters.AddWithValue("@SubjectId", deadline.SubjectId != null ? deadline.SubjectId.Value : DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        private void UpdateDeadline(Deadline deadline) // Atjauna esošā termiņa datus datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Deadlines
                SET 
                    Title = @Title,
                    Description = @Description,
                    Date = @Date,
                    Type = @Type,
                    SubjectId = @SubjectId
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", deadline.Id);
            cmd.Parameters.AddWithValue("@Title", deadline.Title);
            cmd.Parameters.AddWithValue("@Description", deadline.Description);
            cmd.Parameters.AddWithValue("@Date", deadline.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Type", (int)deadline.Type);
            cmd.Parameters.AddWithValue("@SubjectId", deadline.SubjectId.HasValue ? deadline.SubjectId.Value : DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        private void DeleteDeadline(int id) // Dzēš termiņu no datu bāzes pēc Id
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Deadlines WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        private Deadline GetDeadlineById(int id) // Iegūst termiņa datus no datu bāzes pēc Id
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, Title, Description, Date, Type, SubjectId
                FROM Deadlines WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            return new Deadline
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"].ToString(),
                Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                Date = DateTime.Parse(reader["Date"].ToString()),
                Type = (DeadlineType)Convert.ToInt32(reader["Type"]),
                SubjectId = reader["SubjectId"] == DBNull.Value ? null : Convert.ToInt32(reader["SubjectId"])
            };
        }
    }
}