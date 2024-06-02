using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class editproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Attachments_AttachmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AttachmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentGroupId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AttachmentGroupId",
                table: "Products",
                column: "AttachmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProductId",
                table: "Attachments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Products_ProductId",
                table: "Attachments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AttachmentGroups_AttachmentGroupId",
                table: "Products",
                column: "AttachmentGroupId",
                principalTable: "AttachmentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Products_ProductId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AttachmentGroups_AttachmentGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AttachmentGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_ProductId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AttachmentGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Attachments");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AttachmentId",
                table: "Products",
                column: "AttachmentId",
                unique: true,
                filter: "[AttachmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Attachments_AttachmentId",
                table: "Products",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }
    }
}
