using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addbrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marca",
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
                        name: "fk_marca_id_usuario_alteracao",
                        column: x => x.id_usuario_alteracao,
                        principalTable: "usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_marca_id_usuario_criacao",
                        column: x => x.id_usuario_criacao,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_marca_id_usuario_alteracao",
                table: "marca",
                column: "id_usuario_alteracao");

            migrationBuilder.CreateIndex(
                name: "IX_marca_id_usuario_criacao",
                table: "marca",
                column: "id_usuario_criacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marca");
        }
    }
}
