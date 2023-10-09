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
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
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
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    REQUEST_DATE = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    REQUEST_STATUS = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<int>(type: "int", nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    IS_APPROVED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUESTS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
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
                    DATE_TIME = table.Column<DateTime>(type: "date", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    RequestsId = table.Column<int>(type: "int", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPROVES", x => x.ID);
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

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_USER_ID",
                table: "ACCOUNTS",
                column: "USER_ID",
                unique: true);

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
                name: "IX_REQUESTS_USER_ID",
                table: "REQUESTS",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "APPROVES");

            migrationBuilder.DropTable(
                name: "REQUEST_DETAILS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "REQUESTS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
