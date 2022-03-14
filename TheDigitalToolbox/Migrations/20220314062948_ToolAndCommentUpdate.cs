using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDigitalToolbox.Migrations
{
    public partial class ToolAndCommentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 13, 23, 29, 47, 349, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "Embeds",
                keyColumn: "EmbeddedId",
                keyValue: 1,
                column: "ToolId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Guides",
                keyColumn: "GuideId",
                keyValue: 11,
                column: "ToolId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HelpfulLinks",
                keyColumn: "HelpfulLinkId",
                keyValue: 1,
                column: "ToolId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Macros",
                keyColumn: "MacroId",
                keyValue: 1,
                column: "ToolId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 1,
                column: "ToolId",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 13, 23, 14, 52, 734, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Embeds",
                keyColumn: "EmbeddedId",
                keyValue: 1,
                column: "ToolId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Guides",
                keyColumn: "GuideId",
                keyValue: 11,
                column: "ToolId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "HelpfulLinks",
                keyColumn: "HelpfulLinkId",
                keyValue: 1,
                column: "ToolId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Macros",
                keyColumn: "MacroId",
                keyValue: 1,
                column: "ToolId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyValue: 1,
                column: "ToolId",
                value: 0);
        }
    }
}
