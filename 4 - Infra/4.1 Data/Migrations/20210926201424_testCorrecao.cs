using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class testCorrecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "Dificuldade", "Nome" },
                values: new object[,]
                {
                    { new Guid("6734550d-960a-4267-8ab2-bdfeca55af39"), 70, 1, "Inglês" },
                    { new Guid("7e939021-06c7-4372-b933-3bfde5ed889f"), 70, 1, "Espanhol" },
                    { new Guid("7a907cd0-8c35-4a6a-99a4-e536fa49964a"), 80, 1, "Italiano" },
                    { new Guid("716c6195-0c1d-4f35-93cf-6ed8176d2a88"), 90, 1, "Alemão" },
                    { new Guid("89818dd0-a82b-4c4d-ba77-723c1e7441ce"), 110, 2, "Inglês" },
                    { new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), 110, 2, "Espanhol" },
                    { new Guid("b37e29ed-f758-49e3-9fa8-02eb6547e17c"), 150, 2, "Italiano" },
                    { new Guid("fdfc1363-0ac1-4c1e-b1e1-ab81b58e9db0"), 180, 2, "Alemão" },
                    { new Guid("bce8c282-07c8-48b8-881b-c85a539abf7e"), 150, 3, "Inglês" },
                    { new Guid("cba9b402-89d3-45b7-bdfc-c2a8b34ca4c3"), 190, 3, "Espanhol" },
                    { new Guid("dee8ca19-25ed-4e0f-b49e-ec29a8365f55"), 220, 3, "Italiano" },
                    { new Guid("782ffb30-bfff-43c1-b1ab-a4b6c9ebfc16"), 280, 3, "Alemão" }
                });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId", "idCurso", "idProfessor" },
                values: new object[] { new Guid("476162c7-026c-4027-bf14-5048e53e199b"), null, null, new DateTime(2021, 9, 26, 17, 14, 22, 834, DateTimeKind.Local).AddTicks(6142), null, new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("6734550d-960a-4267-8ab2-bdfeca55af39"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("716c6195-0c1d-4f35-93cf-6ed8176d2a88"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("782ffb30-bfff-43c1-b1ab-a4b6c9ebfc16"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("7a907cd0-8c35-4a6a-99a4-e536fa49964a"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("7e939021-06c7-4372-b933-3bfde5ed889f"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("89818dd0-a82b-4c4d-ba77-723c1e7441ce"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("b37e29ed-f758-49e3-9fa8-02eb6547e17c"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("bce8c282-07c8-48b8-881b-c85a539abf7e"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("cba9b402-89d3-45b7-bdfc-c2a8b34ca4c3"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("dee8ca19-25ed-4e0f-b49e-ec29a8365f55"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("fdfc1363-0ac1-4c1e-b1e1-ab81b58e9db0"));

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("476162c7-026c-4027-bf14-5048e53e199b"));
        }
    }
}
