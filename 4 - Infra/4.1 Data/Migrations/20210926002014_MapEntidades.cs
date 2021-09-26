using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class AlunoMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "IdMatricula",
                table: "Aluno",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Boletim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nota = table.Column<float>(type: "real", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletim_Matricula_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensalidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensalidade_Matricula_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "CargaHoraria", "Dificuldade", "Nome", "TurmaId" },
                values: new object[,]
                {
                    { new Guid("46ed0afc-2fdf-4def-b216-9663cf640332"), 70, 1, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9dbb1b0b-633f-4e53-8d44-46b5e6fc9fdd"), 70, 1, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("410f8a3c-5551-4a8f-b361-5f3d619b0ee0"), 80, 1, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9e018cac-255c-4466-aa3b-2eb6fb05e7d7"), 90, 1, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("47f77ff9-55ff-4b0b-9fb4-fe3a6dd02bd9"), 110, 2, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c781633c-6ca0-485b-872f-741395d54cc5"), 110, 2, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c2075070-c498-4408-bbcb-a8832b885c40"), 150, 2, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6df59ecd-f1ec-4de7-b95c-a414857827e4"), 180, 2, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4a3eef64-404d-4f6d-9263-12ea10a69e43"), 150, 3, "Inglês", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e4870a69-74d7-4f3b-8489-707909ff97ca"), 190, 3, "Espanhol", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("63afb29a-4034-4533-8f84-108f7d065378"), 220, 3, "Italiano", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("aa47f99e-0932-4fe3-b396-cb2de3accad7"), 280, 3, "Alemão", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletim_MatriculaId",
                table: "Boletim",
                column: "MatriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_TurmaId",
                table: "Matricula",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidade_MatriculaId",
                table: "Mensalidade",
                column: "MatriculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletim");

            migrationBuilder.DropTable(
                name: "Mensalidade");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("410f8a3c-5551-4a8f-b361-5f3d619b0ee0"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("46ed0afc-2fdf-4def-b216-9663cf640332"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("47f77ff9-55ff-4b0b-9fb4-fe3a6dd02bd9"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("4a3eef64-404d-4f6d-9263-12ea10a69e43"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("63afb29a-4034-4533-8f84-108f7d065378"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("6df59ecd-f1ec-4de7-b95c-a414857827e4"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("9dbb1b0b-633f-4e53-8d44-46b5e6fc9fdd"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("9e018cac-255c-4466-aa3b-2eb6fb05e7d7"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("aa47f99e-0932-4fe3-b396-cb2de3accad7"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("c2075070-c498-4408-bbcb-a8832b885c40"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("c781633c-6ca0-485b-872f-741395d54cc5"));

            migrationBuilder.DeleteData(
                table: "Curso",
                keyColumn: "Id",
                keyValue: new Guid("e4870a69-74d7-4f3b-8489-707909ff97ca"));

            migrationBuilder.DropColumn(
                name: "IdMatricula",
                table: "Aluno");

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
    }
}
