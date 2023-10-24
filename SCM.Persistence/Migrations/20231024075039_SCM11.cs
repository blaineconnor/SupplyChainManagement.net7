using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SCM11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "DEPARTMENT",
                newName: "PHONE");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "DEPARTMENT",
                newName: "ADDRESS");

            migrationBuilder.AlterColumn<string>(
                name: "PHONE",
                table: "DEPARTMENT",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                table: "DEPARTMENT",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PHONE",
                table: "DEPARTMENT",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "ADDRESS",
                table: "DEPARTMENT",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "DEPARTMENT",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "DEPARTMENT",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);
        }
    }
}
