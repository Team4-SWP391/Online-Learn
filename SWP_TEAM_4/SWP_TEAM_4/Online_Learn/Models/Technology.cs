using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Technology
    {
        public int CourseId { get; set; }
        public int ProgramId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Program Program { get; set; }
    }
}
