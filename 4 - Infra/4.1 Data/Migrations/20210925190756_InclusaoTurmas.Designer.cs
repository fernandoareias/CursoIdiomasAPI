﻿// <auto-generated />
using System;
using CursoIdiomas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursoIdiomas.Infra.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210925190756_InclusaoTurmas")]
    partial class InclusaoTurmas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<int>("Dificuldade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Curso");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9bdb0900-60a8-423e-81e2-aea666eed768"),
                            CargaHoraria = 70,
                            Dificuldade = 1,
                            Nome = "Inglês",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("7ef79543-f964-4b37-9372-90665341af82"),
                            CargaHoraria = 70,
                            Dificuldade = 1,
                            Nome = "Espanhol",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("2ed58113-2479-4a0e-bf20-bcb3bb011a5f"),
                            CargaHoraria = 80,
                            Dificuldade = 1,
                            Nome = "Italiano",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("36459be2-80a1-46d1-8264-42b57a5ba4ed"),
                            CargaHoraria = 90,
                            Dificuldade = 1,
                            Nome = "Alemão",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("cb2dea3a-6ffc-4ae4-9328-03337c02bf57"),
                            CargaHoraria = 110,
                            Dificuldade = 2,
                            Nome = "Inglês",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("26cd3036-7fff-4a71-9511-3c2f0d934ef9"),
                            CargaHoraria = 110,
                            Dificuldade = 2,
                            Nome = "Espanhol",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("9e57a4ef-b196-430c-85d6-6aa92c4e8f47"),
                            CargaHoraria = 150,
                            Dificuldade = 2,
                            Nome = "Italiano",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("e13f1f03-631e-4304-b181-9b0afdfba31d"),
                            CargaHoraria = 180,
                            Dificuldade = 2,
                            Nome = "Alemão",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("fc259742-4ab0-4d7c-95d7-96b5a773873e"),
                            CargaHoraria = 150,
                            Dificuldade = 3,
                            Nome = "Inglês",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("5166bd58-d962-4930-89e7-f90265c37913"),
                            CargaHoraria = 190,
                            Dificuldade = 3,
                            Nome = "Espanhol",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("d2edfcd5-5d6b-43a4-8589-43e2225cce3a"),
                            CargaHoraria = 220,
                            Dificuldade = 3,
                            Nome = "Italiano",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("e8127002-3449-4b9d-9ae4-b5118c25ed3b"),
                            CargaHoraria = 280,
                            Dificuldade = 3,
                            Nome = "Alemão",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Flunt.Notifications.Notification", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Professor", b =>
                {
                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ProfessorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProfessorId");

                            b1.ToTable("Professor");

                            b1.WithOwner()
                                .HasForeignKey("ProfessorId");
                        });

                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("ProfessorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProfessorId");

                            b1.ToTable("Professor");

                            b1.WithOwner()
                                .HasForeignKey("ProfessorId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Turma", b =>
                {
                    b.HasOne("CursoIdiomas.Domain.Entities.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoIdiomas.Domain.Entities.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Professor", b =>
                {
                    b.Navigation("Turmas");
                });
#pragma warning restore 612, 618
        }
    }
}