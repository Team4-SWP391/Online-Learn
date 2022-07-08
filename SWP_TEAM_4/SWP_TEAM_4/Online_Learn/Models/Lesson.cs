using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string Video { get; set; }
        public string Main { get; set; }
        public int? LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}
