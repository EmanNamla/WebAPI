using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAttachmentGroupIdInTbUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Attachments_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "AspNetUsers",
                newName: "attachmentGroupId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Attachments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AppUserId",
                table: "Attachments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_attachmentGroupId",
                table: "AspNetUsers",
                column: "attachmentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AttachmentGroups_attachmentGroupId",
                table: "AspNetUsers",
                column: "attachmentGroupId",
                principalTable: "AttachmentGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AspNetUsers_AppUserId",
                table: "Attachments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AttachmentGroups_attachmentGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AspNetUsers_AppUserId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_AppUserId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_attachmentGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "attachmentGroupId",
                table: "AspNetUsers",
                newName: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AttachmentId",
                table: "AspNetUsers",
                column: "AttachmentId",
                unique: true,
                filter: "[AttachmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Attachments_AttachmentId",
                table: "AspNetUsers",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }
    }
}
