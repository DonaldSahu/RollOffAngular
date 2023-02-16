using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RollOffBackend.Models
{
    public partial class Roll_offContext : DbContext
    {
        public Roll_offContext()
        {
        }

        public Roll_offContext(DbContextOptions<Roll_offContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FormTable> FormTables { get; set; }
        public virtual DbSet<LoginTable> LoginTables { get; set; }
        public virtual DbSet<RollOffTable> RollOffTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN07001518\\SQLEXPRESS;Database=Roll_off;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FormTable>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("FormTable");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Communication).HasMaxLength(255);

                entity.Property(e => e.EmployeeNo).HasColumnName("Employee No");

                entity.Property(e => e.GlobalGroupId).HasColumnName("Global Group Id");

                entity.Property(e => e.LocalGrade)
                    .HasMaxLength(255)
                    .HasColumnName("Local Grade");

                entity.Property(e => e.LongLeave)
                    .HasMaxLength(255)
                    .HasColumnName("Long Leave");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PerformanceIssue)
                    .HasMaxLength(255)
                    .HasColumnName("Performance Issue");

                entity.Property(e => e.Practise).HasMaxLength(255);

                entity.Property(e => e.PrimarySkill)
                    .HasMaxLength(255)
                    .HasColumnName("Primary Skill");

                entity.Property(e => e.ProjectCode).HasColumnName("Project Code");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("Project Name");

                entity.Property(e => e.ReasonForRollOff)
                    .HasMaxLength(255)
                    .HasColumnName("Reason For Roll Off");

                entity.Property(e => e.RelevantExperienceYrs).HasColumnName("Relevant Experience(Yrs)");

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.RequestDate)
                    .HasColumnType("date")
                    .HasColumnName("Request Date");

                entity.Property(e => e.Resigned).HasMaxLength(255);

                entity.Property(e => e.RoleCompetencies)
                    .HasMaxLength(255)
                    .HasColumnName("Role/Competencies");

                entity.Property(e => e.RollOffEndDate)
                    .HasColumnType("date")
                    .HasColumnName("Roll-off End Date");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.TechnicalSkills)
                    .HasMaxLength(255)
                    .HasColumnName("Technical/Skills");

                entity.Property(e => e.ThisReleaseNeedBackfillIsBackfilled)
                    .HasMaxLength(255)
                    .HasColumnName("This release need backfill/is backfilled");

                entity.Property(e => e.UnderProbation)
                    .HasMaxLength(255)
                    .HasColumnName("Under Probation");

                entity.HasOne(d => d.GlobalGroup)
                    .WithMany(p => p.FormTables)
                    .HasForeignKey(d => d.GlobalGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormTable_RollOffTable");
            });

            modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__LoginTab__1797D0248713F3C1");

                entity.ToTable("LoginTable");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Roles)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<RollOffTable>(entity =>
            {
                entity.HasKey(e => e.GlobalGroupId)
                    .HasName("PK__Sheet1$__A8B3AC1A669EB0A2");

                entity.ToTable("RollOffTable");

                entity.Property(e => e.GlobalGroupId).HasColumnName("Global Group ID");

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeNo).HasColumnName("Employee no");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Joining Date");

                entity.Property(e => e.LocalGrade)
                    .HasMaxLength(255)
                    .HasColumnName("Local Grade");

                entity.Property(e => e.MainClient)
                    .HasMaxLength(255)
                    .HasColumnName("Main Client");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.NewGlobalPractice)
                    .HasMaxLength(255)
                    .HasColumnName("New Global Practice");

                entity.Property(e => e.OfficeCity)
                    .HasMaxLength(255)
                    .HasColumnName("Office City");

                entity.Property(e => e.PeopleManagerPerformanceReviewer)
                    .HasMaxLength(255)
                    .HasColumnName("People Manager (Performance Reviewer)");

                entity.Property(e => e.Practice).HasMaxLength(255);

                entity.Property(e => e.ProjectCode).HasColumnName("Project Code");

                entity.Property(e => e.ProjectEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Project End Date");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("Project Name");

                entity.Property(e => e.ProjectStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Project Start Date");

                entity.Property(e => e.PspName)
                    .HasMaxLength(255)
                    .HasColumnName("PSP Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
