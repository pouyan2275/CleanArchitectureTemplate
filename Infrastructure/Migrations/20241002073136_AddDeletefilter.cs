using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletefilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_IsDeleted",
                table: "Degrees");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons",
                column: "IsDeleted",
                descending: new bool[0],
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_IsDeleted",
                table: "Degrees",
                column: "IsDeleted",
                descending: new bool[0],
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_IsDeleted",
                table: "Degrees");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IsDeleted",
                table: "Persons",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_IsDeleted",
                table: "Degrees",
                column: "IsDeleted");
        }
    }
}
