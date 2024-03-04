using System;
using System.Collections.Generic;
using GElectra.Entities;
using Microsoft.EntityFrameworkCore;

namespace GElectra.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<PropertyType> PropertyTypes { get; set; }

    public virtual DbSet<Reading> Readings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;user='SA';password='Db@9949436484';TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__tmp_ms_x__6D903F03C40EB4D0");

            entity.ToTable("bills");

            entity.Property(e => e.BillId).HasColumnName("billId");
            entity.Property(e => e.AmountDue).HasColumnName("amountDue");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("date")
                .HasColumnName("dateUpdated");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bills)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bills__customerI__1EF99443");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tmp_ms_x__B611CB9D5B8E798B");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.BedroomCount).HasColumnName("bedroomCount");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("propertyType");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("price");

            entity.Property(e => e.ElectricityPrice).HasColumnName("electricityPrice");
            entity.Property(e => e.GasPrice).HasColumnName("gasPrice");
        });

        modelBuilder.Entity<PropertyType>(entity =>
        {
            entity.HasKey(e => e.PropertyId);

            entity.ToTable("propertyType");

            entity.Property(e => e.PropertyId).HasColumnName("propertyID");
            entity.Property(e => e.PropertyType1)
                .HasMaxLength(50)
                .HasColumnName("propertyType");
        });

        modelBuilder.Entity<Reading>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC072ABD0221");

            entity.ToTable("readings");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.ElectricityReading)
                .HasMaxLength(50)
                .HasColumnName("electricityReading");
            entity.Property(e => e.GasReading)
                .HasMaxLength(50)
                .HasColumnName("gasReading");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("date")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Readings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__readings__custom__22CA2527");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
