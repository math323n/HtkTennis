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

        public virtual DbSet<Court> Courts { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

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
            modelBuilder.Entity<Court>(entity =>
            {
                entity.HasKey(e => e.PkCourtId);

                entity.Property(e => e.PkCourtId).HasColumnName("PK_CourtId");

                entity.Property(e => e.CourtName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.PkMemberId);

                entity.Property(e => e.PkMemberId).HasColumnName("PK_MemberId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
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

            modelBuilder.Entity<Ranking>(entity =>
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

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.PkReservationId);

                entity.Property(e => e.PkReservationId).HasColumnName("PK_ReservationId");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FkCourtId).HasColumnName("FK_CourtId");

                entity.Property(e => e.FkFirstMember).HasColumnName("FK_FirstMemberId");

                entity.Property(e => e.FkSecondMember).HasColumnName("FK_SecondMemberId");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.FkCourt)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.FkCourtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Courts");

                entity.HasOne(d => d.FkFirstMemberNavigation)
                    .WithMany(p => p.ReservationFkFirstMember)
                    .HasForeignKey(d => d.FkFirstMember)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_FirstMember");

                entity.HasOne(d => d.FkSecondMemberNavigation)
                    .WithMany(p => p.ReservationFkSecondMember)
                    .HasForeignKey(d => d.FkSecondMember)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_SecondMember");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
