using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheDigitalToolbox.Migrations
{
    public partial class PKRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Embeds_EmbeddedId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Guides_GuideId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_HelpfulLinks_HelpfulLinkId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Macros_MacroId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Programs_ProgramId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_AspNetUsers_UploaderId",
                table: "Programs");

            migrationBuilder.DropTable(
                name: "Embeds");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "HelpfulLinks");

            migrationBuilder.DropTable(
                name: "Macros");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EmbeddedId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_GuideId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_HelpfulLinkId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MacroId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.DeleteData(
                table: "Programs",
                keyColumn: "ProgramId",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EmbeddedId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "HelpfulLinkId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MacroId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Programs");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "Tool");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Comments",
                newName: "ToolId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProgramId",
                table: "Comments",
                newName: "IX_Comments_ToolId");

            migrationBuilder.RenameIndex(
                name: "IX_Programs_UploaderId",
                table: "Tool",
                newName: "IX_Tool_UploaderId");

            migrationBuilder.AlterColumn<int>(
                name: "ToolId",
                table: "Tool",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Tool",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<string>(
                name: "App",
                table: "Tool",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Tool",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Tool",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Tool",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "iFrameString",
                table: "Tool",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tool",
                table: "Tool",
                column: "ToolId");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 14, 5, 6, 45, 583, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.InsertData(
                table: "Tool",
                columns: new[] { "ToolId", "Creator", "Description", "Discriminator", "ShareURL", "Title", "UploaderId", "iFrameString" },
                values: new object[] { 1, "Josh Allison", "This graph shows you the proportion of how much time you lose on activity within a scheduled time frame when you're late.", "Embed", "https://www.desmos.com/calculator/t2beidgdke", "Activity Time Proportions", null, "<iframe src = \"https://www.desmos.com/calculator/t2beidgdke?embed\" width = \"500\" height = \"500\" style = \"border: 1px solid #ccc\" frameborder = 0 ></iframe>" });

            migrationBuilder.InsertData(
                table: "Tool",
                columns: new[] { "ToolId", "Creator", "Description", "Discriminator", "ShareURL", "Title", "Topic", "UploaderId" },
                values: new object[] { 2, "Josh Allison", "Discord and zoom have made it easy to share video and share screen, with some limitations to both, and they don’t support        webcam-in-display functionality. If they do eventually add it, customization will likely be limited. \n Enter Obs Studio with Obs Virtual Camera and VB Virtual Audio.", "Guide", "https://docs.google.com/document/d/1DPv0Clvu-Aw7UjwIzMMyUkw8t6_L7jkNB5fyCmj5N_8/edit?usp=sharing", "Creating a Virtual Camera/Mic in Obs Studio", "Virtual Camera / Virtual Audio", null });

            migrationBuilder.InsertData(
                table: "Tool",
                columns: new[] { "ToolId", "Creator", "Description", "Discriminator", "ShareURL", "Subject", "Title", "UploaderId" },
                values: new object[] { 3, "Praegressus Limited Group", "Hex color codes, HTML colors, paint matching, directory and color space conversions.", "HelpfulLink", "https://encycolorpedia.com/", "Computer Color Codes", "Encycolorpedia", null });

            migrationBuilder.InsertData(
                table: "Tool",
                columns: new[] { "ToolId", "App", "Creator", "Description", "Discriminator", "ShareURL", "Title", "UploaderId" },
                values: new object[] { 4, "Valheim", "Josh Allison", "A small macro designed to make life a little easier in Valheim.", "Macro", "https://github.com/UBR-JMA/Valheim-Macro", "Valheim Macro", null });

            migrationBuilder.InsertData(
                table: "Tool",
                columns: new[] { "ToolId", "Creator", "Description", "Discriminator", "Language", "ShareURL", "Title", "UploaderId" },
                values: new object[] { 5, "Josh Allison", "I made this for one of my final projects. It runs just like the tabletop Connect-4 game. (Not really a tool, per se, but still a program I'm proud of)", "Program", "Studio Code - App Lab (JavaScript)", "https://studio.code.org/projects/applab/KOr2i_IkV1Ajzuigh5zjOng85lpObGzJXJB-7XOjG50", "Connect-4", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tool_ToolId",
                table: "Comments",
                column: "ToolId",
                principalTable: "Tool",
                principalColumn: "ToolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tool_AspNetUsers_UploaderId",
                table: "Tool",
                column: "UploaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tool_ToolId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tool_AspNetUsers_UploaderId",
                table: "Tool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tool",
                table: "Tool");

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "ToolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "ToolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "ToolId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "ToolId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tool",
                keyColumn: "ToolId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "App",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Tool");

            migrationBuilder.DropColumn(
                name: "iFrameString",
                table: "Tool");

            migrationBuilder.RenameTable(
                name: "Tool",
                newName: "Programs");

            migrationBuilder.RenameColumn(
                name: "ToolId",
                table: "Comments",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ToolId",
                table: "Comments",
                newName: "IX_Comments_ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Tool_UploaderId",
                table: "Programs",
                newName: "IX_Programs_UploaderId");

            migrationBuilder.AddColumn<int>(
                name: "EmbeddedId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HelpfulLinkId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MacroId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Programs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToolId",
                table: "Programs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "ProgramId");

            migrationBuilder.CreateTable(
                name: "Embeds",
                columns: table => new
                {
                    EmbeddedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EmbedString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    UploaderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embeds", x => x.EmbeddedId);
                    table.ForeignKey(
                        name: "FK_Embeds_AspNetUsers_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    GuideId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ShareURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UploaderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.GuideId);
                    table.ForeignKey(
                        name: "FK_Guides_AspNetUsers_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HelpfulLinks",
                columns: table => new
                {
                    HelpfulLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ShareURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    UploaderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpfulLinks", x => x.HelpfulLinkId);
                    table.ForeignKey(
                        name: "FK_HelpfulLinks_AspNetUsers_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Macros",
                columns: table => new
                {
                    MacroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    App = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ShareURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    UploaderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macros", x => x.MacroId);
                    table.ForeignKey(
                        name: "FK_Macros_AspNetUsers_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 3, 13, 23, 29, 47, 349, DateTimeKind.Local).AddTicks(6040));

            migrationBuilder.InsertData(
                table: "Embeds",
                columns: new[] { "EmbeddedId", "Creator", "Description", "EmbedString", "ShareURL", "Title", "ToolId", "UploaderId" },
                values: new object[] { 1, "Josh Allison", "This graph shows you the proportion of how much time you lose on activity within a scheduled time frame when you're late.", "<iframe src = \"https://www.desmos.com/calculator/t2beidgdke?embed\" width = \"500\" height = \"500\" style = \"border: 1px solid #ccc\" frameborder = 0 ></iframe>", "https://www.desmos.com/calculator/t2beidgdke", "Activity Time Proportions", 1, null });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "GuideId", "Creator", "Description", "ShareURL", "Title", "ToolId", "Topic", "UploaderId" },
                values: new object[] { 11, "Josh Allison", "Discord and zoom have made it easy to share video and share screen, with some limitations to both, and they don’t support        webcam-in-display functionality. If they do eventually add it, customization will likely be limited. \n Enter Obs Studio with Obs Virtual Camera and VB Virtual Audio.", "https://docs.google.com/document/d/1DPv0Clvu-Aw7UjwIzMMyUkw8t6_L7jkNB5fyCmj5N_8/edit?usp=sharing", "Creating a Virtual Camera/Mic in Obs Studio", 2, "Virtual Camera / Virtual Audio", null });

            migrationBuilder.InsertData(
                table: "HelpfulLinks",
                columns: new[] { "HelpfulLinkId", "Creator", "Description", "ShareURL", "Subject", "Title", "ToolId", "UploaderId" },
                values: new object[] { 1, "Praegressus Limited Group", "Hex color codes, HTML colors, paint matching, directory and color space conversions.", "https://encycolorpedia.com/", "Computer Color Codes", "Encycolorpedia", 3, null });

            migrationBuilder.InsertData(
                table: "Macros",
                columns: new[] { "MacroId", "App", "Creator", "Description", "ShareURL", "Title", "ToolId", "UploaderId" },
                values: new object[] { 1, "Valheim", "Josh Allison", "A small macro designed to make life a little easier in Valheim.", "https://github.com/UBR-JMA/Valheim-Macro", "Valheim Macro", 4, null });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "ProgramId", "Creator", "Description", "Language", "ShareURL", "Title", "ToolId", "UploaderId" },
                values: new object[] { 1, "Josh Allison", "I made this for one of my final projects. It runs just like the tabletop Connect-4 game. (Not really a tool, per se, but still a program I'm proud of)", "Studio Code - App Lab (JavaScript)", "https://studio.code.org/projects/applab/KOr2i_IkV1Ajzuigh5zjOng85lpObGzJXJB-7XOjG50", "Connect-4", 5, null });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EmbeddedId",
                table: "Comments",
                column: "EmbeddedId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GuideId",
                table: "Comments",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_HelpfulLinkId",
                table: "Comments",
                column: "HelpfulLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MacroId",
                table: "Comments",
                column: "MacroId");

            migrationBuilder.CreateIndex(
                name: "IX_Embeds_UploaderId",
                table: "Embeds",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Guides_UploaderId",
                table: "Guides",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpfulLinks_UploaderId",
                table: "HelpfulLinks",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Macros_UploaderId",
                table: "Macros",
                column: "UploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Embeds_EmbeddedId",
                table: "Comments",
                column: "EmbeddedId",
                principalTable: "Embeds",
                principalColumn: "EmbeddedId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Guides_GuideId",
                table: "Comments",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "GuideId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_HelpfulLinks_HelpfulLinkId",
                table: "Comments",
                column: "HelpfulLinkId",
                principalTable: "HelpfulLinks",
                principalColumn: "HelpfulLinkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Macros_MacroId",
                table: "Comments",
                column: "MacroId",
                principalTable: "Macros",
                principalColumn: "MacroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Programs_ProgramId",
                table: "Comments",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_AspNetUsers_UploaderId",
                table: "Programs",
                column: "UploaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
