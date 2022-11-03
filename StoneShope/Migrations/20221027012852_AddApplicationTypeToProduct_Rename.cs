using Microsoft.EntityFrameworkCore.Migrations;

namespace StoneShope.Migrations
{
    public partial class AddApplicationTypeToProduct_Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_ApplicationTypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ApplicationTypeID",
                table: "Product",
                newName: "ApplicationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ApplicationTypeID",
                table: "Product",
                newName: "IX_Product_ApplicationTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationTypeId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ApplicationType_ApplicationTypeId",
                table: "Product",
                column: "ApplicationTypeId",
                principalTable: "ApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ApplicationType_ApplicationTypeId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ApplicationTypeId",
                table: "Product",
                newName: "ApplicationTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ApplicationTypeId",
                table: "Product",
                newName: "IX_Product_ApplicationTypeID");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationTypeID",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_ApplicationTypeID",
                table: "Product",
                column: "ApplicationTypeID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
