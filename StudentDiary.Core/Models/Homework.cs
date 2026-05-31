using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary.Core.Models
{
    public class Homework // Studenta mājasdarbu modelis
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public HomeworkPriority Priority { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
