using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SCM09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICES_EMPLOYEES_EmployeeId",
                table: "INVOICES");

            migrationBuilder.DropIndex(
                name: "IX_INVOICES_EmployeeId",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "INVOICES");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmployeeId",
                table: "INVOICES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_EmployeeId",
                table: "INVOICES",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICES_EMPLOYEES_EmployeeId",
                table: "INVOICES",
                column: "EmployeeId",
                principalTable: "EMPLOYEES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
