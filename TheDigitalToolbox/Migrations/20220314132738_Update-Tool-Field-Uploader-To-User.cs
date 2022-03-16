using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDigitalToolbox.Migrations
{
    public partial class UpdateToolFieldUploaderToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tool_AspNetUsers_UploaderId",
                table: "Tool");

            migrationBuilder.RenameColumn(
                name: "UploaderId",
                table: "Tool",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_UploaderId",
                table: "Tool",
                newName: "IX_Tool_UserId");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 14, 6, 27, 38, 76, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_AspNetUsers_UserId",
                table: "Tool",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tool_AspNetUsers_UserId",
                table: "Tool");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tool",
                newName: "UploaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_UserId",
                table: "Tool",
                newName: "IX_Tool_UploaderId");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 14, 5, 12, 27, 112, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_AspNetUsers_UploaderId",
                table: "Tool",
                column: "UploaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
