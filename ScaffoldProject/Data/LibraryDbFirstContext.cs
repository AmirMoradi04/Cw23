using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScaffoldProject.DbFirstModels;

namespace ScaffoldProject.Data;

public partial class LibraryDbFirstContext : DbContext
{
    public LibraryDbFirstContext()
    {
    }

    public LibraryDbFirstContext(DbContextOptions<LibraryDbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BorrowRecord> BorrowRecords { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=LibraryDbFirstPractice;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BorrowRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BorrowRe__3214EC07559BF1AB");

            entity.Property(e => e.BookTitle).HasMaxLength(150);
            entity.Property(e => e.BorrowDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.BorrowRecords)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BorrowRecords_Members");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC07805FEDAD");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
