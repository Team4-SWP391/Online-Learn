using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class FeedbackAccount
    {
        public int FeedbackId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Feedback Feedback { get; set; }
    }
}
