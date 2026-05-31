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
using StudentDiary.Core.Models;

namespace StudentDiary.UI.Forms
{
    public partial class NotesForm : Form // Forma piezīmju pārvaldībai
    {
        private int currentNoteId = -1; // Pašreizējās atvērtās piezīmes ID

        public NotesForm()
        {
            InitializeComponent();
            LoadNotes();
        }
        private void LoadNotes(string search = "") // Ielādē piezīmju sarakstu no datu bāzes
        {
            listNotes.Items.Clear();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            if (string.IsNullOrEmpty(search))
            {
                cmd.CommandText = @"
                    SELECT Id, Title, CreatedAt
                    FROM Notes
                    ORDER BY UpdatedAt DESC
                ";
            }
            else
            {
                cmd.CommandText = @"
                    SELECT Id, Title, CreatedAt
                    FROM Notes
                    WHERE Title LIKE @Search
                    OR Content LIKE @Search
                    OR Tags LIKE @Search
                    ORDER BY UpdatedAt DESC
                ";
                cmd.Parameters.AddWithValue("@Search", $"%{search}%");
            }

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listNotes.Items.Add(new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Title"].ToString()
                });
            }
        }


        private void listNotes_SelectedIndexChanged(object sender, EventArgs e) // Ielādē izvēlēto piezīmi redaktorā
        {
            if (listNotes.SelectedItem == null)
                return;

            var selected = (ComboBoxItem)listNotes.SelectedItem;
            LoadNote(selected.Id);
        }

        private void LoadNote(int id) // Ielādē piezīmes datus redaktora laukos
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, Title, Content, Tags, CreatedAt, UpdatedAt
                FROM Notes WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                currentNoteId = Convert.ToInt32(reader["Id"]);
                textTitle.Text = reader["Title"].ToString()!;
                textContent.Text = reader["Content"] == DBNull.Value ? "" : reader["Content"].ToString();
                textTags.Text = reader["Tags"] == DBNull.Value ? "" : reader["Tags"].ToString();

                DateTime created = DateTime.Parse(reader["CreatedAt"].ToString());
                DateTime updated = DateTime.Parse(reader["UpdatedAt"].ToString());
                labelDate.Text = $"Izveidots: {created:dd.MM.yyyy}  " +
                                   $"Labots: {updated:dd.MM.yyyy}";
            }
        }

        private void ClearEditor() // Notīra redaktora laukus
        {
            currentNoteId = -1;
            textTitle.Text = "";
            textContent.Text = "";
            textTags.Text = "";
            labelDate.Text = "";
        }


        private void textSearch_TextChanged(object sender, EventArgs e) // Meklē piezīmes pēc ievadītā teksta
        {
            LoadNotes(textSearch.Text);
        }


        private void buttonNew_Click(object sender, EventArgs e) // Notīra redaktoru jaunas piezīmes izveidošanai
        {
            listNotes.SelectedItem = null;
            ClearEditor();
            textTitle.Focus();
        }
        private void buttonSave_Click(object sender, EventArgs e) // Saglabā piezīmi - izveido jaunu vai atjaunina esošo
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                MessageBox.Show("Ievadiet virsrakstu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentNoteId == -1)
                CreateNote();
            else
                UpdateNote();

            LoadNotes(textSearch.Text);
        }
        private void buttonDelete_Click(object sender, EventArgs e) // Dzēš pašreizējo piezīmi
        {
            if (currentNoteId == -1)
            {
                MessageBox.Show("Izvēlieties piezīmi!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Dzēst šo piezīmi?",
                "Apstiprinājums", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeleteNote(currentNoteId);
                LoadNotes(textSearch.Text);
                ClearEditor();
            }
        }
        private void listNotes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) 
                return;

            e.DrawBackground();

            var item = listNotes.Items[e.Index] as ComboBoxItem;
            if (item != null)
            {
                e.Graphics.DrawString(
                    item.Name,
                    e.Font,
                    new SolidBrush(e.ForeColor),
                    e.Bounds.X + 8,
                    e.Bounds.Y + 8
                );
            }

            e.Graphics.DrawLine(
                new Pen(Color.FromArgb(220, 220, 220)),
                e.Bounds.Left,
                e.Bounds.Bottom - 1,
                e.Bounds.Right,
                e.Bounds.Bottom - 1
            );
        }

        // SQL metodi

        private void CreateNote() // Izveido jaunu piezīmi datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            cmd.CommandText = @"
                INSERT INTO Notes (Title, Content, Tags, CreatedAt, UpdatedAt)
                VALUES (@Title, @Content, @Tags, @CreatedAt, @UpdatedAt)
            ";

            cmd.Parameters.AddWithValue("@Title", textTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@Content", textContent.Text.Trim());
            cmd.Parameters.AddWithValue("@Tags", textTags.Text.Trim());
            cmd.Parameters.AddWithValue("@CreatedAt", now);
            cmd.Parameters.AddWithValue("@UpdatedAt", now);

            cmd.ExecuteNonQuery();
        }

        private void UpdateNote() // // Atjaunina esošās piezīmes datus datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            cmd.CommandText = @"
                UPDATE Notes
                SET Title     = @Title,
                    Content   = @Content,
                    Tags      = @Tags,
                    UpdatedAt = @UpdatedAt
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", currentNoteId);
            cmd.Parameters.AddWithValue("@Title", textTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@Content", textContent.Text.Trim());
            cmd.Parameters.AddWithValue("@Tags", textTags.Text.Trim());
            cmd.Parameters.AddWithValue("@UpdatedAt", now);

            cmd.ExecuteNonQuery();
        }

        private void DeleteNote(int id) // // Dzēš piezīmi no datubāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Notes WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

    }
}