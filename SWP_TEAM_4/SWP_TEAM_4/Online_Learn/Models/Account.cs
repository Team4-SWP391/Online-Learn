using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountCourses = new HashSet<AccountCourse>();
            Blogs = new HashSet<Blog>();
            Courses = new HashSet<Course>();
            FeedbackAccounts = new HashSet<FeedbackAccount>();
            LectureAccounts = new HashSet<LectureAccount>();
            Orders = new HashSet<Order>();
            ResultExams = new HashSet<ResultExam>();
            WhistLists = new HashSet<WhistList>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FulllName { get; set; }
        public int? RoleId { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Language { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public int? Amount { get; set; }
        public string? Desc { get; set; }

        public virtual ICollection<AccountCourse> AccountCourses { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<FeedbackAccount> FeedbackAccounts { get; set; }
        public virtual ICollection<LectureAccount> LectureAccounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ResultExam> ResultExams { get; set; }
        public virtual ICollection<WhistList> WhistLists { get; set; }
    }
}
