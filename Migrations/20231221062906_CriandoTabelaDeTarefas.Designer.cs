﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGBIMFurnas.Data;

#nullable disable

namespace SGBIMFurnas.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231221062906_CriandoTabelaDeTarefas")]
    partial class CriandoTabelaDeTarefas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SGBIMFurnas.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Etapa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Etapas");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Fase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EtapaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("EtapaId");

                    b.ToTable("Fases");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.FaseTransicao", b =>
                {
                    b.Property<int>("FaseAnteriorId")
                        .HasColumnType("int");

                    b.Property<int>("FaseSeguinteId")
                        .HasColumnType("int");

                    b.HasKey("FaseAnteriorId", "FaseSeguinteId");

                    b.HasIndex("FaseSeguinteId");

                    b.ToTable("FaseTransicao");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeadlineDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FaseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TarefaAnteriorId")
                        .HasColumnType("int");

                    b.Property<bool>("Valid")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("FaseId");

                    b.HasIndex("TarefaAnteriorId")
                        .IsUnique();

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Fase", b =>
                {
                    b.HasOne("SGBIMFurnas.Models.Etapa", "Etapa")
                        .WithMany("Fases")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etapa");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.FaseTransicao", b =>
                {
                    b.HasOne("SGBIMFurnas.Models.Fase", "FaseAnterior")
                        .WithMany("FasesSeguintes")
                        .HasForeignKey("FaseAnteriorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGBIMFurnas.Models.Fase", "FaseSeguinte")
                        .WithMany("FasesAnteriores")
                        .HasForeignKey("FaseSeguinteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FaseAnterior");

                    b.Navigation("FaseSeguinte");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Tarefa", b =>
                {
                    b.HasOne("SGBIMFurnas.Models.Fase", "Fase")
                        .WithMany("Tarefas")
                        .HasForeignKey("FaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGBIMFurnas.Models.Tarefa", "TarefaAnterior")
                        .WithOne("TarefaSeguinte")
                        .HasForeignKey("SGBIMFurnas.Models.Tarefa", "TarefaAnteriorId");

                    b.Navigation("Fase");

                    b.Navigation("TarefaAnterior");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Etapa", b =>
                {
                    b.Navigation("Fases");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Fase", b =>
                {
                    b.Navigation("FasesAnteriores");

                    b.Navigation("FasesSeguintes");

                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("SGBIMFurnas.Models.Tarefa", b =>
                {
                    b.Navigation("TarefaSeguinte");
                });
#pragma warning restore 612, 618
        }
    }
}
