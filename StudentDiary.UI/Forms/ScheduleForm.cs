using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using StudentDiary.Core.Models;
using StudentDiary.Data;
using Color = System.Drawing.Color;

namespace StudentDiary.UI.Forms
{
    public partial class ScheduleForm : Form // Forma nodarbību saraksta pārvaldībai kalendāra skatā pa nedēļām
    {
        private DateTime currentWeek; // Pašreizējās nedēļas pirmdienas datums
        private readonly string[] dayNames = // Nedēļas dienu nosaukumi latviešu valodā
        {
            "Pirmdiena", "Otrdiena", "Trešdiena",
            "Ceturtdiena", "Piektdiena", "Sestdiena", "Svētdiena"
        };
        public ScheduleForm() // Izveido kalendāra režģi un ielādē sarakstu
        {
            InitializeComponent();

            currentWeek = GetMonday(DateTime.Today);

            BuildGrid();
            LoadSchedule();
            UpdateWeekLabel();
        }
        private DateTime GetMonday(DateTime date) // Atgriež norādītā datuma pirmdienu
        {
            DayOfWeek day = date.DayOfWeek;
            int dayNumber = day == DayOfWeek.Sunday ? 7 : (int)day;
            int daysToMonday = dayNumber - 1;

            return date.AddDays(-daysToMonday).Date;
        }
        private DateTime GetSemesterStart() // Atgriež semestra sākuma datumu
        {
            int month = DateTime.Today.Month;
            if (month >= 1 && month <= 7)
                return DateTime.Parse($"{DateTime.Today.Year}-02-01");
            return DateTime.Parse($"{DateTime.Today.Year}-09-01");
        }
        private DateTime GetSemesterEnd() // Atgriež pašreizējā semestra beigu datumu
        {
            int month = DateTime.Today.Month;
            if (month >= 1 && month <= 7)
                return DateTime.Parse($"{DateTime.Today.Year}-05-15");
            return DateTime.Parse($"{DateTime.Today.Year}-12-15");
        }
        private bool IsFirstWeek() // Atgriež vai pašreizējā nedēļa ir pirmā vai otrā semestra nedēļa
        {
            DateTime semesterStart = GetSemesterStart();

            if (currentWeek < semesterStart)
                return true;

            int weeksDiff = (int)(currentWeek - semesterStart).TotalDays / 7;
            return weeksDiff % 2 == 0;
        }
        private void BuildGrid() // Izveido kalendāra režģi
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < 7; i++)
            {
                DateTime dayDate = currentWeek.AddDays(i);
                dataGridView1.Columns.Add($"Day{i + 1}",
                    $"{dayNames[i]}\n{dayDate:dd.MM}");
                dataGridView1.Columns[$"Day{i + 1}"]
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 0, 120, 215);
        }
        private void LoadSchedule() // Ielādē nodarbības no datu bāzes un attēlo kalendārā
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < 7; i++)
            {
                DateTime dayDate = currentWeek.AddDays(i);
                dataGridView1.Columns[$"Day{i + 1}"].HeaderText =
                    $"{dayNames[i]}\n{dayDate:dd.MM}";

                dataGridView1.Columns[$"Day{i + 1}"].HeaderCell.Style.BackColor =
                    dayDate.Date == DateTime.Today ? Color.FromArgb(100, 180, 255) : Color.White;
            }

            bool isFirstWeek = IsFirstWeek();
            DateTime semEnd = GetSemesterEnd();

            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                SELECT Schedules.Id, Schedules.ScheduleType,
                       Schedules.DayWeek, Schedules.WeekType,
                       Schedules.SpecificDate, Schedules.StartTime,
                       Schedules.EndTime, Subjects.Name,
                       Subjects.Code, Subjects.CreditPoints,
                       Schedules.Type, Schedules.Room,
                       Teachers.FullName, Schedules.Groups,
                       Schedules.OriginalId
                FROM Schedules
                JOIN Subjects ON Schedules.SubjectId = Subjects.Id
                LEFT JOIN Teachers ON Subjects.TeacherId = Teachers.Id
                ORDER BY Schedules.DayWeek, Schedules.StartTime
    ";
            var columnRowIndex = new Dictionary<string, int>();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var entryType = (ScheduleEntryType)Convert.ToInt32(reader["ScheduleType"]);
                var lessonType = (LessonType)Convert.ToInt32(reader["Type"]);
                int id = Convert.ToInt32(reader["Id"]);
                string start = reader["StartTime"].ToString();
                string subject = reader["Name"].ToString();
                string room = reader["Room"] == DBNull.Value ? "" : reader["Room"].ToString();
                string groups = reader["Groups"] == DBNull.Value ? "Visām grupām" : reader["Groups"].ToString();

                int colIndex = -1;

                if (entryType == ScheduleEntryType.Recurring)
                {
                    int dayWeek = Convert.ToInt32(reader["DayWeek"]);
                    var weekType = (WeekType)Convert.ToInt32(reader["WeekType"]);
                    DateTime lessonDate = currentWeek.AddDays(dayWeek - 1);
                    DateTime semesterStart = GetSemesterStart();
                    if (lessonDate > semEnd || lessonDate < semesterStart)
                        continue;

                    bool showThisWeek = weekType == WeekType.Both || (weekType == WeekType.First && isFirstWeek) ||
                        (weekType == WeekType.Second && !isFirstWeek);

                    if (!showThisWeek) 
                        continue;

                    if (HasOverride(lessonDate, id, connection))
                        continue;

                    colIndex = dayWeek;
                }
                else
                {
                    if (reader["SpecificDate"] == DBNull.Value)
                        continue;

                    DateTime specificDate = DateTime.Parse(
                        reader["SpecificDate"].ToString()!);
                    DateTime weekEnd = currentWeek.AddDays(6);

                    if (specificDate < currentWeek || specificDate > weekEnd)
                        continue;

                    colIndex = specificDate.DayOfWeek == DayOfWeek.Sunday
                        ? 7 : (int)specificDate.DayOfWeek;
                }

                if (colIndex < 1 || colIndex > 7) continue;

                string colName = $"Day{colIndex}";

                if (!columnRowIndex.ContainsKey(colName))
                    columnRowIndex[colName] = 0;

                int rowIndex = columnRowIndex[colName];

                while (dataGridView1.Rows.Count <= rowIndex)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = 150;
                }

                string shortTime = start.Length > 5 ? start.Substring(0, 5) : start;
                string cellText = $"{shortTime} {subject}\n{room}\n{groups}";

                dataGridView1.Rows[rowIndex].Cells[colName].Value = cellText;
                dataGridView1.Rows[rowIndex].Cells[colName].Tag = id;

                Color cellColor;
                switch (lessonType)
                {
                    case LessonType.Lecture:
                        cellColor = Color.FromArgb(180, 210, 255); 
                        break;
                    case LessonType.Practice:
                        cellColor = Color.FromArgb(180, 255, 180); 
                        break;
                    case LessonType.Test:
                        cellColor = Color.FromArgb(255, 180, 180); 
                        break;
                    case LessonType.Consultation:
                        cellColor = Color.FromArgb(255, 245, 180); 
                        break;
                    case LessonType.Cancelled:
                        cellColor = Color.FromArgb(200, 200, 200); 
                        break;
                    case LessonType.Rescheduled:
                        cellColor = Color.FromArgb(255, 200, 130);
                        break;
                    default:
                        cellColor = Color.White;
                        break;
                }

                dataGridView1.Rows[rowIndex].Cells[colName].Style.BackColor = cellColor;

                columnRowIndex[colName] = rowIndex + 1;
            }

            UpdateWeekLabel();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
        }

        // Pārbauda vai regulārajai nodarbībai ir atcelšana vai pārcelšana
        private bool HasOverride(DateTime date, int originalId, SqliteConnection connection)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT COUNT(*) FROM Schedules
                WHERE OriginalId   = @OriginalId
                AND SpecificDate   = @Date
                AND ScheduleType   = 1
                AND (Type = 4 OR Type = 5)
            ";
            cmd.Parameters.AddWithValue("@OriginalId", originalId);
            cmd.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Apstrādā klikšķi uz šūnas - atver nodarbības informāciju
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Tag == null)
                return;

            int id = (int)cell.Tag;
            ShowScheduleInfo(id);
        }

        private void ShowScheduleInfo(int id) // Atver nodarbības informācijas formu
        {
            int scheduleId;
            string code, name, type, day, startTime, endTime, room, teacher, groups, weekText;
            int kp;
            bool isRecurring;
            using (var connection = DatabaseCreation.GetConnection())
            {
                using var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT Schedules.Id, Schedules.ScheduleType,
                           Schedules.DayWeek, Schedules.WeekType,
                           Schedules.SpecificDate, Schedules.StartTime,
                           Schedules.EndTime, Subjects.Name,
                           Subjects.Code, Subjects.CreditPoints,
                           Schedules.Type, Schedules.Room,
                           Teachers.FullName, Schedules.Groups
                    FROM Schedules
                    JOIN Subjects ON Schedules.SubjectId = Subjects.Id
                    LEFT JOIN Teachers ON Subjects.TeacherId = Teachers.Id
                    WHERE Schedules.Id = @Id
                ";
                cmd.Parameters.AddWithValue("@Id", id);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                    return;

                var lessonType = (LessonType)Convert.ToInt32(reader["Type"]);
                var scheduleType = (ScheduleEntryType)Convert.ToInt32(reader["ScheduleType"]);
                var weekType = (WeekType)Convert.ToInt32(reader["WeekType"]);

                scheduleId = Convert.ToInt32(reader["Id"]);
                isRecurring = scheduleType == ScheduleEntryType.Recurring;

                if (scheduleType == ScheduleEntryType.Single && reader["SpecificDate"] != DBNull.Value)
                {
                    DateTime d = DateTime.Parse(reader["SpecificDate"].ToString());
                    day = $"{GetDayName((int)d.DayOfWeek)}, {d:dd.MM.yyyy}";
                }
                else
                {
                    day = GetDayName(Convert.ToInt32(reader["DayWeek"]));
                }

                weekText = isRecurring ? GetWeekTypeName(weekType) : "Vienreizējs";
                code = reader["Code"] == DBNull.Value ? "" : reader["Code"].ToString();
                name = reader["Name"].ToString();
                type = GetLessonTypeName(lessonType);
                startTime = reader["StartTime"].ToString();
                endTime = reader["EndTime"].ToString();
                room = reader["Room"] == DBNull.Value ? "" : reader["Room"].ToString();
                teacher = reader["FullName"] == DBNull.Value ? "" : reader["FullName"].ToString();
                groups = reader["Groups"] == DBNull.Value ? "Visām grupām" : reader["Groups"].ToString();
                kp = Convert.ToInt32(reader["CreditPoints"]);

            }
            var infoForm = new ScheduleInfoForm(
                id: scheduleId,
                code: code,
                name: name,
                type: type,
                day: day,
                startTime: startTime,
                endTime: endTime,
                room: room,
                teacher: teacher,
                groups: groups,
                kp: kp,
                weekText: weekText,
                isRecurring: isRecurring,
                currentWeek: currentWeek
            );
            if (infoForm.ShowDialog() == DialogResult.OK)// Aprēķina nodarbības datumu pašreizējā nedēļā
                LoadSchedule();
        }

        private string GetWeekTypeName(WeekType weekType) // Atgriež nedēļas tipa nosaukumu latviešu valodā
        {
            switch (weekType)
            {
                case WeekType.First:
                    return "1. nedēļa";
                case WeekType.Second:
                    return "2. nedēļa";
                case WeekType.Both:
                    return "Katru nedēļu";
                default: return "";
            }
        }

        private string GetDayName(int day) // // Atgriež nedēļas dienas nosaukumu latviešu valodā
        {
            switch (day)
            {
                case 1:
                    return "Pirmdiena";
                case 2:
                    return "Otrdiena";
                case 3:
                    return "Trešdiena";
                case 4:
                    return "Ceturtdiena";
                case 5:
                    return "Piektdiena";
                case 6:
                    return "Sestdiena";
                case 7:
                    return "Svētdiena";
                default:
                    return "";
            }
        }

        private string GetLessonTypeName(LessonType type) // Atgriež nodarbības veida nosaukumu latviešu valodā
        {
            switch (type)
            {
                case LessonType.Lecture:
                    return "Lekcija";
                case LessonType.Practice:
                    return "Prakt. darbi";
                case LessonType.Test:
                    return "Tests";
                case LessonType.Consultation:
                    return "Konsultācija";
                case LessonType.Cancelled:
                    return "Atcelts";
                case LessonType.Rescheduled:
                    return "Pārcelts";
                default:
                    return "Cits";
            }
        }
        private void buttonPrevWeek_Click(object sender, EventArgs e) // Pāriet uz iepriekšējo nedēļu
        {
            DateTime semesterStart = GetMonday(GetSemesterStart());
            currentWeek = currentWeek.AddDays(-7);
            LoadSchedule();
        }

        private void buttonNextWeek_Click(object sender, EventArgs e) // Pāriet uz nākamo nedēļu
        {
            currentWeek = currentWeek.AddDays(7);
            LoadSchedule();
        }

        private void buttonToday_Click(object sender, EventArgs e) // Pāriet uz šo nedēļu
        {
            currentWeek = GetMonday(DateTime.Today);
            LoadSchedule();
        }

        private void UpdateWeekLabel() // Atjaunina nedēļas datuma
        {
            DateTime weekEnd = currentWeek.AddDays(6);
            labelWeek.Text = $"{currentWeek:dd.MM.yyyy} – {weekEnd:dd.MM.yyyy}";
        }

        private void buttonAdd_Click(object sender, EventArgs e) // Atver pievienošanas formu un saglabā jaunu nodarbību
        {
            var dialog = new ScheduleAddForm(currentWeek);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AddSchedule(dialog.Schedule);
                LoadSchedule();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) // Atver rediģēšanas formu izvēlētajai nodarbībai
        {
            if (dataGridView1.CurrentCell?.Tag == null)
            {
                MessageBox.Show("Izvēlieties nodarbību!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dataGridView1.CurrentCell.Tag;

            var dialog = new ScheduleAddForm(GetScheduleById(id));
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UpdateSchedule(dialog.Schedule);
                LoadSchedule();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) // Dzēš izvēlēto nodarbību
        {
            if (dataGridView1.CurrentCell?.Tag == null)
            {
                MessageBox.Show("Izvēlieties nodarbību!",
                    "Uzmanību", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Dzēst izvēlēto nodarbību?",
                "Apstiprinājums",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridView1.CurrentCell.Tag;
                DeleteSchedule(id);
                LoadSchedule();
            }
        }

        // SQL metodi
        private void AddSchedule(Schedule schedule) // Saglabā jaunu nodarbību datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                INSERT INTO Schedules
                    (ScheduleType, DayWeek, WeekType, SpecificDate,
                     StartTime, EndTime, Room, Type, Groups, SubjectId, OriginalId)
                VALUES
                    (@ScheduleType, @DayWeek, @WeekType, @SpecificDate,
                     @StartTime, @EndTime, @Room, @Type, @Groups, @SubjectId, @OriginalId)
            ";

            cmd.Parameters.AddWithValue("@ScheduleType", (int)schedule.ScheduleType);
            cmd.Parameters.AddWithValue("@DayWeek", schedule.DayWeek);
            cmd.Parameters.AddWithValue("@WeekType", (int)schedule.WeekType);
            cmd.Parameters.AddWithValue("@SpecificDate", schedule.SpecificDate.HasValue ? schedule.SpecificDate.Value.ToString("yyyy-MM-dd") : DBNull.Value);
            cmd.Parameters.AddWithValue("@StartTime", schedule.StartTime.ToString());
            cmd.Parameters.AddWithValue("@EndTime", schedule.EndTime.ToString());
            cmd.Parameters.AddWithValue("@Room", schedule.Room);
            cmd.Parameters.AddWithValue("@Type", (int)schedule.Type);
            cmd.Parameters.AddWithValue("@Groups", schedule.Groups);
            cmd.Parameters.AddWithValue("@SubjectId", schedule.SubjectId);
            cmd.Parameters.AddWithValue("@OriginalId", schedule.OriginalId.HasValue ? schedule.OriginalId.Value : DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        private void UpdateSchedule(Schedule schedule) // Atjaunina esošās nodarbības datus datu bāzē
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = @"
                UPDATE Schedules
                SET ScheduleType = @ScheduleType,
                    DayWeek      = @DayWeek,
                    WeekType     = @WeekType,
                    SpecificDate = @SpecificDate,
                    StartTime    = @StartTime,
                    EndTime      = @EndTime,
                    Room         = @Room,
                    Type         = @Type,
                    Groups       = @Groups,
                    SubjectId    = @SubjectId
                WHERE Id = @Id
            ";

            cmd.Parameters.AddWithValue("@Id", schedule.Id);
            cmd.Parameters.AddWithValue("@ScheduleType", (int)schedule.ScheduleType);
            cmd.Parameters.AddWithValue("@DayWeek", schedule.DayWeek);
            cmd.Parameters.AddWithValue("@WeekType", (int)schedule.WeekType);
            cmd.Parameters.AddWithValue("@SpecificDate", schedule.SpecificDate.HasValue ? schedule.SpecificDate.Value.ToString("yyyy-MM-dd") : DBNull.Value);
            cmd.Parameters.AddWithValue("@StartTime", schedule.StartTime.ToString());
            cmd.Parameters.AddWithValue("@EndTime", schedule.EndTime.ToString());
            cmd.Parameters.AddWithValue("@Room", schedule.Room);
            cmd.Parameters.AddWithValue("@Type", (int)schedule.Type);
            cmd.Parameters.AddWithValue("@Groups", schedule.Groups);
            cmd.Parameters.AddWithValue("@SubjectId", schedule.SubjectId);

            cmd.ExecuteNonQuery();
        }

        private void DeleteSchedule(int id) // Dzēš nodarbību no datu bāzes pēc ID
        {
            using var connection = DatabaseCreation.GetConnection();
            using var cmd = connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Schedules WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        private Schedule GetScheduleById(int id) // Atgriež nodarbības datus no datu bāzes pēc ID
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
                DayWeek = reader["DayWeek"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DayWeek"]),
                WeekType = reader["WeekType"] == DBNull.Value ? WeekType.Both : (WeekType)Convert.ToInt32(reader["WeekType"]),
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