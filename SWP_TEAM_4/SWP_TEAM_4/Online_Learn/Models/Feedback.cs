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
        public int? BlogId { get; set; }
        public string Message { get; set; }
        public int? Rate { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual ICollection<FeedbackAccount> FeedbackAccounts { get; set; }
    }
}
