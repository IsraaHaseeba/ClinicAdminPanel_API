using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinelTest.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Visit",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Patient",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Lookup",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Doctor",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Category",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Visit",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Patient",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Lookup",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Doctor",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Category",
                newName: "isDeleted");
        }
    }
}
