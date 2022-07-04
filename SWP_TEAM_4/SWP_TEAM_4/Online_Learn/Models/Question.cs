using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string Quiz { get; set; }
        public string Op1 { get; set; }
        public string Op2 { get; set; }
        public string Op3 { get; set; }
        public string Op4 { get; set; }
        public string Solution { get; set; }
        public int LectureId { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}
