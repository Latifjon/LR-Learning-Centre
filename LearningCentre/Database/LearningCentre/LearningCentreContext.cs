using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningCentre.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LearningCentreContext : DbContext
    {
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<PlacementTest> PlacementTest { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LearningCentreContext(DbContextOptions<LearningCentreContext> options): base(options)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=USER\SqlExpress;Database=LearningCentre;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlacementTest>(entity =>
            {
                entity.Property(e => e.PlacementTestDate).HasColumnType("datetime");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.PlacementTest)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK_PlacementTest_Level");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Citizenship).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfRegistration).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasColumnType("nchar(10)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NativeLanguage).HasMaxLength(50);

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK_Student_Country");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Teacher_Subject");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Role).HasMaxLength(50);
            });
        }
    }
}
