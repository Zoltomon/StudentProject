using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models;

public partial class TestDataBaseContext : DbContext
{
    public TestDataBaseContext()
    {
    }

    public TestDataBaseContext(DbContextOptions<TestDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DirectionOfStudent> DirectionOfStudents { get; set; }

    public virtual DbSet<GradeStudent> GradeStudents { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonsStudent> LessonsStudents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusStudent> StatusStudents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=81.177.6.104;user=prof_user1;database=TestDataBase;password=WsrWsrWsr2021$", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.19-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DirectionOfStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DirectionOfStudent");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CodeDirection).HasMaxLength(100);
            entity.Property(e => e.NameDirection).HasMaxLength(100);
        });

        modelBuilder.Entity<GradeStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("GradeStudent");

            entity.HasIndex(e => e.StudentId, "GradeStudent_FK");

            entity.HasIndex(e => e.SubjectId, "GradeStudent_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.StudentId).HasColumnType("int(11)");
            entity.Property(e => e.SubjectId).HasColumnType("int(11)");

            entity.HasOne(d => d.Student).WithMany(p => p.GradeStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("GradeStudent_FK");

            entity.HasOne(d => d.Subject).WithMany(p => p.GradeStudents)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("GradeStudent_FK_1");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Group");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameGroup).HasMaxLength(100);
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameLessons).HasMaxLength(100);
        });

        modelBuilder.Entity<LessonsStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("LessonsStudent");

            entity.HasIndex(e => e.StudentId, "LessonsStudent_FK");

            entity.HasIndex(e => e.LessonsId, "LessonsStudent_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.LessonsId).HasColumnType("int(11)");
            entity.Property(e => e.StudentId).HasColumnType("int(11)");

            entity.HasOne(d => d.Lessons).WithMany(p => p.LessonsStudents)
                .HasForeignKey(d => d.LessonsId)
                .HasConstraintName("LessonsStudent_FK_1");

            entity.HasOne(d => d.Student).WithMany(p => p.LessonsStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("LessonsStudent_FK");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameRole).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("StatusStudent");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Student");

            entity.HasIndex(e => e.DirectionOfStudentId, "Student_FK");

            entity.HasIndex(e => e.StatusStudentId, "Student_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CodeStudent).HasColumnType("int(11)");
            entity.Property(e => e.DirectionOfStudentId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Patronomic).HasMaxLength(100);
            entity.Property(e => e.StatusStudentId).HasColumnType("int(11)");
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.DirectionOfStudent).WithMany(p => p.Students)
                .HasForeignKey(d => d.DirectionOfStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_FK");

            entity.HasOne(d => d.StatusStudent).WithMany(p => p.Students)
                .HasForeignKey(d => d.StatusStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_FK_1");
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("StudentGroup");

            entity.HasIndex(e => e.StudentId, "StudentGroup_FK");

            entity.HasIndex(e => e.GroupId, "StudentGroup_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.GroupId).HasColumnType("int(11)");
            entity.Property(e => e.StudentId).HasColumnType("int(11)");

            entity.HasOne(d => d.Group).WithMany(p => p.StudentGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("StudentGroup_FK_1");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentGroups)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("StudentGroup_FK");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameSubject).HasMaxLength(100);
        });

        modelBuilder.Entity<SubjectTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("SubjectTeacher");

            entity.HasIndex(e => e.SubjectId, "SubjectTeacher_FK");

            entity.HasIndex(e => e.TeacherId, "SubjectTeacher_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.SubjectId).HasColumnType("int(11)");
            entity.Property(e => e.TeacherId).HasColumnType("int(11)");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("SubjectTeacher_FK");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SubjectTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("SubjectTeacher_FK_1");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Teacher");

            entity.HasIndex(e => e.UserId, "Teacher_FK");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CodeTeacher).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Patronomic).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Teacher_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.HasIndex(e => e.StatusId, "User_FK");

            entity.HasIndex(e => e.RoleId, "User_FK_1");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdentificateCode).HasColumnType("int(11)");
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnType("int(11)");
            entity.Property(e => e.StatusId).HasColumnType("int(11)");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_FK_1");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
