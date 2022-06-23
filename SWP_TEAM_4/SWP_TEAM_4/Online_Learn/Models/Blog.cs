using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models {
    public partial class Blog {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? DepartmentId { get; set; }
        public string Content { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Department Department { get; set; }
    }
}
