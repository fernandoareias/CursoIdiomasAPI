using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class FinalMapEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("50bf45df-2cc1-4b91-ac27-06f8dca0a257"));

            migrationBuilder.RenameColumn(
                name: "ProfessorSobrenome",
                table: "Professor",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "ProfessorNome",
                table: "Professor",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Aluno",
                type: "nvarchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Aluno",
                type: "nvarchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Emails",
                table: "Aluno",
                type: "nvarchar(120)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("125e50a4-db1f-4c5b-9778-0752cfa96896"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 52, 35, 219, DateTimeKind.Local).AddTicks(7924), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("125e50a4-db1f-4c5b-9778-0752cfa96896"));

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Professor",
                newName: "ProfessorSobrenome");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Professor",
                newName: "ProfessorNome");

            migrationBuilder.AlterColumn<string>(
                name: "Sobrenome",
                table: "Aluno",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Aluno",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Emails",
                table: "Aluno",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("50bf45df-2cc1-4b91-ac27-06f8dca0a257"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 50, 33, 552, DateTimeKind.Local).AddTicks(9060), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }
    }
}
