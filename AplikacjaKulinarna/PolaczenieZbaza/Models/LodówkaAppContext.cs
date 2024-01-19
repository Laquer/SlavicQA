using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PolaczenieZbaza.Models;

public partial class LodówkaAppContext : DbContext
{
    public LodówkaAppContext()
    {
    }

    public LodówkaAppContext(DbContextOptions<LodówkaAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lodowki> Lodowkis { get; set; }

    public virtual DbSet<StringDTO> StringDTOs { get; set; }

    public virtual DbSet<LodówkaDTO> LodówkaDTOs { get; set; }

    public virtual DbSet<Przepi> Przepis { get; set; }

    public virtual DbSet<Skladnik> Skladniks { get; set; }

    public virtual DbSet<ZestawSkladnikow> ZestawSkladnikows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MNHGNQU;Initial Catalog=BAZA_V2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lodowki>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Lodowki");

            entity.Property(e => e.IdLodowka).HasColumnName("id_lodowka");
            entity.Property(e => e.IdSkladnika).HasColumnName("id_skladnika");
            entity.Property(e => e.IloscSkladnika)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("ilosc_skladnika");

            entity.HasOne(d => d.IdSkladnikaNavigation).WithMany()
                .HasForeignKey(d => d.IdSkladnika)
                .HasConstraintName("FK_Lodowki_Skladnik");
        });

        modelBuilder.Entity<Przepi>(entity =>
        {
            entity.HasKey(e => e.IdPrzepisu);

            entity.Property(e => e.IdPrzepisu)
                .ValueGeneratedNever()
                .HasColumnName("id_przepisu");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("nazwa");
            entity.Property(e => e.OpisPrzygotowania)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("opis_przygotowania");
            entity.Property(e => e.WartosciOdzywcze)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("wartosci_odzywcze");
        });

        modelBuilder.Entity<Skladnik>(entity =>
        {
            entity.HasKey(e => e.IdSkladnika);

            entity.ToTable("Skladnik");

            entity.Property(e => e.IdSkladnika)
                .ValueGeneratedNever()
                .HasColumnName("id_skladnika");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("nazwa");
            entity.Property(e => e.Przelicznik)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("przelicznik");
        });

        modelBuilder.Entity<ZestawSkladnikow>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Zestaw_skladnikow");

            entity.Property(e => e.IdPrzepisu).HasColumnName("id_przepisu");
            entity.Property(e => e.IdSkladnika).HasColumnName("id_skladnika");
            entity.Property(e => e.IloscSkladnika)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("ilosc_skladnika");

            entity.HasOne(d => d.IdPrzepisuNavigation).WithMany()
                .HasForeignKey(d => d.IdPrzepisu)
                .HasConstraintName("FK_Zestaw_skladnikow_Przepis");

            entity.HasOne(d => d.IdSkladnikaNavigation).WithMany()
                .HasForeignKey(d => d.IdSkladnika)
                .HasConstraintName("FK_Zestaw_skladnikow_Skladnik");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
