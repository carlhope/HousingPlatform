using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertyTenancyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Properties");

            migrationBuilder.AddColumn<Guid>(
                name: "LandlordId",
                table: "Properties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Properties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Landlord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenancy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandlordId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenancy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenancy_Landlord_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenancy_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentCharge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenancyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentCharge_Tenancy_TenancyId",
                        column: x => x.TenancyId,
                        principalTable: "Tenancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenancyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaidOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentPayment_Tenancy_TenancyId",
                        column: x => x.TenancyId,
                        principalTable: "Tenancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    TenancyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenant_Tenancy_TenancyId",
                        column: x => x.TenancyId,
                        principalTable: "Tenancy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentCharge_TenancyId",
                table: "RentCharge",
                column: "TenancyId");

            migrationBuilder.CreateIndex(
                name: "IX_RentPayment_TenancyId",
                table: "RentPayment",
                column: "TenancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenancy_LandlordId",
                table: "Tenancy",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenancy_PropertyId",
                table: "Tenancy",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_TenancyId",
                table: "Tenant",
                column: "TenancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlord_LandlordId",
                table: "Properties",
                column: "LandlordId",
                principalTable: "Landlord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Owner_OwnerId",
                table: "Properties",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlord_LandlordId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Owner_OwnerId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "RentCharge");

            migrationBuilder.DropTable(
                name: "RentPayment");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Tenancy");

            migrationBuilder.DropTable(
                name: "Landlord");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Properties");

            migrationBuilder.AddColumn<decimal>(
                name: "Rent",
                table: "Properties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
