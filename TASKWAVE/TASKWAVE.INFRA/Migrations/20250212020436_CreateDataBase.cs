using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASKWAVE.INFRA.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ACESSO",
                columns: table => new
                {
                    ID_ACESSO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_ACESSO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_ACESSO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_CRIACAO_ACESSO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACESSO", x => x.ID_ACESSO);
                });

            migrationBuilder.CreateTable(
                name: "TB_AMBIENTE",
                columns: table => new
                {
                    ID_AMBIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_AMBIENTE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_AMBIENTE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AMBIENTE", x => x.ID_AMBIENTE);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROJETO",
                columns: table => new
                {
                    ID_PROJETO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_PROJETO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_PROJETO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATA_CRIACAO_PROJETO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJETO", x => x.ID_PROJETO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_USUARIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL_USUARIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SENHA_USUARIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATA_CRIACAO_USUARIO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_SETOR",
                columns: table => new
                {
                    ID_SETOR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_SETOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_SETOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmbienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SETOR", x => x.ID_SETOR);
                    table.ForeignKey(
                        name: "FK_TB_SETOR_TB_AMBIENTE_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "TB_AMBIENTE",
                        principalColumn: "ID_AMBIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TAREFA",
                columns: table => new
                {
                    ID_TAREFA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SITUACAO_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRIORIDADE_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATA_CRIACAO_TAREFA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATA_PREVISTA_TAREFA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATA_FINAL_TAREFA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAREFA", x => x.ID_TAREFA);
                    table.ForeignKey(
                        name: "FK_TB_TAREFA_TB_PROJETO_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "TB_PROJETO",
                        principalColumn: "ID_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ACESSO_USUARIO",
                columns: table => new
                {
                    ACESSO_ID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACESSO_USUARIO", x => new { x.ACESSO_ID, x.USUARIO_ID });
                    table.ForeignKey(
                        name: "FK_ACESSO_ID",
                        column: x => x.ACESSO_ID,
                        principalTable: "TB_ACESSO",
                        principalColumn: "ID_ACESSO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EQUIPE",
                columns: table => new
                {
                    ID_EQUIPE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_EQUIPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO_EQUIPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EQUIPE", x => x.ID_EQUIPE);
                    table.ForeignKey(
                        name: "FK_TB_EQUIPE_TB_SETOR_SetorId",
                        column: x => x.SetorId,
                        principalTable: "TB_SETOR",
                        principalColumn: "ID_SETOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_HISTORICO_TAREFA",
                columns: table => new
                {
                    ID_HISTORICO_TAREFA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_MUDANCA_TAREFA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SITUACAO_ATUAL_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SITUACAO_ANTERIOR_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRIORIDADE_ATUAL_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRIORIDADE_ANTERIOR_TAREFA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarefaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HISTORICO_TAREFA", x => x.ID_HISTORICO_TAREFA);
                    table.ForeignKey(
                        name: "FK_TB_HISTORICO_TAREFA_TB_TAREFA_TarefaID",
                        column: x => x.TarefaID,
                        principalTable: "TB_TAREFA",
                        principalColumn: "ID_TAREFA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_MENSAGEM",
                columns: table => new
                {
                    ID_MENSAGEM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTEUDO_MENSAGEM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATA_ENVIO_MENSAGEM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarefaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MENSAGEM", x => x.ID_MENSAGEM);
                    table.ForeignKey(
                        name: "FK_TB_MENSAGEM_TB_TAREFA_TarefaID",
                        column: x => x.TarefaID,
                        principalTable: "TB_TAREFA",
                        principalColumn: "ID_TAREFA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EQUIPE_PROJETO",
                columns: table => new
                {
                    EQUIPE_ID = table.Column<int>(type: "int", nullable: false),
                    PROJETO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EQUIPE_PROJETO", x => new { x.EQUIPE_ID, x.PROJETO_ID });
                    table.ForeignKey(
                        name: "FK_EQUIPE_ID",
                        column: x => x.EQUIPE_ID,
                        principalTable: "TB_EQUIPE",
                        principalColumn: "ID_EQUIPE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROJETO_ID",
                        column: x => x.PROJETO_ID,
                        principalTable: "TB_PROJETO",
                        principalColumn: "ID_PROJETO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_EQUIPE_USUARIO",
                columns: table => new
                {
                    EQUIPE_ID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EQUIPE_USUARIO", x => new { x.EQUIPE_ID, x.USUARIO_ID });
                    table.ForeignKey(
                        name: "FK_EQUIPE_USUARIO_ID",
                        column: x => x.EQUIPE_ID,
                        principalTable: "TB_EQUIPE",
                        principalColumn: "ID_EQUIPE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_EQUIPE_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ACESSO_USUARIO_USUARIO_ID",
                table: "TB_ACESSO_USUARIO",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EQUIPE_SetorId",
                table: "TB_EQUIPE",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EQUIPE_PROJETO_PROJETO_ID",
                table: "TB_EQUIPE_PROJETO",
                column: "PROJETO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_EQUIPE_USUARIO_USUARIO_ID",
                table: "TB_EQUIPE_USUARIO",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORICO_TAREFA_TarefaID",
                table: "TB_HISTORICO_TAREFA",
                column: "TarefaID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MENSAGEM_TarefaID",
                table: "TB_MENSAGEM",
                column: "TarefaID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SETOR_AmbienteId",
                table: "TB_SETOR",
                column: "AmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TAREFA_ProjetoId",
                table: "TB_TAREFA",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ACESSO_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_EQUIPE_PROJETO");

            migrationBuilder.DropTable(
                name: "TB_EQUIPE_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_HISTORICO_TAREFA");

            migrationBuilder.DropTable(
                name: "TB_MENSAGEM");

            migrationBuilder.DropTable(
                name: "TB_ACESSO");

            migrationBuilder.DropTable(
                name: "TB_EQUIPE");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_TAREFA");

            migrationBuilder.DropTable(
                name: "TB_SETOR");

            migrationBuilder.DropTable(
                name: "TB_PROJETO");

            migrationBuilder.DropTable(
                name: "TB_AMBIENTE");
        }
    }
}
