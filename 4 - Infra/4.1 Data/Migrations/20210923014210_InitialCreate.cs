using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dificuldade = table.Column<int>(type: "int", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
