using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class MapEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("6f53fa22-e44e-4827-b573-43eedd6bd1cc"));

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("50bf45df-2cc1-4b91-ac27-06f8dca0a257"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 50, 33, 552, DateTimeKind.Local).AddTicks(9060), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("50bf45df-2cc1-4b91-ac27-06f8dca0a257"));

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("6f53fa22-e44e-4827-b573-43eedd6bd1cc"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 45, 6, 540, DateTimeKind.Local).AddTicks(5238), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }
    }
}
