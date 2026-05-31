using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDiary.UI.Forms
{
    public partial class ScheduleRescheduleForm : Form // Forma nodarbības pārcelšanas datuma izvēlei
    {
        public DateTime NewDate { get; private set; } // Izvēlētais jaunais nodarbības datums (tikai lasīšana ārpus)

        private readonly int scheduleId; // Pārcēlāmās nodarbības ID

        public ScheduleRescheduleForm(int scheduleId) // Inicializē formu
        {
            InitializeComponent();

            this.scheduleId = scheduleId;

            dateTimeNew.MinDate = DateTime.Today.AddDays(1);
            dateTimeNew.Value = DateTime.Today.AddDays(1); 
        }

        private void buttonSave_Click(object sender, EventArgs e) // Saglabā izvēlēto datumu un aizver formu
        {
            NewDate = dateTimeNew.Value.Date;
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