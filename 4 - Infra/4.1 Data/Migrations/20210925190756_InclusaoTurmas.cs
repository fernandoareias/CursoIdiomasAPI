using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class InclusaoTurmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("2ca6aaad-0dec-4326-b7fa-4dcf985f3fab"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("3a954806-e673-408e-9a6e-b8bb859ea810"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("4e0a9aca-57b6-44eb-9868-15d23a44fbdd"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("7e3140e5-82a1-44ff-9f59-b1402eea0878"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("82e2c700-607b-43ba-bde3-af6d86bd582c"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("9a66c62a-c854-4617-9141-c0fc838da6ae"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("9d9968a2-5055-4210-b531-8ec51321f7cb"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("b03a7f95-1433-4b90-b1e6-7f9d45972ed0"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("bea6a055-e757-41fd-a69e-c7783719cf12"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("cb1c6fe0-5490-4da3-bb9a-a7986ca10e55"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("e79e6343-c99a-46c5-afaa-e8dd180561ef"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("f52f2fea-d24b-4dfb-b278-f2e973bc8b47"));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Curso",
                type: "varchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Curso",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Turma_CursoId",
                table: "Turma",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ProfessorId",
                table: "Turma",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Professor");

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

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Curso");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "Dificuldade", "Nome" },
                values: new object[,]
                {
                    { new Guid("f52f2fea-d24b-4dfb-b278-f2e973bc8b47"), 70, 1, "Inglês" },
                    { new Guid("3a954806-e673-408e-9a6e-b8bb859ea810"), 70, 1, "Espanhol" },
                    { new Guid("bea6a055-e757-41fd-a69e-c7783719cf12"), 80, 1, "Italiano" },
                    { new Guid("cb1c6fe0-5490-4da3-bb9a-a7986ca10e55"), 90, 1, "Alemão" },
                    { new Guid("82e2c700-607b-43ba-bde3-af6d86bd582c"), 110, 2, "Inglês" },
                    { new Guid("9a66c62a-c854-4617-9141-c0fc838da6ae"), 110, 2, "Espanhol" },
                    { new Guid("2ca6aaad-0dec-4326-b7fa-4dcf985f3fab"), 150, 2, "Italiano" },
                    { new Guid("b03a7f95-1433-4b90-b1e6-7f9d45972ed0"), 180, 2, "Alemão" },
                    { new Guid("4e0a9aca-57b6-44eb-9868-15d23a44fbdd"), 150, 3, "Inglês" },
                    { new Guid("9d9968a2-5055-4210-b531-8ec51321f7cb"), 190, 3, "Espanhol" },
                    { new Guid("7e3140e5-82a1-44ff-9f59-b1402eea0878"), 220, 3, "Italiano" },
                    { new Guid("e79e6343-c99a-46c5-afaa-e8dd180561ef"), 280, 3, "Alemão" }
                });
        }
    }
}
