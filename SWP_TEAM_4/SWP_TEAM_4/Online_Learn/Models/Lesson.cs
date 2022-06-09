using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public int LectureId { get; set; }
        public int CourseId { get; set; }
        public string LessonName { get; set; }

        public virtual Course Course { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
