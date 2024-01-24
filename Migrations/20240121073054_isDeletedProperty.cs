using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinelTest.Migrations
{
    /// <inheritdoc />
    public partial class isDeletedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Visit",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Patient",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Lookup",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Doctor",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Category",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Category");
        }
    }
}
