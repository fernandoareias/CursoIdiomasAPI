using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class MapAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("799e87fe-2ce5-40bf-bd4f-193e9e9e6a6d"));

            migrationBuilder.DropColumn(
                name: "IdMatricula",
                table: "Aluno");

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("6f53fa22-e44e-4827-b573-43eedd6bd1cc"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 45, 6, 540, DateTimeKind.Local).AddTicks(5238), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("6f53fa22-e44e-4827-b573-43eedd6bd1cc"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdMatricula",
                table: "Aluno",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("799e87fe-2ce5-40bf-bd4f-193e9e9e6a6d"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 42, 14, 75, DateTimeKind.Local).AddTicks(9837), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }
    }
}
