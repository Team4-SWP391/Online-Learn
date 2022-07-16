using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models {
    public partial class Lesson {
        public Lesson()
        {
            AccountLessons = new HashSet<AccountLesson>();
        }

        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string Video { get; set; }
        public string Main { get; set; }
        public int? LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<AccountLesson> AccountLessons { get; set; }
    }
}
