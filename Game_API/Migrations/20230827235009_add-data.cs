using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game_API.Migrations
{
    /// <inheritdoc />
    public partial class adddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "contentCharacters",
                columns: new[] { "id", "name", "typeId" },
                values: new object[,]
                {
                    { 1, "basic", 1 },
                    { 2, "grass", 2 },
                    { 3, "water", 3 },
                    { 4, "fire", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "contentCharacters",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contentCharacters",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contentCharacters",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "contentCharacters",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
