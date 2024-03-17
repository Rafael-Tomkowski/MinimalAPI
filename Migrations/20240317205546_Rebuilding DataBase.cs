using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class RebuildingDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "products",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");
        }
    }
}
