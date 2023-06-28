using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestWebAPI.Models;

public partial class TestDataBaseContext : DbContext
{
    public TestDataBaseContext()
    {
    }

    public TestDataBaseContext(DbContextOptions<TestDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginHistory> LoginHistories { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=81.177.6.104;user id=prof_user1;password=WsrWsrWsr2021$;database=TestDataBase", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.19-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<LoginHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("LoginHistory");

            entity.HasIndex(e => e.UserId, "LoginHistory_FK");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.TimeAuto).HasColumnType("time");
            entity.Property(e => e.TimeExit).HasColumnType("time");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.LoginHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LoginHistory_FK");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.NameStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("User");

            entity.HasIndex(e => e.StatusId, "User_FK");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.IdentificateCode).HasMaxLength(100);
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.StatusId).HasColumnType("int(11)");
            entity.Property(e => e.UserId).HasColumnType("int(11)");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
