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
    public partial class ScheduleInfoForm : Form // Forma nodarbības detalizētas informācijas apskatei
    {
        private readonly int scheduleId; // Apskatāmās nodarbības ID
        private readonly bool isRecurring; // Norāda vai nodarbība ir regulāra
        private readonly DateTime currentWeek;

        public ScheduleInfoForm( // Inicializē formu un attēlo nodarbības informāciju
            int id,
            string code,
            string name,
            string type,
            string day,
            string startTime,
            string endTime,
            string room,
            string teacher,
            string groups,
            int kp,
            string weekText,
            bool isRecurring,
            DateTime currentWeek)
        {
            InitializeComponent();

            scheduleId = id;
            this.isRecurring = isRecurring;
            this.currentWeek = currentWeek;
            labelCode.Text = $"{code} {name} {kp}KP";
            labelType.Text = type;
            labelGroup.Text = groups;
            labelDay.Text = $"{day}, {startTime} – {endTime}";
            labelWeek.Text = weekText;
            labelRoom.Text = string.IsNullOrEmpty(room) ? "Nav" : $"Telpa: {room}";
            labelTeacher.Text = string.IsNullOrEmpty(teacher) ? "Nav" : teacher;
            buttonCancel.Visible = isRecurring;
            buttonReschedule.Visible = isRecurring;
        }
        private void buttonClose_Click(object sender, EventArgs e) // Aizver formu bez izmaiņām
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e) // Atcel nodarbību
        {
            var result = MessageBox.Show("Atcelt šo nodarbību?",
                "Apstiprinājums", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No) 
                return;

            var original = GetScheduleById(scheduleId);
            DateTime lessonDate = GetLessonDate(original);
            CreateOverride(original, lessonDate, LessonType.Cancelled);

            MessageBox.Show("Nodarbība atcelta!",
                "Gatavs", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonReschedule_Click(object sender, EventArgs e) // Pārcel nodarbību
        {
            var rescheduleForm = new ScheduleRescheduleForm(scheduleId);
            if (rescheduleForm.ShowDialog() == DialogResult.OK)
            {
                var original = GetScheduleById(scheduleId);
                DateTime lessonDate = GetLessonDate(original);
                CreateOverride(original, lessonDate, LessonType.Cancelled);
                CreateRescheduled(original, rescheduleForm.NewDate);

                MessageBox.Show("Nodarbība pārcelta!",
                    "Gatavs",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private DateTime GetLessonDate(Schedule schedule) // Aprēķina nodarbības datumu šo nedēļā
        {
            return currentWeek.AddDays(schedule.DayWeek - 1);
        }

        private void CreateOverride(Schedule original, DateTime date, LessonType type) // Izveido vienreizēju ierakstu datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Schedules
                    (ScheduleType, SpecificDate, StartTime, EndTime,
                     Room, Type, Groups, SubjectId, OriginalId)
                VALUES
                    (1, @Date, @StartTime, @EndTime,
                     @Room, @Type, @Groups, @SubjectId, @OriginalId)
            ";

            cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@StartTime", original.StartTime.ToString());
            cmd.Parameters.AddWithValue("@EndTime", original.EndTime.ToString());
            cmd.Parameters.AddWithValue("@Room", original.Room);
            cmd.Parameters.AddWithValue("@Type", (int)type);
            cmd.Parameters.AddWithValue("@Groups", original.Groups);
            cmd.Parameters.AddWithValue("@SubjectId", original.SubjectId);
            cmd.Parameters.AddWithValue("@OriginalId", original.Id);

            cmd.ExecuteNonQuery();
        }
        private void CreateRescheduled(Schedule original, DateTime newDate) // Izveido pārceltās nodarbības ierakstu datu bāzē jaunajā datumā
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Schedules
                    (ScheduleType, SpecificDate, StartTime, EndTime,
                     Room, Type, Groups, SubjectId, OriginalId)
                VALUES
                    (1, @Date, @StartTime, @EndTime,
                     @Room, @Type, @Groups, @SubjectId, @OriginalId)
            ";

            cmd.Parameters.AddWithValue("@Date", newDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@StartTime", original.StartTime.ToString());
            cmd.Parameters.AddWithValue("@EndTime", original.EndTime.ToString());
            cmd.Parameters.AddWithValue("@Room", original.Room);
            cmd.Parameters.AddWithValue("@Type", (int)LessonType.Rescheduled);
            cmd.Parameters.AddWithValue("@Groups", original.Groups);
            cmd.Parameters.AddWithValue("@SubjectId", original.SubjectId);
            cmd.Parameters.AddWithValue("@OriginalId", original.Id);

            cmd.ExecuteNonQuery();
        }

        private Schedule GetScheduleById(int id) // Iegūst nodarbības datus no datubāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Id, ScheduleType, DayWeek, WeekType,
                       SpecificDate, StartTime, EndTime,
                       Room, Type, Groups, SubjectId, OriginalId
                FROM Schedules WHERE Id = @Id
            ";
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            reader.Read();

            return new Schedule
            {
                Id = Convert.ToInt32(reader["Id"]),
                ScheduleType = (ScheduleEntryType)Convert.ToInt32(reader["ScheduleType"]),
                DayWeek = Convert.ToInt32(reader["DayWeek"]),
                WeekType = (WeekType)Convert.ToInt32(reader["WeekType"]),
                SpecificDate = reader["SpecificDate"] == DBNull.Value ? null : DateTime.Parse(reader["SpecificDate"].ToString()),
                StartTime = TimeSpan.Parse(reader["StartTime"].ToString()),
                EndTime = TimeSpan.Parse(reader["EndTime"].ToString()),
                Room = reader["Room"] == DBNull.Value ? "" : reader["Room"].ToString(),
                Type = (LessonType)Convert.ToInt32(reader["Type"]),
                Groups = reader["Groups"] == DBNull.Value ? "Visām grupām" : reader["Groups"].ToString(),
                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                OriginalId = reader["OriginalId"] == DBNull.Value ? null : Convert.ToInt32(reader["OriginalId"])
            };
        }
    }
}