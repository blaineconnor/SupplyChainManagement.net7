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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auth = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_ID = table.Column<long>(type: "bigint", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DETAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNIT_IN_STOCK = table.Column<int>(type: "int", nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "DEPARTMENT",
                columns: table => new
                {
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDENTITY_NUMBER = table.Column<string>(type: "nchar(11)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PHONE = table.Column<string>(type: "nchar(13)", nullable: false),
                    BIRTHDATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_DEPARTMENT_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LAST_USER_LOGIN = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LAST_LOGIN_IP = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authorization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_EMPLOYEES_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APPROVES",
                columns: table => new
                {
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    REQUEST_ID = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    APPROVED_ID = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: true),
                    OfferId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPROVES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPROVES_EMPLOYEES_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APPROVER_ID = table.Column<long>(type: "bigint", nullable: false),
                    INVOICE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    RequestId = table.Column<long>(type: "bigint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICES_COMPANY_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "COMPANY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVOICES_EMPLOYEES_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFFERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<long>(type: "bigint", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SUPPLIER_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SUPPLIER_ID = table.Column<long>(type: "bigint", nullable: false),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    OFFER_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFFERS_Suppliers_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REQUESTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BY = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ApproverId = table.Column<long>(type: "bigint", nullable: false),
                    ApproverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REQUEST_STATUS = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HowMany = table.Column<short>(type: "smallint", nullable: false),
                    IS_APPROVED = table.Column<bool>(type: "bit", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUESTS_ACCOUNTS_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACCOUNTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_REQUESTS_APPROVES_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "APPROVES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_REQUESTS_EMPLOYEES_UserId",
                        column: x => x.UserId,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_REQUESTS_OFFERS_OfferId",
                        column: x => x.OfferId,
                        principalTable: "OFFERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_REQUESTS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_USER_ID",
                table: "ACCOUNTS",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_EmployeeId",
                table: "APPROVES",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_OfferId",
                table: "APPROVES",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_APPROVES_REQUEST_ID",
                table: "APPROVES",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_CompanyId",
                table: "DEPARTMENT",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_CompanyId",
                table: "EMPLOYEES",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_DepartmentId",
                table: "EMPLOYEES",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_CompanyId",
                table: "INVOICES",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_EmployeeId",
                table: "INVOICES",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_RequestId",
                table: "INVOICES",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_REQUEST_ID",
                table: "OFFERS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_SUPPLIER_ID",
                table: "OFFERS",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORY_ID",
                table: "PRODUCTS",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_AccountId",
                table: "REQUESTS",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_ApproverId",
                table: "REQUESTS",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_OfferId",
                table: "REQUESTS",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_ProductId",
                table: "REQUESTS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_UserId",
                table: "REQUESTS",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_APPROVES_OFFERS_OfferId",
                table: "APPROVES",
                column: "OfferId",
                principalTable: "OFFERS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_APPROVES_REQUESTS_REQUEST_ID",
                table: "APPROVES",
                column: "REQUEST_ID",
                principalTable: "REQUESTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "REQUEST_INVOICES_REQUESTID",
                table: "INVOICES",
                column: "RequestId",
                principalTable: "REQUESTS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OFFERS_REQUESTS_REQUEST_ID",
                table: "OFFERS",
                column: "REQUEST_ID",
                principalTable: "REQUESTS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACCOUNTS_EMPLOYEES_USER_ID",
                table: "ACCOUNTS");

            migrationBuilder.DropForeignKey(
                name: "FK_APPROVES_EMPLOYEES_EmployeeId",
                table: "APPROVES");

            migrationBuilder.DropForeignKey(
                name: "FK_REQUESTS_EMPLOYEES_UserId",
                table: "REQUESTS");

            migrationBuilder.DropForeignKey(
                name: "FK_APPROVES_OFFERS_OfferId",
                table: "APPROVES");

            migrationBuilder.DropForeignKey(
                name: "FK_REQUESTS_OFFERS_OfferId",
                table: "REQUESTS");

            migrationBuilder.DropForeignKey(
                name: "FK_APPROVES_REQUESTS_REQUEST_ID",
                table: "APPROVES");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "REQUESTS");

            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "APPROVES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");
        }
    }
}
