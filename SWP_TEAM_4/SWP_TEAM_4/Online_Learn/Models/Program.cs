using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Program
    {
        public Program()
        {
            Technologies = new HashSet<Technology>();
        }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }
    }
}
