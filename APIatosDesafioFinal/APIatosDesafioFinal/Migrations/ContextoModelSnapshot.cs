﻿// <auto-generated />
using System;
using APIatosDesafioFinal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIatosDesafioFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIatosDesafioFinal.DataModels.Comissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRebimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotaFiscal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relatorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<int>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendaId");

                    b.ToTable("Comissao");
                });

            modelBuilder.Entity("APIatosDesafioFinal.DataModels.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Comissao")
                        .HasColumnType("float");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("Operadora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Parcela")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorContrato")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("APIatosDesafioFinal.DataModels.Comissao", b =>
                {
                    b.HasOne("APIatosDesafioFinal.DataModels.Venda", "Venda")
                        .WithMany("comissoes")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("APIatosDesafioFinal.DataModels.Venda", b =>
                {
                    b.Navigation("comissoes");
                });
#pragma warning restore 612, 618
        }
    }
}
