using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GarageSaleDB.Models;

public partial class GarageSaleDbContext : DbContext
{
    public GarageSaleDbContext()
    {
    }

    public GarageSaleDbContext(DbContextOptions<GarageSaleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GarageSale> GarageSales { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=CHASES-PC;Initial Catalog=GarageSaleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GarageSale>(entity =>
        {
            entity.ToTable("GarageSale");

            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.GarageSales)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GarageSale_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Payment");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.GarageSale).WithMany()
                .HasForeignKey(d => d.GarageSaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_GarageSale");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.DateJoined).HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Salt).HasMaxLength(150);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
