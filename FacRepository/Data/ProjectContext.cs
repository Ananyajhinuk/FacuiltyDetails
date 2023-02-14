using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FacRepository.Data
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CoursesTaught> CoursesTaughts { get; set; } = null!;
        public virtual DbSet<Degree> Degrees { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Designation> Designations { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Publication> Publications { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<UserAdministrator> UserAdministrators { get; set; } = null!;
        public virtual DbSet<UserFaculty> UserFaculties { get; set; } = null!;
        public virtual DbSet<UserStudent> UserStudents { get; set; } = null!;
        public virtual DbSet<WorkHistory> WorkHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=Project; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("fk_Courses_DeptId");

                entity.HasMany(d => d.Subjects)
                    .WithMany(p => p.Courses)
                    .UsingEntity<Dictionary<string, object>>(
                        "CourseSubject",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("SubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CourseSubjects_SubjectId"),
                        r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_CourseSubjects_CourseId"),
                        j =>
                        {
                            j.HasKey("CourseId", "SubjectId").HasName("PK__CourseSu__53ECCB9DEF31C9C1");

                            j.ToTable("CourseSubjects");
                        });
            });

            modelBuilder.Entity<CoursesTaught>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.FacultyId, e.SubjectId })
                    .HasName("PK__CoursesT__93879C34AF3488F9");

                entity.ToTable("CoursesTaught");

                entity.Property(e => e.FirstDateTaught).HasColumnType("date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesTaughts)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoursesTaught_CourseId");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.CoursesTaughts)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoursesTaught_FacultyId");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.CoursesTaughts)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CoursesTaught_SubjectId");
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.Property(e => e.DegreeId).ValueGeneratedNever();

                entity.Property(e => e.Degree1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Degree");

                entity.Property(e => e.DegreeYear).HasColumnType("date");

                entity.Property(e => e.Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Degrees)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("fk_Degrees_FacultyId");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__014881AE36B70492");

                entity.Property(e => e.DeptId).ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.DesignationId).ValueGeneratedNever();

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.FacultyId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateofBirth).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("fk_Faculties_DeptId");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("fk_Faculties_DesignationId");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(e => e.PublicationId).ValueGeneratedNever();

                entity.Property(e => e.ArticleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CitationDate).HasColumnType("date");

                entity.Property(e => e.PublicationLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublicationTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("fk_Publications_FacultyId");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAdministrator>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserAdmi__1788CC4C38BCE41D");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserFaculty>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserFacu__1788CC4CEB0EB435");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserStudent>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserStud__1788CC4C38323F93");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkHistory>(entity =>
            {
                entity.Property(e => e.WorkHistoryId).ValueGeneratedNever();

                entity.Property(e => e.JobBeginDate).HasColumnType("date");

                entity.Property(e => e.JobEndDate).HasColumnType("date");

                entity.Property(e => e.JobResponsibilities)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Organization)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.WorkHistories)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("fk_WorkHistories_FacultyId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
