using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class Aluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("26cd3036-7fff-4a71-9511-3c2f0d934ef9"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("2ed58113-2479-4a0e-bf20-bcb3bb011a5f"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("36459be2-80a1-46d1-8264-42b57a5ba4ed"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("5166bd58-d962-4930-89e7-f90265c37913"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("7ef79543-f964-4b37-9372-90665341af82"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("9bdb0900-60a8-423e-81e2-aea666eed768"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("9e57a4ef-b196-430c-85d6-6aa92c4e8f47"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("cb2dea3a-6ffc-4ae4-9328-03337c02bf57"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("d2edfcd5-5d6b-43a4-8589-43e2225cce3a"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("e13f1f03-631e-4304-b181-9b0afdfba31d"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("e8127002-3449-4b9d-9ae4-b5118c25ed3b"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("fc259742-4ab0-4d7c-95d7-96b5a773873e"));

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "Dificuldade", "Nome", "TurmaId" },
                values: new object[,]
                {
                    { new Guid("0712bd87-75ae-4f36-a892-2e3e5f5ca41c"), 70, 1, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b01f91fa-fb39-4cfd-9a67-0d3556fd152d"), 70, 1, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("60063860-a3f5-4e8e-b361-58fa9d47ccf7"), 80, 1, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("43b87620-d273-44bc-929e-d3e68274f227"), 90, 1, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("46e774be-a2ef-4bd7-9dc6-d821f9f55594"), 110, 2, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("132f9e0b-fa0c-4dda-941d-51072f94357b"), 110, 2, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("72b9cbcc-5fc3-448e-91be-486376923c3e"), 150, 2, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("973833c0-f949-4202-ae47-9a617c879bb2"), 180, 2, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7b66931b-e87b-4e90-8133-51a8f86871ba"), 150, 3, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("72fabee5-41d8-42ed-b511-18f7e4f22a2e"), 190, 3, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1eebefe6-1c44-4187-b819-153962eabadf"), 220, 3, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("260d315b-1897-461f-b136-532b4698d996"), 280, 3, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("0712bd87-75ae-4f36-a892-2e3e5f5ca41c"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("132f9e0b-fa0c-4dda-941d-51072f94357b"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("1eebefe6-1c44-4187-b819-153962eabadf"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("260d315b-1897-461f-b136-532b4698d996"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("43b87620-d273-44bc-929e-d3e68274f227"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("46e774be-a2ef-4bd7-9dc6-d821f9f55594"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("60063860-a3f5-4e8e-b361-58fa9d47ccf7"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("72b9cbcc-5fc3-448e-91be-486376923c3e"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("72fabee5-41d8-42ed-b511-18f7e4f22a2e"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("7b66931b-e87b-4e90-8133-51a8f86871ba"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("973833c0-f949-4202-ae47-9a617c879bb2"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("b01f91fa-fb39-4cfd-9a67-0d3556fd152d"));

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "Dificuldade", "Nome", "TurmaId" },
                values: new object[,]
                {
                    { new Guid("9bdb0900-60a8-423e-81e2-aea666eed768"), 70, 1, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7ef79543-f964-4b37-9372-90665341af82"), 70, 1, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2ed58113-2479-4a0e-bf20-bcb3bb011a5f"), 80, 1, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("36459be2-80a1-46d1-8264-42b57a5ba4ed"), 90, 1, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cb2dea3a-6ffc-4ae4-9328-03337c02bf57"), 110, 2, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("26cd3036-7fff-4a71-9511-3c2f0d934ef9"), 110, 2, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9e57a4ef-b196-430c-85d6-6aa92c4e8f47"), 150, 2, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e13f1f03-631e-4304-b181-9b0afdfba31d"), 180, 2, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fc259742-4ab0-4d7c-95d7-96b5a773873e"), 150, 3, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5166bd58-d962-4930-89e7-f90265c37913"), 190, 3, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d2edfcd5-5d6b-43a4-8589-43e2225cce3a"), 220, 3, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e8127002-3449-4b9d-9ae4-b5118c25ed3b"), 280, 3, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }
    }
}
