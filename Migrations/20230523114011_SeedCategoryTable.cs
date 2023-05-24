using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyWeb.Migrations
{
    public partial class SeedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cartegories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[] { 1, "1", "Action" });

            migrationBuilder.InsertData(
                table: "Cartegories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[] { 2, "2", "Scifi" });

            migrationBuilder.InsertData(
                table: "Cartegories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[] { 3, "3", "Thriller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cartegories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cartegories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cartegories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
