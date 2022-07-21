using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Online_Learn.Models {
    public partial class Blog {
        public Blog()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int BlogId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Write your title...")]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdateAt { get; set; }
        public int DepartmentId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
