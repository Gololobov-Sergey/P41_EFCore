using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_First;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Disease> Diseases { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorsExamination> DoctorsExaminations { get; set; }

    public virtual DbSet<Examination> Examinations { get; set; }

    public virtual DbSet<Inter> Inters { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=mssql-srv.step.edu;Persist Security Info=False;User ID=sa;Password=QweAsdZxc!23;Initial Catalog=HospitalDB;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC075B7DC3FF");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F64C63A96E").IsUnique();

            entity.Property(e => e.Financing).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Disease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diseases__3214EC07F1BD22FB");

            entity.ToTable(tb => tb.HasTrigger("ignore_update"));

            entity.HasIndex(e => e.Name, "UQ__Diseases__737584F609D947CE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Doctors__3214EC07C5B69371");

            entity.ToTable(tb => tb.HasTrigger("when_delete"));

            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        modelBuilder.Entity<DoctorsExamination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorsE__3214EC07EAFD9525");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Disease).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.DiseaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__Disea__52593CB8");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__Docto__534D60F1");

            entity.HasOne(d => d.Examination).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__Exami__5441852A");

            entity.HasOne(d => d.Ward).WithMany(p => p.DoctorsExaminations)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorsEx__WardI__5535A963");
        });

        modelBuilder.Entity<Examination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Examinat__3214EC07D3C9FA57");

            entity.HasIndex(e => e.Name, "UQ__Examinat__737584F679E301EC").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Inter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inters__3214EC07FF31DD87");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Inters)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inters__DoctorId__5812160E");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3214EC07D433AD9A");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Professors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Professor__Docto__5AEE82B9");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wards__3214EC07D65759FC");

            entity.HasIndex(e => e.Name, "UQ__Wards__737584F64E66F185").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20);

            entity.HasOne(d => d.Department).WithMany(p => p.Wards)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wards__Departmen__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
