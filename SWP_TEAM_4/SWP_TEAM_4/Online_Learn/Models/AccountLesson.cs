using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class AccountLesson
    {
        public int AccountId { get; set; }
        public int LessonId { get; set; }
<<<<<<< HEAD

        public virtual Account Account { get; set; }
=======
        public int CourseId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Course Course { get; set; }
>>>>>>> f8654a48020cbcb3bcac4c83e7cd5f6e2313d210
        public virtual Lesson Lesson { get; set; }
    }
}
