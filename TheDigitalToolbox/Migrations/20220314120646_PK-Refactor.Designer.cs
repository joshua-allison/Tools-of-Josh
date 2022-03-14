﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheDigitalToolbox.Models;

namespace TheDigitalToolbox.Migrations
{
    [DbContext(typeof(ToolboxContext))]
    [Migration("20220314120646_PK-Refactor")]
    partial class PKRefactor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommenterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CommenterId");

                    b.HasIndex("ToolId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            Date = new DateTime(2022, 3, 14, 5, 6, 45, 583, DateTimeKind.Local).AddTicks(951),
                            Text = "Seeded Example Text."
                        });
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Tool", b =>
                {
                    b.Property<int>("ToolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShareURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("UploaderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ToolId");

                    b.HasIndex("UploaderId");

                    b.ToTable("Tool");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tool");
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Embed", b =>
                {
                    b.HasBaseType("TheDigitalToolbox.Models.Tool");

                    b.Property<string>("iFrameString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Embed");

                    b.HasData(
                        new
                        {
                            ToolId = 1,
                            Creator = "Josh Allison",
                            Description = "This graph shows you the proportion of how much time you lose on activity within a scheduled time frame when you're late.",
                            ShareURL = "https://www.desmos.com/calculator/t2beidgdke",
                            Title = "Activity Time Proportions",
                            iFrameString = "<iframe src = \"https://www.desmos.com/calculator/t2beidgdke?embed\" width = \"500\" height = \"500\" style = \"border: 1px solid #ccc\" frameborder = 0 ></iframe>"
                        });
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Guide", b =>
                {
                    b.HasBaseType("TheDigitalToolbox.Models.Tool");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasDiscriminator().HasValue("Guide");

                    b.HasData(
                        new
                        {
                            ToolId = 2,
                            Creator = "Josh Allison",
                            Description = "Discord and zoom have made it easy to share video and share screen, with some limitations to both, and they don’t support        webcam-in-display functionality. If they do eventually add it, customization will likely be limited. \n Enter Obs Studio with Obs Virtual Camera and VB Virtual Audio.",
                            ShareURL = "https://docs.google.com/document/d/1DPv0Clvu-Aw7UjwIzMMyUkw8t6_L7jkNB5fyCmj5N_8/edit?usp=sharing",
                            Title = "Creating a Virtual Camera/Mic in Obs Studio",
                            Topic = "Virtual Camera / Virtual Audio"
                        });
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.HelpfulLink", b =>
                {
                    b.HasBaseType("TheDigitalToolbox.Models.Tool");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasDiscriminator().HasValue("HelpfulLink");

                    b.HasData(
                        new
                        {
                            ToolId = 3,
                            Creator = "Praegressus Limited Group",
                            Description = "Hex color codes, HTML colors, paint matching, directory and color space conversions.",
                            ShareURL = "https://encycolorpedia.com/",
                            Title = "Encycolorpedia",
                            Subject = "Computer Color Codes"
                        });
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Macro", b =>
                {
                    b.HasBaseType("TheDigitalToolbox.Models.Tool");

                    b.Property<string>("App")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasDiscriminator().HasValue("Macro");

                    b.HasData(
                        new
                        {
                            ToolId = 4,
                            Creator = "Josh Allison",
                            Description = "A small macro designed to make life a little easier in Valheim.",
                            ShareURL = "https://github.com/UBR-JMA/Valheim-Macro",
                            Title = "Valheim Macro",
                            App = "Valheim"
                        });
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Program", b =>
                {
                    b.HasBaseType("TheDigitalToolbox.Models.Tool");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasDiscriminator().HasValue("Program");

                    b.HasData(
                        new
                        {
                            ToolId = 5,
                            Creator = "Josh Allison",
                            Description = "I made this for one of my final projects. It runs just like the tabletop Connect-4 game. (Not really a tool, per se, but still a program I'm proud of)",
                            ShareURL = "https://studio.code.org/projects/applab/KOr2i_IkV1Ajzuigh5zjOng85lpObGzJXJB-7XOjG50",
                            Title = "Connect-4",
                            Language = "Studio Code - App Lab (JavaScript)"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TheDigitalToolbox.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TheDigitalToolbox.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheDigitalToolbox.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TheDigitalToolbox.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Comment", b =>
                {
                    b.HasOne("TheDigitalToolbox.Models.User", "Commenter")
                        .WithMany()
                        .HasForeignKey("CommenterId");

                    b.HasOne("TheDigitalToolbox.Models.Tool", "Tool")
                        .WithMany("Comments")
                        .HasForeignKey("ToolId");

                    b.Navigation("Commenter");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Tool", b =>
                {
                    b.HasOne("TheDigitalToolbox.Models.User", "Uploader")
                        .WithMany()
                        .HasForeignKey("UploaderId");

                    b.Navigation("Uploader");
                });

            modelBuilder.Entity("TheDigitalToolbox.Models.Tool", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
