using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenant",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tenant",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tenant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tenant",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tenancy",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Tenancy",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tenancy",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tenancy",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RentPayment",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RentPayment",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RentPayment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RentPayment",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RentCharge",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RentCharge",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RentCharge",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RentCharge",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Properties",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Properties",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Properties",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Properties",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Owner",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Owner",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Owner",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Owner",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Landlord",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Landlord",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Landlord",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Landlord",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tenancy");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Tenancy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tenancy");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tenancy");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RentPayment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RentCharge");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RentCharge");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RentCharge");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RentCharge");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Landlord");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Landlord");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Landlord");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Landlord");
        }
    }
}
