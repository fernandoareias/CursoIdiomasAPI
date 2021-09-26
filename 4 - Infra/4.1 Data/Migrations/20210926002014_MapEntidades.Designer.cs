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
    [Migration("20210926002014_AlunoMatricula")]
    partial class AlunoMatricula
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMatricula")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Boletim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MatriculaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Nota")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MatriculaId");

                    b.ToTable("Boletim");
                });

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
                            Id = new Guid("46ed0afc-2fdf-4def-b216-9663cf640332"),
                            CargaHoraria = 70,
                            Dificuldade = 1,
                            Nome = "Inglês",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("9dbb1b0b-633f-4e53-8d44-46b5e6fc9fdd"),
                            CargaHoraria = 70,
                            Dificuldade = 1,
                            Nome = "Espanhol",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("410f8a3c-5551-4a8f-b361-5f3d619b0ee0"),
                            CargaHoraria = 80,
                            Dificuldade = 1,
                            Nome = "Italiano",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("9e018cac-255c-4466-aa3b-2eb6fb05e7d7"),
                            CargaHoraria = 90,
                            Dificuldade = 1,
                            Nome = "Alemão",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("47f77ff9-55ff-4b0b-9fb4-fe3a6dd02bd9"),
                            CargaHoraria = 110,
                            Dificuldade = 2,
                            Nome = "Inglês",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("c781633c-6ca0-485b-872f-741395d54cc5"),
                            CargaHoraria = 110,
                            Dificuldade = 2,
                            Nome = "Espanhol",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("c2075070-c498-4408-bbcb-a8832b885c40"),
                            CargaHoraria = 150,
                            Dificuldade = 2,
                            Nome = "Italiano",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("6df59ecd-f1ec-4de7-b95c-a414857827e4"),
                            CargaHoraria = 180,
                            Dificuldade = 2,
                            Nome = "Alemão",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("4a3eef64-404d-4f6d-9263-12ea10a69e43"),
                            CargaHoraria = 150,
                            Dificuldade = 3,
                            Nome = "Inglês",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("e4870a69-74d7-4f3b-8489-707909ff97ca"),
                            CargaHoraria = 190,
                            Dificuldade = 3,
                            Nome = "Espanhol",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("63afb29a-4034-4533-8f84-108f7d065378"),
                            CargaHoraria = 220,
                            Dificuldade = 3,
                            Nome = "Italiano",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("aa47f99e-0932-4fe3-b396-cb2de3accad7"),
                            CargaHoraria = 280,
                            Dificuldade = 3,
                            Nome = "Alemão",
                            TurmaId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Matricula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique();

                    b.HasIndex("TurmaId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Mensalidades", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MatriculaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MatriculaId");

                    b.ToTable("Mensalidade");
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

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Aluno", b =>
                {
                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Aluno");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("AlunoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AlunoId");

                            b1.ToTable("Aluno");

                            b1.WithOwner()
                                .HasForeignKey("AlunoId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Nome");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Boletim", b =>
                {
                    b.HasOne("CursoIdiomas.Domain.Entities.Matricula", "Matricula")
                        .WithMany("Boletins")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Matricula", b =>
                {
                    b.HasOne("CursoIdiomas.Domain.Entities.Aluno", "Aluno")
                        .WithOne("Matricula")
                        .HasForeignKey("CursoIdiomas.Domain.Entities.Matricula", "AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoIdiomas.Domain.Entities.Turma", "Turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Mensalidades", b =>
                {
                    b.HasOne("CursoIdiomas.Domain.Entities.Matricula", "Matricula")
                        .WithMany("Mensalidades")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matricula");
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

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Matricula", b =>
                {
                    b.Navigation("Boletins");

                    b.Navigation("Mensalidades");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Professor", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Turma", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
