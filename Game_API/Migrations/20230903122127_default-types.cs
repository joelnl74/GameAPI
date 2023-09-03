using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game_API.Migrations
{
    /// <inheritdoc />
    public partial class defaulttypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_contentCharacterTypes",
                table: "contentCharacterTypes");

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "id",
                table: "contentCharacterTypes");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "contentCharacterTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contentCharacterTypes",
                table: "contentCharacterTypes",
                column: "type");

            migrationBuilder.InsertData(
                table: "contentCharacterTypes",
                columns: new[] { "type", "name", "strongAgainst", "weakAgainst" },
                values: new object[,]
                {
                    { 0, "Unknown", "", "" },
                    { 1, "Normale", "", "" },
                    { 2, "Grass", "", "" },
                    { 3, "Fire", "", "" },
                    { 4, "Water", "", "" },
                    { 5, "Electric", "", "" },
                    { 6, "Rock", "", "" },
                    { 7, "Steel", "", "" },
                    { 8, "Ground", "", "" },
                    { 9, "Fairy", "", "" },
                    { 10, "Dark", "", "" },
                    { 11, "Ghost", "", "" },
                    { 12, "Fighting", "", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_contentCharacterTypes",
                table: "contentCharacterTypes");

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "contentCharacterTypes",
                keyColumn: "type",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "name",
                table: "contentCharacterTypes");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "contentCharacterTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contentCharacterTypes",
                table: "contentCharacterTypes",
                column: "id");

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
    }
}
