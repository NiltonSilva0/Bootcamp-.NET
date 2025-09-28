using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciador_de_Produtos.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeColunaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoryId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoryId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "NomeCategoriaCategoryId",
                table: "Produtos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoria",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NomeCategoriaCategoryId",
                table: "Produtos",
                column: "NomeCategoriaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_NomeCategoriaCategoryId",
                table: "Produtos",
                column: "NomeCategoriaCategoryId",
                principalTable: "Categorias",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_NomeCategoriaCategoryId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_NomeCategoriaCategoryId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "NomeCategoriaCategoryId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "categoria",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoryId",
                table: "Produtos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoryId",
                table: "Produtos",
                column: "CategoryId",
                principalTable: "Categorias",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
