using Microsoft.EntityFrameworkCore.Migrations;

namespace StoneShope.Migrations
{
    public partial class AddApplicationTypeToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationTypeID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ApplicationTypeID",
                table: "Product",
                column: "ApplicationTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_ApplicationTypeID",
                table: "Product",
                column: "ApplicationTypeID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_ApplicationTypeID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ApplicationTypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ApplicationTypeID",
                table: "Product");
        }
    }
}
