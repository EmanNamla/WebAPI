using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPropinTnAppUser_AndAddTbAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AttachmentId",
                table: "AspNetUsers",
                column: "AttachmentId",
                unique: true,
                filter: "[AttachmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Attachment_AttachmentId",
                table: "AspNetUsers",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Attachment_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");
        }
    }
}
