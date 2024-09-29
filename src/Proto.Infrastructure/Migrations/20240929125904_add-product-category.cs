using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addproductcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "id_categoria_produto",
                table: "produto",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categoria_produto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    id_usuario_criacao = table.Column<long>(type: "bigint", nullable: false),
                    id_usuario_alteracao = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_categoria_produto_id_usuario_alteracao",
                        column: x => x.id_usuario_alteracao,
                        principalTable: "usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_categoria_produto_id_usuario_criacao",
                        column: x => x.id_usuario_criacao,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_produto_id_categoria_produto",
                table: "produto",
                column: "id_categoria_produto");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_produto_id_usuario_alteracao",
                table: "categoria_produto",
                column: "id_usuario_alteracao");

            migrationBuilder.CreateIndex(
                name: "IX_categoria_produto_id_usuario_criacao",
                table: "categoria_produto",
                column: "id_usuario_criacao");

            migrationBuilder.AddForeignKey(
                name: "fk_produto_id_categoria_produto",
                table: "produto",
                column: "id_categoria_produto",
                principalTable: "categoria_produto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_produto_id_categoria_produto",
                table: "produto");

            migrationBuilder.DropTable(
                name: "categoria_produto");

            migrationBuilder.DropIndex(
                name: "IX_produto_id_categoria_produto",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "id_categoria_produto",
                table: "produto");
        }
    }
}
