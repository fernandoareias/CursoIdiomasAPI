using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class CorrecaoVARCHAR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("476162c7-026c-4027-bf14-5048e53e199b"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorSobrenome",
                table: "Professor",
                type: "nvarchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorNome",
                table: "Professor",
                type: "nvarchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId", "idCurso", "idProfessor" },
                values: new object[] { new Guid("45a2b6a3-7298-4929-a726-619421d639d6"), null, null, new DateTime(2021, 9, 26, 17, 36, 22, 742, DateTimeKind.Local).AddTicks(6466), null, new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("45a2b6a3-7298-4929-a726-619421d639d6"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorSobrenome",
                table: "Professor",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfessorNome",
                table: "Professor",
                type: "nvarchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId", "idCurso", "idProfessor" },
                values: new object[] { new Guid("476162c7-026c-4027-bf14-5048e53e199b"), null, null, new DateTime(2021, 9, 26, 17, 14, 22, 834, DateTimeKind.Local).AddTicks(6142), null, new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }
    }
}
