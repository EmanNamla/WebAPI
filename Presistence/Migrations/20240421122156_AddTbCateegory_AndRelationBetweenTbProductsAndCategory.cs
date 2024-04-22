using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTbCateegory_AndRelationBetweenTbProductsAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Attachment_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Attachment_AttachmentId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.RenameIndex(
                name: "IX_Product_AttachmentId",
                table: "Products",
                newName: "IX_Products_AttachmentId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Attachments_AttachmentId",
                table: "AspNetUsers",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Attachments_AttachmentId",
                table: "Products",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Attachments_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Attachments_AttachmentId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.RenameIndex(
                name: "IX_Products_AttachmentId",
                table: "Product",
                newName: "IX_Product_AttachmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Attachment_AttachmentId",
                table: "AspNetUsers",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Attachment_AttachmentId",
                table: "Product",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }
    }
}
