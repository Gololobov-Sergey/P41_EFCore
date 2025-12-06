using Students.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Students
{
    internal class StudentDBContext : DbContext
    {
        public StudentDBContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public StudentDBContext(DbContextOptions<StudentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.Student> Students { get; set; }
        public virtual DbSet<Models.Group> Groups { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=mssql-srv.step.edu;Persist Security Info=False;User ID=sa;Password=QweAsdZxc!23;Initial Catalog=StudentDB;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<Models.Group>();

            //modelBuilder.Entity<Models.Student>().ToTable("Bublik");

            //modelBuilder.Entity<Models.Student>().Property("GetCode").HasField("code");

            //modelBuilder.Entity<Models.Student>().Property(s => s.FirstName).IsRequired();
            //modelBuilder.Entity<Models.Student>().Property(s => s.LastName).IsRequired();

            //modelBuilder.Entity<Student>().HasKey(s => s.IdStudent);
            //modelBuilder.Entity<Student>().HasKey(s => new { s.LastName, s.FirstName});
            //modelBuilder.Entity<Student>().HasAlternateKey(s => new { s.LastName, s.FirstName }).HasName("QK_LNS");
            //modelBuilder.Entity<Student>().Property(s => s.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Models.Student>().Property(s => s.DateOfBirth).HasDefaultValueSql("GETDATE()");
            //modelBuilder.Entity<Models.Student>().Property(s => s.DateOfBirth).HasDefaultValue("2000-01-01");

            //modelBuilder.Entity<Models.Student>().ToTable(t => t.HasCheckConstraint("CK_Student_FirstName", "FirstName <> ''"));
            //modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(100);

            modelBuilder.Entity<Models.Group>().HasData(
                new Models.Group { Id = 1, Name = "Group A" },
                new Models.Group { Id = 2, Name = "Group B" }
            );


            modelBuilder.Entity<Models.Student>().HasData(
                new Models.Student { Id = 1, FirstName = "Ivan", LastName = "Ivanov", DateOfBirth = new DateTime(2000, 1, 1), GroupId = 1 },
                new Models.Student { Id = 2, FirstName = "Petr", LastName = "Petrov", DateOfBirth = new DateTime(2001, 2, 2), GroupId = 2 },
                new Models.Student { Id = 3, FirstName = "Sidor", LastName = "Sidorov", DateOfBirth = new DateTime(2002, 3, 3), GroupId = 1 }
            );
        }

    }
}
