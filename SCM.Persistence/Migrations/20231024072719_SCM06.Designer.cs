﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCM.Persistence.Context;

#nullable disable

namespace SCM.Persistence.Migrations
{
    [DbContext(typeof(SCM_Context))]
    [Migration("20231024072719_SCM06")]
    partial class SCM06
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SCM.Domain.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Authorization")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastUserIP")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LAST_LOGIN_IP")
                        .HasColumnOrder(6);

                    b.Property<DateTime?>("LastUserLogin")
                        .HasColumnType("datetime2")
                        .HasColumnName("LAST_USER_LOGIN")
                        .HasColumnOrder(5);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PASSWORD")
                        .HasColumnOrder(4);

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnOrder(2);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("USER_ID")
                        .HasColumnOrder(2);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("USER_NAME")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.ToTable("ACCOUNTS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Approves", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(7);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ApproveId")
                        .HasColumnType("bigint")
                        .HasColumnName("APPROVED_ID");

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<long?>("OfferId")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint")
                        .HasColumnName("REQUEST_ID");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("STATUS")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OfferId");

                    b.HasIndex("RequestId");

                    b.ToTable("APPROVES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CATEGORY_NAME")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.HasKey("Id");

                    b.ToTable("CATEGORIES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("COMPANY_NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PHONE");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("COMPANY", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("DEPARTMENT_NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("DEPARTMENT", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BIRTHDATE")
                        .HasColumnOrder(9);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("EMAIL")
                        .HasColumnOrder(7);

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nchar(11)")
                        .HasColumnName("IDENTITY_NUMBER")
                        .HasColumnOrder(4);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(5);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nchar(13)")
                        .HasColumnName("PHONE")
                        .HasColumnOrder(8);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("SURNAME")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("EMPLOYEES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("ApproverId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("APPROVER_ID")
                        .HasColumnOrder(4);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime")
                        .HasColumnName("INVOICE_DATE")
                        .HasColumnOrder(6);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<long?>("OfferId")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RequestId");

                    b.ToTable("INVOICES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Offer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("AMOUNT")
                        .HasColumnOrder(4);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnOrder(3);

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("OFFER_STATUS");

                    b.Property<long?>("SupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnOrder(6);

                    b.Property<string>("SupplierName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SUPPLIER_NAME")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("SupplierId");

                    b.ToTable("OFFERS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("CATEGORY_ID")
                        .HasColumnOrder(2);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DETAIL")
                        .HasColumnOrder(4);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("NAME")
                        .HasColumnOrder(3);

                    b.Property<int>("UnitInStock")
                        .HasColumnType("int")
                        .HasColumnName("UNIT_IN_STOCK")
                        .HasColumnOrder(5);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("UNIT_PRICE")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("ADDED_TIME")
                        .HasColumnOrder(26);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("AMOUNT");

                    b.Property<long?>("ApproverId")
                        .HasColumnType("bigint");

                    b.Property<string>("By")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("HowMany")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasColumnName("IS_APPROVED");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<long?>("OfferId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("RejectionReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("REQUEST_STATUS");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_TIME")
                        .HasColumnOrder(26);

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("OfferId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("REQUESTS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Auth")
                        .HasColumnType("int");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Approves", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Employee", null)
                        .WithMany("Approves")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SCM.Domain.Entities.Offer", null)
                        .WithMany("Approves")
                        .HasForeignKey("OfferId");

                    b.HasOne("SCM.Domain.Entities.Request", null)
                        .WithMany("Approves")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCM.Domain.Entities.Department", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Employee", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Account", "Account")
                        .WithOne("Employee")
                        .HasForeignKey("SCM.Domain.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Company");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Request", "Request")
                        .WithMany("Invoices")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("REQUEST_INVOICES_REQUESTID");

                    b.Navigation("Company");

                    b.Navigation("Employee");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Offer", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Request", "Request")
                        .WithMany("Offers")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Supplier", "Supplier")
                        .WithMany("Offers")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Request");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Product", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Category", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PRODUCT_CATEGORY_CATEGORY_ID");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Request", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Approves", "approves")
                        .WithMany("Requests")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SCM.Domain.Entities.Offer", "Offer")
                        .WithMany("Requests")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SCM.Domain.Entities.Product", "Product")
                        .WithMany("Requests")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Employee", "Employee")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Employee");

                    b.Navigation("Offer");

                    b.Navigation("Product");

                    b.Navigation("approves");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Supplier", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Account", "Account")
                        .WithOne("Supplier")
                        .HasForeignKey("SCM.Domain.Entities.Supplier", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Account", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("Supplier")
                        .IsRequired();
                });

            modelBuilder.Entity("SCM.Domain.Entities.Approves", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Approves");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Offer", b =>
                {
                    b.Navigation("Approves");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Product", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Request", b =>
                {
                    b.Navigation("Approves");

                    b.Navigation("Invoices");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Supplier", b =>
                {
                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
