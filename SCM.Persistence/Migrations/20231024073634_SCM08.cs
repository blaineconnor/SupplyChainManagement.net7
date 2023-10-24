using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SCM08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INVOICES_COMPANY_CompanyId",
                table: "INVOICES");

            migrationBuilder.DropIndex(
                name: "IX_INVOICES_CompanyId",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "INVOICES");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "INVOICES",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_CompanyId",
                table: "INVOICES",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_INVOICES_COMPANY_CompanyId",
                table: "INVOICES",
                column: "CompanyId",
                principalTable: "COMPANY",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
