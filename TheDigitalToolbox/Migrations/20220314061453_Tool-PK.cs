using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDigitalToolbox.Migrations
{
    public partial class ToolPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Macros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "HelpfulLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Guides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToolId",
                table: "Embeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 13, 23, 14, 52, 734, DateTimeKind.Local).AddTicks(4656));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Macros");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "HelpfulLinks");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "ToolId",
                table: "Embeds");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 11, 13, 5, 9, 595, DateTimeKind.Local).AddTicks(569));
        }
    }
}
