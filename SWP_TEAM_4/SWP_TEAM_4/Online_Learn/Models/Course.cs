﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models {
    public partial class Course {
        public Course()
        {
            AccountCourses = new HashSet<AccountCourse>();
            AccountLessons = new HashSet<AccountLesson>();
            OrderDetails = new HashSet<OrderDetail>();
            Technologies = new HashSet<Technology>();
            WhistLists = new HashSet<WhistList>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double Price { get; set; }
        public int DepartmentId { get; set; }
        public string Image { get; set; }
        public int? Rate { get; set; }
        public string Language { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public int? IsSale { get; set; }
        public DateTime UpdateAt { get; set; }
        public int LevelId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Department Department { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<AccountCourse> AccountCourses { get; set; }
        public virtual ICollection<AccountLesson> AccountLessons { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
        public virtual ICollection<WhistList> WhistLists { get; set; }
        public double getPriceByDiscount()
        {
            return Price;
        }
    }
}
