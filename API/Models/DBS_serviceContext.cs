using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_DBS.Models
{
    public partial class DBS_serviceContext : DbContext
    {
        public DBS_serviceContext()
        {
        }

        public DBS_serviceContext(DbContextOptions<DBS_serviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Cregistration> Cregistrations { get; set; } = null!;
        public virtual DbSet<Eregistration> Eregistrations { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Pricechart> Pricecharts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=DBS_service;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Booking__C3905BAF06B46F95");

                entity.ToTable("Booking");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DelivaryDate).HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExecId).HasColumnName("ExecID");

                entity.Property(e => e.PicKupTime).HasColumnType("datetime");

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cregistration>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__CRegistr__049E3A89BF343F95");

                entity.ToTable("CRegistration");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emailID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CS_AS");
            });

            modelBuilder.Entity<Eregistration>(entity =>
            {
                entity.HasKey(e => e.ExecId)
                    .HasName("PK__ERegistr__691611DE46187B4C");

                entity.ToTable("ERegistration");

                entity.Property(e => e.ExecId).HasColumnName("ExecID");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emailID");

                entity.Property(e => e.ExecName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CS_AS");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__History__C3905BAFCFE6E422");

                entity.ToTable("History");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.DelivaryDate).HasColumnType("date");

                entity.Property(e => e.Destination)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExecId).HasColumnName("ExecID");

                entity.Property(e => e.PicKupTime).HasColumnType("datetime");

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pricechart>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK__Pricecha__4957584F446AC938");

                entity.ToTable("Pricechart");

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.DistanceInKm)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WeightInKg)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
