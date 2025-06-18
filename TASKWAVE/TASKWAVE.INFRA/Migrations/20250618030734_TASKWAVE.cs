using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASKWAVE.INFRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class TASKWAVE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracaoToken",
                table: "TB_USUARIO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenRedefinicaoSenha",
                table: "TB_USUARIO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExpiracaoToken",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "TokenRedefinicaoSenha",
                table: "TB_USUARIO");
        }
    }
}
