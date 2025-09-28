using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciador_de_Produtos.Migrations
{
    /// <inheritdoc />
    public partial class correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_NomeCategoriaCategoryId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Produtos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "NomeCategoriaCategoryId",
                table: "Produtos",
                newName: "CategoryModelCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_NomeCategoriaCategoryId",
                table: "Produtos",
                newName: "IX_Produtos_CategoryModelCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoryModelCategoryId",
                table: "Produtos",
                column: "CategoryModelCategoryId",
                principalTable: "Categorias",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoryModelCategoryId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Produtos",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "CategoryModelCategoryId",
                table: "Produtos",
                newName: "NomeCategoriaCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_CategoryModelCategoryId",
                table: "Produtos",
                newName: "IX_Produtos_NomeCategoriaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_NomeCategoriaCategoryId",
                table: "Produtos",
                column: "NomeCategoriaCategoryId",
                principalTable: "Categorias",
                principalColumn: "CategoryId");
        }
    }
}
