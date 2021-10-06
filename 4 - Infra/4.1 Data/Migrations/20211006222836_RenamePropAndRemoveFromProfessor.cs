using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class RenamePropAndRemoveFromProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Curso_CursoId",
                table: "Professor");

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "Professor");

            migrationBuilder.AlterColumn<long>(
                name: "CursoId",
                table: "Professor",
                type: "bigint",
                nullable: true,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Curso_CursoId",
                table: "Professor",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Curso_CursoId",
                table: "Professor");

            migrationBuilder.AlterColumn<long>(
                name: "CursoId",
                table: "Professor",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "IdCurso",
                table: "Professor",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "DataInicio", "DataTermino", "Dificuldade", "Nome" },
                values: new object[] { 1L, 280, new DateTime(2021, 10, 8, 18, 9, 21, 443, DateTimeKind.Local).AddTicks(3400), null, 1, "Inglês" });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "ProfessorId", "QntAlunos" },
                values: new object[] { 1L, 1L, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Curso_CursoId",
                table: "Professor",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
