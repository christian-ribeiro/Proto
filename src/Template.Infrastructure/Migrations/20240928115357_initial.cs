using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    rota = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    icone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    posicao = table.Column<int>(type: "int", nullable: false),
                    id_menu_pai = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_menu_id_menu_pai",
                        column: x => x.id_menu_pai,
                        principalTable: "menu",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    idioma = table.Column<int>(type: "int", nullable: false),
                    refresh_token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    chave_login = table.Column<Guid>(type: "char(36)", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario_criacao = table.Column<long>(type: "bigint", nullable: true),
                    id_usuario_alteracao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_usuario_id_usuario_alteracao",
                        column: x => x.id_usuario_alteracao,
                        principalTable: "usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_usuario_id_usuario_criacao",
                        column: x => x.id_usuario_criacao,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "menu_usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_menu = table.Column<long>(type: "bigint", nullable: false),
                    posicao = table.Column<int>(type: "int", nullable: false),
                    favorito = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    visivel = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario_criacao = table.Column<long>(type: "bigint", nullable: false),
                    id_usuario_alteracao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_menu_usuario_id_menu",
                        column: x => x.id_menu,
                        principalTable: "menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_menu_usuario_id_usuario_alteracao",
                        column: x => x.id_usuario_alteracao,
                        principalTable: "usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_menu_usuario_id_usuario_criacao",
                        column: x => x.id_usuario_criacao,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "descricao", "icone", "id_menu_pai", "posicao", "rota" },
                values: new object[] { 1L, "Sistema", "icon-sistema", null, 1, "/Sistema" });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "data_alteracao", "id_usuario_alteracao", "codigo", "data_criacao", "id_usuario_criacao", "email", "idioma", "chave_login", "nome", "senha", "refresh_token" },
                values: new object[] { 1L, null, null, "001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "christian.des.ribeiro@gmail.com", 0, null, "Christian Ribeiro", "$2a$11$252h2vGrxOa1D/ZO.SCreebeBKyQfoa8MAo4V6wx7O21U3nfxbXWO", null });

            migrationBuilder.InsertData(
                table: "menu",
                columns: new[] { "Id", "descricao", "icone", "id_menu_pai", "posicao", "rota" },
                values: new object[] { 2L, "Usuário", "icon-user", 1L, 2, "/Usuario" });

            migrationBuilder.CreateIndex(
                name: "IX_menu_id_menu_pai",
                table: "menu",
                column: "id_menu_pai");

            migrationBuilder.CreateIndex(
                name: "IX_menu_usuario_id_menu",
                table: "menu_usuario",
                column: "id_menu");

            migrationBuilder.CreateIndex(
                name: "IX_menu_usuario_id_usuario_alteracao",
                table: "menu_usuario",
                column: "id_usuario_alteracao");

            migrationBuilder.CreateIndex(
                name: "IX_menu_usuario_id_usuario_criacao",
                table: "menu_usuario",
                column: "id_usuario_criacao");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_usuario_alteracao",
                table: "usuario",
                column: "id_usuario_alteracao");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_usuario_criacao",
                table: "usuario",
                column: "id_usuario_criacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_usuario");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
