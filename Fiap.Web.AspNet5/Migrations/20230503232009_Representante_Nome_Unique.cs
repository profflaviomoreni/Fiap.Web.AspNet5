using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.AspNet5.Migrations
{
    /// <inheritdoc />
    public partial class Representante_Nome_Unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Representante_NomeRepresentante",
                table: "Representante",
                column: "NomeRepresentante",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Representante_NomeRepresentante",
                table: "Representante");
        }
    }
}
