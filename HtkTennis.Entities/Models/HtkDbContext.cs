using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HtkTennis.Entities;

namespace HtkTennis.Entities.Models
{
    public partial class HtkDbContext: DbContext
    {
        public HtkDbContext()
        {
        }

        public HtkDbContext(DbContextOptions<HtkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courts> Courts { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Rankings> Rankings { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HtkTennisDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courts>(entity =>
            {
                entity.HasKey(e => e.PkCourtId);

                entity.Property(e => e.PkCourtId).HasColumnName("PK_CourtId");

                entity.Property(e => e.CourtName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.PkMemberId);

                entity.Property(e => e.PkMemberId).HasColumnName("PK_MemberId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Rankings>(entity =>
            {
                entity.HasKey(e => e.PkRankId);

                entity.Property(e => e.PkRankId).HasColumnName("PK_RankId");

                entity.Property(e => e.FkMemberId).HasColumnName("FK_MemberId");

                entity.HasOne(d => d.FkMember)
                    .WithMany(p => p.Rankings)
                    .HasForeignKey(d => d.FkMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rankings_Members");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.PkReservationId);

                entity.Property(e => e.PkReservationId).HasColumnName("PK_ReservationId");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FkCourtId).HasColumnName("FK_CourtId");

                entity.Property(e => e.FkFirstMemberId).HasColumnName("FK_FirstMemberId");

                entity.Property(e => e.FkSecondMemberId).HasColumnName("FK_SecondMemberId");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.FkCourt)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkCourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Courts");

                entity.HasOne(d => d.FkFirstMember)
                    .WithMany(p => p.ReservationsFkFirstMember)
                    .HasForeignKey(d => d.FkFirstMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Members");

                entity.HasOne(d => d.FkSecondMember)
                    .WithMany(p => p.ReservationsFkSecondMember)
                    .HasForeignKey(d => d.FkSecondMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Members1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
