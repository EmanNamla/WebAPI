using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AspNetUsers_AppUserId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Products_ProductId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_AppUserId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_ProductId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Attachments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AppUserId",
                table: "Attachments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProductId",
                table: "Attachments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AspNetUsers_AppUserId",
                table: "Attachments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Products_ProductId",
                table: "Attachments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
