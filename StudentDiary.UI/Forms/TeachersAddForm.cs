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

namespace StudentDiary.UI.Forms
{
    public partial class TeachersAddForm : Form // Forma pasniedzēja pievienošanai un rediģēšanai
    {
        public Teacher Teacher { get; private set; } // pasniedzēja objekts ar datiem (tikai lasīšana ārpus)

        public TeachersAddForm() // Konstruktors jauna pasniedzēja pievienošanai
        {
            InitializeComponent();
            this.Text = "Pievienot pasniedzēju";
            Teacher = new Teacher();
        }
        public TeachersAddForm(Teacher teacher) // Konstruktors esošā pasniedzēja rediģēšanai
        {
            InitializeComponent();
            this.Text = "Labot pasniedzēju";
            Teacher = teacher;

            textFullName.Text = teacher.FullName;
            textEmail.Text = teacher.Email;
            textPhone.Text = teacher.Phone;
            textClassroom.Text = teacher.Classroom;
        }
        private void buttonSave_Click(object sender, EventArgs e)  //saglabā pasniedzēju un aizver formu
        {
            if (string.IsNullOrWhiteSpace(textFullName.Text))
            {
                MessageBox.Show("Ievadiet pasniedzēja vārdu, uzvārdu!",
                    "Uzmanību!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Teacher.FullName = textFullName.Text.Trim();
            Teacher.Email = textEmail.Text.Trim();
            Teacher.Phone = textPhone.Text.Trim();
            Teacher.Classroom = textClassroom.Text.Trim();

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