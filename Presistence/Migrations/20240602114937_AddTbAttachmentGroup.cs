using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTbAttachmentGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttachmentGroupId",
                table: "Attachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Attachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AttachmentGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentGroupId",
                table: "Attachments",
                column: "AttachmentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AttachmentGroups_AttachmentGroupId",
                table: "Attachments",
                column: "AttachmentGroupId",
                principalTable: "AttachmentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AttachmentGroups_AttachmentGroupId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "AttachmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_AttachmentGroupId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AttachmentGroupId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Attachments");
        }
    }
}
