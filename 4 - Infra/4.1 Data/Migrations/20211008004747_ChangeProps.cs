using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoIdiomas.Infra.Data.Migrations
{
    public partial class ChangeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Aluno_AlunoId",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "IdAluno",
                table: "Cobranca");

            migrationBuilder.AlterColumn<long>(
                name: "AlunoId",
                table: "Cobranca",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Nota",
                table: "Boletim",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Aluno_AlunoId",
                table: "Cobranca",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Aluno_AlunoId",
                table: "Cobranca");

            migrationBuilder.AlterColumn<long>(
                name: "AlunoId",
                table: "Cobranca",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "IdAluno",
                table: "Cobranca",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<float>(
                name: "Nota",
                table: "Boletim",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Aluno_AlunoId",
                table: "Cobranca",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
