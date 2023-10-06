using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class scm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "APPROVES",
                newName: "IS_APPROVED");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_APPROVED",
                table: "APPROVES",
                type: "bit",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IS_APPROVED",
                table: "APPROVES",
                newName: "IsApproved");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "APPROVES",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "getdate()")
                .OldAnnotation("Relational:ColumnOrder", 1);
        }
    }
}
