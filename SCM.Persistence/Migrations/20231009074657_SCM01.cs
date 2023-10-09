using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SCM01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUESTS_USERS_USER_ID",
                table: "REQUESTS");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "REQUESTS",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_REQUESTS_USER_ID",
                table: "REQUESTS",
                newName: "IX_REQUESTS_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "REQUESTS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<string>(
                name: "USER_NAME",
                table: "REQUESTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddForeignKey(
                name: "FK_REQUESTS_USERS_UserId",
                table: "REQUESTS",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUESTS_USERS_UserId",
                table: "REQUESTS");

            migrationBuilder.DropColumn(
                name: "USER_NAME",
                table: "REQUESTS");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "REQUESTS",
                newName: "USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_REQUESTS_UserId",
                table: "REQUESTS",
                newName: "IX_REQUESTS_USER_ID");

            migrationBuilder.AlterColumn<int>(
                name: "USER_ID",
                table: "REQUESTS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddForeignKey(
                name: "FK_REQUESTS_USERS_USER_ID",
                table: "REQUESTS",
                column: "USER_ID",
                principalTable: "USERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
