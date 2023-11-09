using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paruppgift_e_handel.Migrations
{
    /// <inheritdoc />
    public partial class addedDateTimetoCustomerOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBeenShipped",
                table: "CustomerOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCreated",
                table: "CustomerOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderShipped",
                table: "CustomerOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBeenShipped",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "OrderCreated",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "OrderShipped",
                table: "CustomerOrders");
        }
    }
}
