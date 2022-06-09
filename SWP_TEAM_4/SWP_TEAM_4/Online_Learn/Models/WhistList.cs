using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class WhistList
    {
        public int AccountId { get; set; }
        public int CourseId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Course Course { get; set; }
    }
}
