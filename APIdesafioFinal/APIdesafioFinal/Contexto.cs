using System;
using System.Collections.Generic;
using APIdesafioFinal.DataModels;
using Microsoft.EntityFrameworkCore;

namespace APIdesafioFinal;

public partial class Contexto : DbContext
{
    public Contexto()
    {
    }

    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Comissao> Comissaos { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=DesafioFinal;User ID=DesafioFinal;password=Desafio_Final;language=Portuguese;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comissao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comissao__3213E83FBB50296E");

            entity.ToTable("Comissao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataRebimento)
                .HasColumnType("date")
                .HasColumnName("dataRebimento");
            entity.Property(e => e.FkVenda).HasColumnName("fk_venda");
            entity.Property(e => e.NotaFiscal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("notaFiscal");
            entity.Property(e => e.Relatorio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("relatorio");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.FkVendaNavigation).WithMany(p => p.Comissaos)
                .HasForeignKey(d => d.FkVenda)
                .HasConstraintName("FK__Comissao__fk_ven__267ABA7A");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venda__3213E83F49D309DD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apelido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apelido");
            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.Comissao).HasColumnName("comissao");
            entity.Property(e => e.DataVenda)
                .HasColumnType("date")
                .HasColumnName("dataVenda");
            entity.Property(e => e.Operadora)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("operadora");
            entity.Property(e => e.Parcela).HasColumnName("parcela");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.ValorContrato).HasColumnName("valorContrato");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
