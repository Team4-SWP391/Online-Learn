using System;
using System.Collections.Generic;

namespace Online_Learn.Models
{
    public class Lecture
    {
        public Lecture()
        {
            Exams = new HashSet<Exam>();
            LectureAccounts = new HashSet<LectureAccount>();
            Lessons = new HashSet<Lesson>();
            Questions = new HashSet<Question>();
        }

        public int LectureId { get; set; }
        public string LectureName { get; set; }
        public int? CourseId { get; set; }
        public DateTime? CreateAt { get; set; }
        public string Description { get; set; }

        public Course Course { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<LectureAccount> LectureAccounts { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
