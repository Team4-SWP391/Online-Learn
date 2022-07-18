using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Result
    {
        public int ResultId { get; set; }
        public int ExamId { get; set; }
        public int? AccountId { get; set; }
        public double? Score { get; set; }
        public int CorrectAnswer { get; set; }
        public string Status { get; set; }
        public int Time { get; set; }

        public virtual Account Account { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
