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
using ScottPlot.ArrowShapes;

namespace StudentDiary.UI.Forms
{
    public partial class ScheduleAddForm : Form // Forma nodarbību pievienošanai un rediģēšanai
    {
        public Schedule Schedule { get; private set; } // Nodarbību objekts ar datiem (tikai lasīšana ārpus)

        // Nodarbību sākuma laiki
        private readonly string[] startTimes =
        {
            "08:00", "09:45", "11:30",
            "14:00", "15:45", "17:30", "19:15"
        };
        // Nodarbību beigu laiki — atbilst startTimes pēc indeksa
        private readonly string[] endTimes =
        {
            "09:35", "11:20", "13:05",
            "15:35", "17:20", "19:05", "20:50"
        };
        public ScheduleAddForm(DateTime currentWeekStart) // Konstruktors jaunas nodarbības pievienošanai
        {
            InitializeComponent();
            this.Text = "Pievienot nodarbību";
            Schedule = new Schedule();

            LoadDays();
            LoadWeekTypes();
            LoadStartTimes();
            LoadSubjects();
            LoadTypes();
            LoadGroups();

            dateTimeDate.MinDate = DateTime.Today.AddDays(1);
            dateTimeDate.Value = DateTime.Today.AddDays(1);
        }


        public ScheduleAddForm(Schedule schedule) // Konstruktors esošās nodarbības rediģēšanai
        {
            InitializeComponent();
            this.Text = "Labot nodarbību";
            Schedule = schedule;

            LoadDays();
            LoadWeekTypes();
            LoadStartTimes();
            LoadSubjects();
            LoadTypes();
            LoadGroups();

            if (schedule.ScheduleType == ScheduleEntryType.Recurring)
            {
                radioRecurring.Checked = true;
                comboDay.SelectedIndex = schedule.DayWeek - 1;
                comboWeek.SelectedIndex = (int)schedule.WeekType;
            }
            else
            {
                radioSingle.Checked = true;
                if (schedule.SpecificDate != null)
                    dateTimeDate.Value = schedule.SpecificDate.Value;
            }

            string startTime = schedule.StartTime.ToString(@"hh\:mm");
            for (int i = 0; i < startTimes.Length; i++)
            {
                if (startTimes[i] == startTime)
                {
                    comboStartTime.SelectedIndex = i;
                    break;
                }
            }

            textRoom.Text = schedule.Room;
            comboType.SelectedIndex = (int)schedule.Type;

            for (int i = 0; i < comboGroups.Items.Count; i++)
            {
                if (comboGroups.Items[i].ToString() == schedule.Groups)
                {
                    comboGroups.SelectedIndex = i;
                    break;
                }
            }

            foreach (ComboBoxItem item in comboSubject.Items)
            {
                if (item.Id == schedule.SubjectId)
                {
                    comboSubject.SelectedItem = item;
                    break;
                }
            }
        }

        private void LoadDays() // Ielādē nedēļas dienas combobox
        {
            comboDay.Items.Clear();
            comboDay.Items.Add("Pirmdiena");
            comboDay.Items.Add("Otrdiena");
            comboDay.Items.Add("Trešdiena");
            comboDay.Items.Add("Ceturtdiena");
            comboDay.Items.Add("Piektdiena");
            comboDay.Items.Add("Sestdiena");
            comboDay.Items.Add("Svētdiena");
            comboDay.SelectedIndex = 0;
        }

        private void LoadWeekTypes() // // Ielādē nedēļas tipus combobox
        {
            comboWeek.Items.Clear();
            comboWeek.Items.Add("1. nedēļa");
            comboWeek.Items.Add("2. nedēļa");
            comboWeek.Items.Add("Katru nedēļu");
            comboWeek.SelectedIndex = 2;
        }

        private void LoadStartTimes() // Ielādē nodarbību sākuma laikus combobox
        {
            comboStartTime.Items.Clear();
            foreach (var time in startTimes)
                comboStartTime.Items.Add(time);
            comboStartTime.SelectedIndex = 0;
            UpdateEndTime();
        }

        private void LoadSubjects() // Ielādē priekšmetu sarakstu no datu bāzes
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
                    Name = reader["Name"].ToString()!
                });
            }

            if (comboSubject.Items.Count > 0)
                comboSubject.SelectedIndex = 0;
        }

        private void LoadTypes() // Ielādē nodarbību veidus combobox
        {
            comboType.Items.Clear();
            comboType.Items.Add("Lekcija");
            comboType.Items.Add("Prakt. darbi");
            comboType.Items.Add("Kontroldarbs");
            comboType.Items.Add("Konsultācija");
            comboType.Items.Add("Atcelts");
            comboType.Items.Add("Pārcelts");
            comboType.SelectedIndex = 0;
        }

        private void LoadGroups() // Ielādē grupu sarakstu combobox
        {
            comboGroups.Items.Clear();
            comboGroups.Items.Add("Visām grupām");
            comboGroups.Items.Add("1");
            comboGroups.Items.Add("2");
            comboGroups.Items.Add("3");
            comboGroups.SelectedIndex = 0;
        }

        // Pārslēdz starp regulāras un vienreizējas nodarbības paneli
        private void radiobRecurring_CheckedChanged(object sender, EventArgs e)
        {
            panelRecurring.Visible = radioRecurring.Checked;
            panelSingle.Visible = !radioRecurring.Checked;
        }

        private void radioSingle_CheckedChanged(object sender, EventArgs e)
        {
            panelSingle.Visible = radioSingle.Checked;
            panelRecurring.Visible = !radioSingle.Checked;
        }

        // Atjaunina beigu laiku automātiski pēc sākuma laika maiņas
        private void comboStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEndTime();
        }

        private void UpdateEndTime()
        {
            int index = comboStartTime.SelectedIndex;
            if (index >= 0)
                textEndTime.Text = endTimes[index];
        }

        private void buttonSave_Click(object sender, EventArgs e) // saglabā nodarbību un aizver formu
        {
            if (comboSubject.SelectedItem == null)
            {
                MessageBox.Show("Izvēlieties priekšmetu!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var subject = (ComboBoxItem)comboSubject.SelectedItem;
            int index = comboStartTime.SelectedIndex;
            string start = startTimes[index];
            string end = endTimes[index];

            Schedule.StartTime = TimeSpan.Parse(start);
            Schedule.EndTime = TimeSpan.Parse(end);
            Schedule.Room = textRoom.Text.Trim();
            Schedule.Type = (LessonType)comboType.SelectedIndex;
            Schedule.Groups = comboGroups.SelectedItem.ToString();
            Schedule.SubjectId = subject.Id;

            if (radioRecurring.Checked)
            {
                Schedule.ScheduleType = ScheduleEntryType.Recurring;
                Schedule.DayWeek = comboDay.SelectedIndex + 1;
                Schedule.WeekType = (WeekType)comboWeek.SelectedIndex;
                Schedule.SpecificDate = null;
            }
            else
            {
                Schedule.ScheduleType = ScheduleEntryType.Single;
                Schedule.SpecificDate = dateTimeDate.Value.Date;
                Schedule.DayWeek = 0;
                Schedule.WeekType = WeekType.Both;
            }

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