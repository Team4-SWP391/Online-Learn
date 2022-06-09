using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Department
    {
        public Department()
        {
            Blogs = new HashSet<Blog>();
            Courses = new HashSet<Course>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
