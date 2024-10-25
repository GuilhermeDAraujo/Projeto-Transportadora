﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Transportadora.Context;

#nullable disable

namespace Projeto_Transportadora.Migrations
{
    [DbContext(typeof(TransportadoraContext))]
    [Migration("20241024224120_CriandoTabelaTransportadora")]
    partial class CriandoTabelaTransportadora
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto_Transportadora.Models.AcaoNotaFiscal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("DataDaAcao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriacao")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("NotaFiscalId")
                        .HasColumnType("int");

                    b.Property<int>("TipoAcao")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("AcoesNotaFiscal");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.Caminhao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal?>("CustoCombustivel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CustoManutencao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("id");

                    b.ToTable("Caminhoes");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.Estoque", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("DataDaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaFiscalId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.Fechamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("DataDoFechamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaFiscalId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("NotaFiscalId");

                    b.ToTable("Fechamentos");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.NotaFiscal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CaminhaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDoFaturamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnderecoFaturado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumeroDaCarga")
                        .HasColumnType("int");

                    b.Property<int>("NumeroNotaFiscal")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CaminhaoId");

                    b.ToTable("NotasFiscais");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.AcaoNotaFiscal", b =>
                {
                    b.HasOne("Projeto_Transportadora.Models.NotaFiscal", "NotaFiscal")
                        .WithMany("Acoes")
                        .HasForeignKey("NotaFiscalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotaFiscal");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.Estoque", b =>
                {
                    b.HasOne("Projeto_Transportadora.Models.NotaFiscal", "NotaFiscal")
                        .WithMany()
                        .HasForeignKey("NotaFiscalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotaFiscal");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.Fechamento", b =>
                {
                    b.HasOne("Projeto_Transportadora.Models.NotaFiscal", "NotaFiscal")
                        .WithMany()
                        .HasForeignKey("NotaFiscalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotaFiscal");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.NotaFiscal", b =>
                {
                    b.HasOne("Projeto_Transportadora.Models.Caminhao", "Caminhao")
                        .WithMany("NotasFiscais")
                        .HasForeignKey("CaminhaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caminhao");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.Caminhao", b =>
                {
                    b.Navigation("NotasFiscais");
                });

            modelBuilder.Entity("Projeto_Transportadora.Models.NotaFiscal", b =>
                {
                    b.Navigation("Acoes");
                });
#pragma warning restore 612, 618
        }
    }
}
