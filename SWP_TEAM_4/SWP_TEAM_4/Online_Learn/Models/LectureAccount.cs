using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class LectureAccount
    {
        public int AccountId { get; set; }
        public int LectureId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
