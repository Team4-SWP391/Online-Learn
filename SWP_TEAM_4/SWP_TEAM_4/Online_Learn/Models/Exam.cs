using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Results = new HashSet<Result>();
        }

        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int? Quantity { get; set; }
        public int? Time { get; set; }
        public DateTime? StartDate { get; set; }
        public int? LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
