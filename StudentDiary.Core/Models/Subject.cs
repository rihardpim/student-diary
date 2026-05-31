using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary.Core.Models
{
    public class Subject // Studenta priekšmetiem modelis
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Part { get; set; } = string.Empty;
        public int CreditPoints { get; set; }
        public int Ects { get; set; }
        public int Semester { get; set; }

        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
