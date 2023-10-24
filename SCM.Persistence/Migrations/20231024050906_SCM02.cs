using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SCM02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFFERS_Suppliers_SUPPLIER_ID",
                table: "OFFERS");

            migrationBuilder.AlterColumn<string>(
                name: "SUPPLIER_NAME",
                table: "OFFERS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<long>(
                name: "SUPPLIER_ID",
                table: "OFFERS",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_OFFERS_Suppliers_SUPPLIER_ID",
                table: "OFFERS",
                column: "SUPPLIER_ID",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFFERS_Suppliers_SUPPLIER_ID",
                table: "OFFERS");

            migrationBuilder.AlterColumn<string>(
                name: "SUPPLIER_NAME",
                table: "OFFERS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SUPPLIER_ID",
                table: "OFFERS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OFFERS_Suppliers_SUPPLIER_ID",
                table: "OFFERS",
                column: "SUPPLIER_ID",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
