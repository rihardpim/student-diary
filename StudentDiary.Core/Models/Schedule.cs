using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary.Core.Models
{
    public class Schedule // Studenta saraksta modelis
    {
        public int Id { get; set; }
        public ScheduleEntryType ScheduleType { get; set; }

        // Par atkārtojošajiem
        public int DayWeek { get; set; }  // 1-7
        public WeekType WeekType { get; set; }  // 1/2/Both

        // Vienvietīgajiem
        public DateTime? SpecificDate { get; set; }

        // Kopējie lauki
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Room { get; set; } = string.Empty;
        public LessonType Type { get; set; }
        public string Groups { get; set; } = "Visām grupām";
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int? OriginalId { get; set; } // Pārnesumiem
    }
}
