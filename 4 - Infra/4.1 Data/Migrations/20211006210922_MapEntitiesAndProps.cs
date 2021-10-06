using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class MapEntitiesAndProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Emails = table.Column<string>(type: "nvarchar(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Dificuldade = table.Column<int>(type: "int", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nota = table.Column<float>(type: "real", nullable: false),
                    IdAluno = table.Column<long>(type: "bigint", nullable: false),
                    AlunoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletim_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cobranca",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAluno = table.Column<long>(type: "bigint", nullable: false),
                    AlunoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobranca_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    Professor_Email_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCurso = table.Column<long>(type: "bigint", nullable: false),
                    CursoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    QntAlunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<long>(type: "bigint", nullable: false),
                    TurmaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "Curso",
            //    columns: new[] { "Id", "CargaHoraria", "DataInicio", "DataTermino", "Dificuldade", "Nome" },
            //    values: new object[] { 1L, 280, new DateTime(2021, 10, 8, 18, 9, 21, 443, DateTimeKind.Local).AddTicks(3400), null, 1, "Inglês" });

            //migrationBuilder.InsertData(
            //    table: "Turma",
            //    columns: new[] { "Id", "ProfessorId", "QntAlunos" },
            //    values: new object[] { 1L, 1L, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Boletim_AlunoId",
                table: "Boletim",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_AlunoId",
                table: "Cobranca",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_TurmaId",
                table: "Matricula",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_CursoId",
                table: "Professor",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ProfessorId",
                table: "Turma",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletim");

            migrationBuilder.DropTable(
                name: "Cobranca");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
