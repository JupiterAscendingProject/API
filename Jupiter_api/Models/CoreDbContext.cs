using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jupiter_api.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MainTable> MainTables { get; set; } = null!;
        public virtual DbSet<ModuleDetail> ModuleDetails { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<TrackDetail> TrackDetails { get; set; } = null!;
        public virtual DbSet<TrackModule> TrackModules { get; set; } = null!;
        public virtual DbSet<TrainerDetail> TrainerDetails { get; set; } = null!;
        public virtual DbSet<TrainerModule> TrainerModules { get; set; } = null!;
        public virtual DbSet<TrainerSkill> TrainerSkills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= .;Initial Catalog=Jupiter_Test;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainTable>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PK__Main_Tab__E9B4BF3AB4E9219F");
            });

            modelBuilder.Entity<ModuleDetail>(entity =>
            {
                entity.Property(e => e.ModuleNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TrackDetail>(entity =>
            {
                entity.HasKey(e => e.TrackNo)
                    .HasName("PK__Track_De__5DAC0915904A8BEE");

                entity.Property(e => e.TrackNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<TrackModule>(entity =>
            {
                entity.HasOne(d => d.ModuleNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Track_Mod__Modul__2F10007B");

                entity.HasOne(d => d.TrackNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TrackNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Track_Mod__Track__300424B4");
            });

            modelBuilder.Entity<TrainerDetail>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Trainer___2623598B25145680");

                entity.Property(e => e.EmpId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TrainerModule>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainer_M__Emp_I__30F848ED");

                entity.HasOne(d => d.ModuleNoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainer_M__Modul__31EC6D26");
            });

            modelBuilder.Entity<TrainerSkill>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Trainer_S__Emp_I__32E0915F");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("FK__Trainer_S__Skill__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
