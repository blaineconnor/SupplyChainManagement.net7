using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCM.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SCM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTITY_NUMBER = table.Column<string>(type: "nchar(11)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PHONE = table.Column<string>(type: "nchar(13)", nullable: false),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DETAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNIT_IN_STOCK = table.Column<int>(type: "int", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "PRODUCT_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LAST_USER_LOGIN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_LOGIN_IP = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    Roles = table.Column<int>(type: "int", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_SUPPLIERS_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REQUESTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    REQUEST_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    REQUEST_STATUS = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IS_APPROVED = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUESTS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    SUPPLIER_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    INVOICE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICES_REQUESTS_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalTable: "REQUESTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVOICES_SUPPLIERS_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFFERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SUPPLIER_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SUPPLIER_ID = table.Column<int>(type: "int", nullable: false),
                    OFFER_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    RequestsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFFERS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_REQUESTS_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "REQUESTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_SUPPLIERS_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REQUEST_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUEST_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUEST_DETAILS_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "REQUEST_DETAIL_REQUEST_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalTable: "REQUESTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APPROVES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    APPROVED_BY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "date", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPROVES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPROVES_OFFERS_OfferId",
                        column: x => x.OfferId,
                        principalTable: "OFFERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APPROVES_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_APPROVES_REQUESTS_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "REQUESTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APPROVES_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_SuppliersId",
                table: "ACCOUNTS",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_USER_ID",
                table: "ACCOUNTS",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_OfferId",
                table: "APPROVES",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_ProductId",
                table: "APPROVES",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_RequestsId",
                table: "APPROVES",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_UserId",
                table: "APPROVES",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_REQUEST_ID",
                table: "INVOICES",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_SUPPLIER_ID",
                table: "INVOICES",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_ProductId",
                table: "OFFERS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_RequestsId",
                table: "OFFERS",
                column: "RequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_SUPPLIER_ID",
                table: "OFFERS",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORY_ID",
                table: "PRODUCTS",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_DETAILS_PRODUCT_ID",
                table: "REQUEST_DETAILS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUEST_DETAILS_REQUEST_ID",
                table: "REQUEST_DETAILS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_UserId",
                table: "REQUESTS",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "APPROVES");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "REQUEST_DETAILS");

            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "REQUESTS");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
