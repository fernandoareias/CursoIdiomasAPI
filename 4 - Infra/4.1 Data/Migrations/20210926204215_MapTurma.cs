using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class MapTurma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Curso_CursoId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma");

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("45a2b6a3-7298-4929-a726-619421d639d6"));

            migrationBuilder.DropColumn(
                name: "idCurso",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "idProfessor",
                table: "Turma");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CursoId",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId" },
                values: new object[] { new Guid("799e87fe-2ce5-40bf-bd4f-193e9e9e6a6d"), new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), null, new DateTime(2021, 9, 26, 17, 42, 14, 75, DateTimeKind.Local).AddTicks(9837), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Curso_CursoId",
                table: "Turma",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Curso_CursoId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma");

            migrationBuilder.DeleteData(
                table: "Turma",
                keyColumn: "Id",
                keyValue: new Guid("799e87fe-2ce5-40bf-bd4f-193e9e9e6a6d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CursoId",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "idCurso",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "idProfessor",
                table: "Turma",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "CursoId", "DataFim", "DataInicio", "ProfessorId", "idCurso", "idProfessor" },
                values: new object[] { new Guid("45a2b6a3-7298-4929-a726-619421d639d6"), null, null, new DateTime(2021, 9, 26, 17, 36, 22, 742, DateTimeKind.Local).AddTicks(6466), null, new Guid("e0c62bad-3744-4e93-8b77-00588ecd4c5e"), new Guid("80d71825-3434-4503-902e-28fb2c5323f8") });

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Curso_CursoId",
                table: "Turma",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Professor_ProfessorId",
                table: "Turma",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
