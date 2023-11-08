using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paruppgift_e_handel.Migrations
{
    /// <inheritdoc />
    public partial class addedloginlogicandcustomerproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders");

            migrationBuilder.RenameColumn(
                name: "CustomerPhone",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "CustomerPhone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "CustomerEmail");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "CustomerAddress");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_Customers_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
