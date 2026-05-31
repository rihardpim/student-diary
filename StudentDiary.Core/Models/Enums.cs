using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary.Core.Models
{
    public enum GradeType
    {
        Exam,
        Test,
        Lab,
        Homework,
        Oral
    }

    public enum HomeworkPriority
    {
        Low,
        Medium,
        High
    }

    public enum DeadlineType
    {
        Exam,
        Test,
        Lab,
        Homework,
        Coursework,
        Other
    }

    public enum LessonType
    {
        Lecture,
        Practice,
        Test,
        Consultation,
        Cancelled,
        Rescheduled
    }

    public enum ScheduleEntryType // Nodarbības ieraksta veids sarakstā
    {
        Recurring,  // Atkārtojas
        Single      // Vienvietīga
    }

    public enum WeekType
    {
        First,  // 1. nedēļa
        Second, // 2. nedēļa
        Both    // Katra nedēļa
    }
}
