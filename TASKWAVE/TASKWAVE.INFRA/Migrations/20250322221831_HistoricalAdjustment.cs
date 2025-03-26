using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASKWAVE.INFRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class HistoricalAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SITUACAO_ATUAL_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SITUACAO_ANTERIOR_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PRIORIDADE_ATUAL_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PRIORIDADE_ANTERIOR_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SITUACAO_ATUAL_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SITUACAO_ANTERIOR_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PRIORIDADE_ATUAL_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PRIORIDADE_ANTERIOR_TAREFA",
                table: "TB_HISTORICO_TAREFA",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
