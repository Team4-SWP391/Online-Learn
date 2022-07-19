using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Online_Learn.Models
{
    public partial class Online_LearnContext : DbContext
    {
        public Online_LearnContext()
        {
        }

        public Online_LearnContext(DbContextOptions<Online_LearnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountCourse> AccountCourses { get; set; }
        public virtual DbSet<AccountLesson> AccountLessons { get; set; }
        public virtual DbSet<AccountToken> AccountTokens { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FeedbackAccount> FeedbackAccounts { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<LectureAccount> LectureAccounts { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<WhistList> WhistLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-UKC2529\\TUAN; database=Online_Learn;uid=sa;pwd=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Desc).HasColumnName("desc");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FulllName).HasColumnName("fulll_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Language)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<AccountCourse>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.CourseId });

                entity.ToTable("Account_Course");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountCourses)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Course_Account");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AccountCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Course_Course");
            });

            modelBuilder.Entity<AccountLesson>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.LessonId });

                entity.ToTable("Account_Lesson");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.LessonId).HasColumnName("lesson_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountLessons)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Lesson_Account");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.AccountLessons)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Lesson_Lesson");
            });

            modelBuilder.Entity<AccountToken>(entity =>
            {
                entity.HasKey(e => e.AtId);

                entity.ToTable("Account_Token");

                entity.Property(e => e.AtId).HasColumnName("at_id");

                entity.Property(e => e.CreateToken)
                    .HasColumnType("datetime")
                    .HasColumnName("create_token")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Token)
                    .HasMaxLength(50)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).HasColumnName("blog_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Account");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Department");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("course_name");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.IsSale).HasColumnName("is_sale");

                entity.Property(e => e.Language)
                    .IsUnicode(false)
                    .HasColumnName("language");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Account");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Department");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Level");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("exam_name");

                entity.Property(e => e.LectureId).HasColumnName("lecture_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Lecture");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId)
                    .ValueGeneratedNever()
                    .HasColumnName("feedback_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Massage).HasColumnName("massage");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Feedback_Course");
            });

            modelBuilder.Entity<FeedbackAccount>(entity =>
            {
                entity.HasKey(e => new { e.FeedbackId, e.AccountId });

                entity.ToTable("Feedback_Account");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FeedbackAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Account_Account");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.FeedbackAccounts)
                    .HasForeignKey(d => d.FeedbackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Account_Feedback");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lecture");

                entity.Property(e => e.LectureId).HasColumnName("lecture_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.LectureName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("lecture_name");
            });

            modelBuilder.Entity<LectureAccount>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.LectureId });

                entity.ToTable("Lecture_Account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.LectureId).HasColumnName("lecture_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.LectureAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_Account_Account");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.LectureAccounts)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_Account_Lecture");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.LessonId).HasColumnName("lesson_id");

                entity.Property(e => e.LectureId).HasColumnName("lecture_id");

                entity.Property(e => e.LessonName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("lesson_name");

                entity.Property(e => e.Main).HasColumnName("main");

                entity.Property(e => e.Video)
                    .IsRequired()
                    .HasColumnName("video");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_Lesson_Lecture");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelId).HasColumnName("level_id");

                entity.Property(e => e.Level1)
                    .IsUnicode(false)
                    .HasColumnName("level");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Order_Account");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Detail");

                entity.Property(e => e.OrderdetailId).HasColumnName("orderdetail_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Order_Detail_Course");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_Detail_Order");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("Program");

                entity.Property(e => e.ProgramId).HasColumnName("program_id");

                entity.Property(e => e.ProgramName)
                    .IsUnicode(false)
                    .HasColumnName("program_name");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.LectureId).HasColumnName("lecture_id");

                entity.Property(e => e.Op1)
                    .IsRequired()
                    .HasColumnName("op1");

                entity.Property(e => e.Op2)
                    .IsRequired()
                    .HasColumnName("op2");

                entity.Property(e => e.Op3)
                    .IsRequired()
                    .HasColumnName("op3");

                entity.Property(e => e.Op4)
                    .IsRequired()
                    .HasColumnName("op4");

                entity.Property(e => e.Quiz)
                    .IsRequired()
                    .HasColumnName("quiz");

                entity.Property(e => e.Solution)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("solution");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.LectureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Lecture");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CorrectAnswer).HasColumnName("correctAnswer");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Result_Account");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Result_Exam1");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.ProgramId });

                entity.ToTable("Technology");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.ProgramId).HasColumnName("program_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Technology_Course");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Technology_Program");
            });

            modelBuilder.Entity<WhistList>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.CourseId });

                entity.ToTable("WhistList");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.WhistLists)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WhistList_Account");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.WhistLists)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WhistList_Course");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
