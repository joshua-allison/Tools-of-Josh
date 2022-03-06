using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDigitalToolbox.Migrations
{
    public partial class Reseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Embeds",
                columns: new[] { "EmbeddedId", "Creator", "Description", "EmbedString", "ShareURL", "Title", "UploaderId" },
                values: new object[] { 1, "Josh Allison", "This graph shows you the proportion of how much time you lose on activity within a scheduled time frame when you're late.", "< iframe src = \"https://www.desmos.com/calculator/t2beidgdke?embed\" width = \"500\" height = \"500\" style = \"border: 1px solid #ccc\" frameborder = 0 ></ iframe >", "https://www.desmos.com/calculator/t2beidgdke", "Activity Time Proportions", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
