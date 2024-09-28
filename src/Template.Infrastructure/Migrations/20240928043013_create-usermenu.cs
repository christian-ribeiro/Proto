using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createusermenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CreationUserId = table.Column<long>(type: "bigint", nullable: true),
                    ChangeUserId = table.Column<long>(type: "bigint", nullable: true)
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
                        column: x => x.ChangeUserId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_menu_usuario_id_usuario_criacao",
                        column: x => x.CreationUserId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_menu_usuario_ChangeUserId",
                table: "menu_usuario",
                column: "ChangeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_usuario_CreationUserId",
                table: "menu_usuario",
                column: "CreationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_usuario_id_menu",
                table: "menu_usuario",
                column: "id_menu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_usuario");
        }
    }
}
