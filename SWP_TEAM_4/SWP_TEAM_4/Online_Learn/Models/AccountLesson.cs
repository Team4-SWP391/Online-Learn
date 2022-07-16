using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class AccountLesson
    {
        public int AccountId { get; set; }
        public int LessonId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
