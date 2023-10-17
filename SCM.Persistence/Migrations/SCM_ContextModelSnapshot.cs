﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCM.Persistence.Context;

#nullable disable

namespace SCM.Persistence.Migrations
{
    [DbContext(typeof(SCM_Context))]
    partial class SCM_ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SCM.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID")
                        .HasColumnOrder(2);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("USER_NAME")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ACCOUNTS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Approves", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(7);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApprovedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("APPROVED_BY")
                        .HasColumnOrder(5);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("date")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnOrder(3);

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<string>("RequestedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestsId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("STATUS")
                        .HasColumnOrder(6);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestsId");

                    b.HasIndex("UserId");

                    b.ToTable("APPROVES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

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

                    b.HasKey("Id");

                    b.ToTable("CATEGORIES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("AMOUNT")
                        .HasColumnOrder(5);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

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

                    b.Property<int>("RequestId")
                        .HasColumnType("int")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnOrder(3);

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("INVOICES", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("AMOUNT")
                        .HasColumnOrder(4);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnOrder(3);

                    b.Property<int?>("RequestsId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("SUPPLIER_ID")
                        .HasColumnOrder(6);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SUPPLIER_NAME")
                        .HasColumnOrder(5);

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestsId");

                    b.ToTable("OFFERS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY_ID")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

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

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("PRODUCTS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Requests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("AMOUNT");

                    b.Property<string>("By")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasColumnName("IS_APPROVED");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("IS_DELETED")
                        .HasColumnOrder(30)
                        .HasDefaultValueSql("0");

                    b.Property<string>("RejectionReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int")
                        .HasColumnName("REQUEST_ID")
                        .HasColumnOrder(2);

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("REQUEST_STATUS");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("REQUESTS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BIRTHDATE")
                        .HasColumnOrder(9);

                    b.Property<string>("By")
                        .HasColumnType("NVARCHAR(10)")
                        .HasColumnName("BY")
                        .HasColumnOrder(27);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATE_TIME")
                        .HasColumnOrder(26);

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

                    b.HasKey("Id");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("SCM.Domain.Entities.Account", b =>
                {
                    b.HasOne("SCM.Domain.Entities.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("SCM.Domain.Entities.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Approves", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Offer", "Offer")
                        .WithMany("Approves")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.Product", null)
                        .WithMany("Approves")
                        .HasForeignKey("ProductId");

                    b.HasOne("SCM.Domain.Entities.Requests", "Requests")
                        .WithMany("Approves")
                        .HasForeignKey("RequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCM.Domain.Entities.User", null)
                        .WithMany("Approves")
                        .HasForeignKey("UserId");

                    b.Navigation("Offer");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Requests", "Request")
                        .WithMany("Invoices")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Offer", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Product", null)
                        .WithMany("Offers")
                        .HasForeignKey("ProductId");

                    b.HasOne("SCM.Domain.Entities.Requests", null)
                        .WithMany("Offers")
                        .HasForeignKey("RequestsId");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Product", b =>
                {
                    b.HasOne("SCM.Domain.Entities.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PRODUCT_CATEGORY_CATEGORY_ID");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Requests", b =>
                {
                    b.HasOne("SCM.Domain.Entities.User", null)
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCM.Domain.Entities.Categories", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Offer", b =>
                {
                    b.Navigation("Approves");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Product", b =>
                {
                    b.Navigation("Approves");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("SCM.Domain.Entities.Requests", b =>
                {
                    b.Navigation("Approves");

                    b.Navigation("Invoices");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("SCM.Domain.Entities.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Approves");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
