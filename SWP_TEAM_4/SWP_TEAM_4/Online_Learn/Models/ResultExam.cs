using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class ResultExam
    {
        public int ResultId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Result Result { get; set; }
    }
}
