using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game_API.Migrations
{
    /// <inheritdoc />
    public partial class types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contentCharacterTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    strongAgainst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weakAgainst = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contentCharacterTypes", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "contentCharacterTypes",
                columns: new[] { "id", "strongAgainst", "type", "weakAgainst" },
                values: new object[,]
                {
                    { 1, "", 0, "" },
                    { 2, "4", 0, "3" },
                    { 3, "3", 0, "2" },
                    { 4, "2", 0, "4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contentCharacterTypes");
        }
    }
}
