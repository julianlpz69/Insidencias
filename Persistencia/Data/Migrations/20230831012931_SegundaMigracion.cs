using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salon_matricula_MatriculaId",
                table: "salon");

            migrationBuilder.DropIndex(
                name: "IX_salon_MatriculaId",
                table: "salon");

            migrationBuilder.DropColumn(
                name: "MatriculaId",
                table: "salon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatriculaId",
                table: "salon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_salon_MatriculaId",
                table: "salon",
                column: "MatriculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_salon_matricula_MatriculaId",
                table: "salon",
                column: "MatriculaId",
                principalTable: "matricula",
                principalColumn: "Id");
        }
    }
}
