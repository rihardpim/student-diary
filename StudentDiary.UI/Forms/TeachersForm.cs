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
    public partial class TeachersForm : Form // Forma pasniedzēju saraksta pārvaldībai
    {
        public TeachersForm() // Inicializē formu
        {
            InitializeComponent();

            SetupGrid();
            LoadTeachers();
        }
        private void SetupGrid() // Konfigurē tabulas kolonnas
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "№");
            dataGridView1.Columns.Add("FullName", "Vārds Uzvārds");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Phone", "Tālrunis");
            dataGridView1.Columns.Add("Classroom", "Auditorija");

            dataGridView1.Columns["Id"].Width = 40;
            dataGridView1.Columns["FullName"].Width = 200;
            dataGridView1.Columns["Email"].Width = 150;
            dataGridView1.Columns["Phone"].Width = 130;
            dataGridView1.Columns["Classroom"].Width = 80;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 0, 120, 215);
        }
        private void LoadTeachers(string search = "") // Ielādē pasniedzēju sarakstu no datu bāzes
        {
            dataGridView1.Rows.Clear();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            if (string.IsNullOrEmpty(search))
            {
                cmd.CommandText = @"
                    SELECT Id, FullName, Email, Phone, Classroom
                    FROM Teachers
                    ORDER BY FullName
                ";
            }
            else
            {
                cmd.CommandText = @"
                    SELECT Id, FullName, Email, Phone, Classroom
                    FROM Teachers
                    WHERE FullName LIKE @Search
                    ORDER BY FullName
                ";
                cmd.Parameters.AddWithValue("@Search", $"%{search}%");
            }

            int rowNumber = 1;
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);

                int row = dataGridView1.Rows.Add(
                    rowNumber++,
                    reader["FullName"].ToString(),
                    reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString(),
                    reader["Phone"] == DBNull.Value ? "" : reader["Phone"].ToString(),
                    reader["Classroom"] == DBNull.Value ? "" : reader["Classroom"].ToString()
                );

                dataGridView1.Rows[row].Tag = id;
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e) // Atver pievienošanas formu un saglabā jaunu pasniedzēju
        {
            var dialog = new TeachersAddForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddTeacher(dialog.Teacher);
                LoadTeachers();
            }
        }

        // Atver rediģēšanas formu izvēlētajam pasniedzējam
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties pasniedzēju!",
                    "!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dataGridView1.CurrentRow.Tag;

            var dialog = new TeachersAddForm(GetTeacherById(id));
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                EditTeacher(dialog.Teacher);
                LoadTeachers();
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e) // Dzēš izvēlēto pasniedzēju
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Tag == null)
            {
                MessageBox.Show("Izvēlieties pasniedzēju!",
                    "!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = dataGridView1.CurrentRow .Cells["FullName"].Value.ToString();

            var result = MessageBox.Show(
                $"Dzēst pasniedzēju {name}?",
                "Apstiprinājums",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridView1.CurrentRow.Tag;
                DeleteTeacher(id);
                LoadTeachers();
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e) // Meklē pasniedzējus pēc ievadītā teksta
        {
            LoadTeachers(txtSearch.Text);
        }

        // Uzsāk meklēšanu nospiežot Enter meklēšanas laukā
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoadTeachers(txtSearch.Text);
        }


        // SQL metodi

        private void AddTeacher(Teacher teacher) // Saglabā jaunu pasniedzēju datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Teachers (FullName, Email, Phone, Classroom)
                VALUES (@FullName, @Email, @Phone, @Classroom)
            ";

            cmd.Parameters.AddWithValue("@FullName", teacher.FullName);
            cmd.Parameters.AddWithValue("@Email", teacher.Email);
            cmd.Parameters.AddWithValue("@Phone", teacher.Phone);
            cmd.Parameters.AddWithValue("@Classroom", teacher.Classroom);

            cmd.ExecuteNonQuery();
        }

        private void EditTeacher(Teacher teacher) // Atjaunina esošā pasniedzēja datus datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Teachers
                SET FullName = @FullName,
                    Email = @Email,
                    Phone = @Phone,
                    Classroom = @Classroom
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", teacher.Id);
            cmd.Parameters.AddWithValue("@FullName", teacher.FullName);
            cmd.Parameters.AddWithValue("@Email", teacher.Email);
            cmd.Parameters.AddWithValue("@Phone", teacher.Phone);
            cmd.Parameters.AddWithValue("@Classroom", teacher.Classroom);

            cmd.ExecuteNonQuery();
        }

        private void DeleteTeacher(int id) // Dzēš pasniedzēju no datubāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Teachers WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        private Teacher GetTeacherById(int id) // Iegūst pasniedzēja datus no datubāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, FullName, Email, Phone, Classroom
                FROM Teachers WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            return new Teacher
            {
                Id = Convert.ToInt32(reader["Id"]),
                FullName = reader["FullName"].ToString(),
                Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString(),
                Phone = reader["Phone"] == DBNull.Value ? "" : reader["Phone"].ToString(),
                Classroom = reader["Classroom"] == DBNull.Value ? "" : reader["Classroom"].ToString()
            };
        }
    }
}

