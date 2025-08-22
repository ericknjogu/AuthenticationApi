using System;
using System.Collections.Generic;
using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Data;

public partial class AtchrmlocalContext : DbContext
{
    public AtchrmlocalContext()
    {
    }

    public AtchrmlocalContext(DbContextOptions<AtchrmlocalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpDetail> EmpDetails { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.Property(e => e.EmpId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("EmpID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InMachine)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("inMachine");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
