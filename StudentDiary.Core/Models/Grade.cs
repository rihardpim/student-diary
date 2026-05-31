using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary.Core.Models
{
    public class Grade // Studenta atzīmju modelis
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public GradeType Type { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; } = string.Empty;

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
