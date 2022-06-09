using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Feedback
    {
        public Feedback()
        {
            FeedbackAccounts = new HashSet<FeedbackAccount>();
        }

        public int FeedbackId { get; set; }
        public int? CourseId { get; set; }
        public string Massage { get; set; }
        public int? Rate { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<FeedbackAccount> FeedbackAccounts { get; set; }
    }
}
