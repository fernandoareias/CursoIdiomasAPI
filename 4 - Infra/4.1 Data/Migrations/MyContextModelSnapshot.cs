﻿// <auto-generated />
using System;
using CursoIdiomas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursoIdiomas.Infra.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CursoIdiomas.Domain.Cursos.Curso.Curso", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Curso");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6734550d-960a-4267-8ab2-bdfeca55af39"),
                            CargaHoraria = 70,
                            Dificuldade = 1,
                            Nome = "Inglês"
                        },
                        new
                        {
                            Id = new Guid("7e939021-06c7-4372-b933-3bfde5ed889f"),
                            CargaHoraria = 70,
                            Dificuldade = 1,
                            Nome = "Espanhol"
                        },
                        new
                        {
                            Id = new Guid("7a907cd0-8c35-4a6a-99a4-e536fa49964a"),
                            CargaHoraria = 80,
                            Dificuldade = 1,
                            Nome = "Italiano"
                        },
                        new
                        {
                            Id = new Guid("716c6195-0c1d-4f35-93cf-6ed8176d2a88"),
                            CargaHoraria = 90,
                            Dificuldade = 1,
                            Nome = "Alemão"
                        },
                        new
                        {
                            Id = new Guid("89818dd0-a82b-4c4d-ba77-723c1e7441ce"),
                            CargaHoraria = 110,
                            Dificuldade = 2,
                            Nome = "Inglês"
                        },
                        new
                        {
                            Id = new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"),
                            CargaHoraria = 110,
                            Dificuldade = 2,
                            Nome = "Espanhol"
                        },
                        new
                        {
                            Id = new Guid("b37e29ed-f758-49e3-9fa8-02eb6547e17c"),
                            CargaHoraria = 150,
                            Dificuldade = 2,
                            Nome = "Italiano"
                        },
                        new
                        {
                            Id = new Guid("fdfc1363-0ac1-4c1e-b1e1-ab81b58e9db0"),
                            CargaHoraria = 180,
                            Dificuldade = 2,
                            Nome = "Alemão"
                        },
                        new
                        {
                            Id = new Guid("bce8c282-07c8-48b8-881b-c85a539abf7e"),
                            CargaHoraria = 150,
                            Dificuldade = 3,
                            Nome = "Inglês"
                        },
                        new
                        {
                            Id = new Guid("cba9b402-89d3-45b7-bdfc-c2a8b34ca4c3"),
                            CargaHoraria = 190,
                            Dificuldade = 3,
                            Nome = "Espanhol"
                        },
                        new
                        {
                            Id = new Guid("dee8ca19-25ed-4e0f-b49e-ec29a8365f55"),
                            CargaHoraria = 220,
                            Dificuldade = 3,
                            Nome = "Italiano"
                        },
                        new
                        {
                            Id = new Guid("782ffb30-bfff-43c1-b1ab-a4b6c9ebfc16"),
                            CargaHoraria = 280,
                            Dificuldade = 3,
                            Nome = "Alemão"
                        });
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Alunos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Mensalidade", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("125e50a4-db1f-4c5b-9778-0752cfa96896"),
                            CursoId = new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"),
                            DataInicio = new DateTime(2021, 9, 26, 17, 52, 35, 219, DateTimeKind.Local).AddTicks(7924),
                            ProfessorId = new Guid("80d71825-3434-4503-902e-28fb2c5323f8")
                        });
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Professor.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Alunos", b =>
                {
                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("AlunosId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(120)")
                                .HasColumnName("Emails");

                            b1.HasKey("AlunosId");

                            b1.ToTable("Aluno");

                            b1.WithOwner()
                                .HasForeignKey("AlunosId");
                        });

                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("AlunosId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(80)")
                                .HasColumnName("Nome");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(80)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("AlunosId");

                            b1.ToTable("Aluno");

                            b1.WithOwner()
                                .HasForeignKey("AlunosId");
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
                    b.HasOne("CursoIdiomas.Domain.Entities.Alunos", "Aluno")
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

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Mensalidade", b =>
                {
                    b.HasOne("CursoIdiomas.Domain.Entities.Matricula", "Matricula")
                        .WithMany("Mensalidades")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Turma", b =>
                {
                    b.HasOne("CursoIdiomas.Domain.Cursos.Curso.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoIdiomas.Domain.Professor.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Professor.Professor", b =>
                {
                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Email", "Professor_Email", b1 =>
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

                    b.OwnsOne("CursoIdiomas.Domain.ValueObjects.Nome", "Professor_Nome", b1 =>
                        {
                            b1.Property<Guid>("ProfessorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(80)")
                                .HasColumnName("Nome");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(80)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("ProfessorId");

                            b1.ToTable("Professor");

                            b1.WithOwner()
                                .HasForeignKey("ProfessorId");
                        });

                    b.Navigation("Professor_Email");

                    b.Navigation("Professor_Nome");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Cursos.Curso.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Alunos", b =>
                {
                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Matricula", b =>
                {
                    b.Navigation("Boletins");

                    b.Navigation("Mensalidades");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Entities.Turma", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("CursoIdiomas.Domain.Professor.Professor", b =>
                {
                    b.Navigation("Turmas");
                });
#pragma warning restore 612, 618
        }
    }
}
