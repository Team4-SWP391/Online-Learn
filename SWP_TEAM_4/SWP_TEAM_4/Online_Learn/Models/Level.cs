using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Level
    {
        public Level()
        {
            Courses = new HashSet<Course>();
        }

        public int LevelId { get; set; }
        public string Level1 { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
