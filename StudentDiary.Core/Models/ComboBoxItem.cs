using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDiary.Core.Models
{
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString() { return Name; }
    }
}
