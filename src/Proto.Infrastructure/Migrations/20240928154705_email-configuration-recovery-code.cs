using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class emailconfigurationrecoverycode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codigo_recuperacao_senha",
                table: "usuario",
                type: "varchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "configuracao_email",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    servidor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    porta = table.Column<int>(type: "int", nullable: false),
                    nome_exibicao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    remetente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    usuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ssl = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    copia_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    tipo_configuracao_email = table.Column<int>(type: "int", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario_criacao = table.Column<long>(type: "bigint", nullable: false),
                    id_usuario_alteracao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_configuracao_email_id_usuario_alteracao",
                        column: x => x.id_usuario_alteracao,
                        principalTable: "usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_configuracao_email_id_usuario_criacao",
                        column: x => x.id_usuario_criacao,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "usuario",
                keyColumn: "Id",
                keyValue: 1L,
                column: "codigo_recuperacao_senha",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_configuracao_email_id_usuario_alteracao",
                table: "configuracao_email",
                column: "id_usuario_alteracao");

            migrationBuilder.CreateIndex(
                name: "IX_configuracao_email_id_usuario_criacao",
                table: "configuracao_email",
                column: "id_usuario_criacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracao_email");

            migrationBuilder.DropColumn(
                name: "codigo_recuperacao_senha",
                table: "usuario");
        }
    }
}
