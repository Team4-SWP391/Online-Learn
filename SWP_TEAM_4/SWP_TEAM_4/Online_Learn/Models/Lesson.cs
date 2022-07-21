using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            AccountLessons = new HashSet<AccountLesson>();
        }

        public int LessonId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lesson Name is requried...")]
        public string LessonName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Video is requỉed...")]
        public string Video { get; set; }
        public string Main { get; set; }
        public int? LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<AccountLesson> AccountLessons { get; set; }
    }
}
