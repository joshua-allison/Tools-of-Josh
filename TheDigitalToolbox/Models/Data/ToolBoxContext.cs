using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheDigitalToolbox.Models
{
    public class ToolboxContext : IdentityDbContext<User>
    {
        public ToolboxContext(DbContextOptions<ToolboxContext> options) : base(options) { }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Embed> Embeds{ get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<HelpfulLink> HelpfulLinks { get; set; }
        public DbSet<Macro> Macros { get; set; }
        public DbSet<Program> Programs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed data - Ready for initial Migration
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1,
                    Commenter = null,
                    Date = DateTime.Now,
                    Text = "Seeded Example Text."
                }
            );
            modelBuilder.Entity<Embed>().HasData(
                new Embed
                {
                    ToolId = 1,
                    Uploader = null,
                    Creator = "Josh Allison",
                    Title = "Activity Time Proportions",
                    Description = "This graph shows you the proportion of how much time you lose on activity within a scheduled time frame when you're late.",
                    ShareURL = "https://www.desmos.com/calculator/t2beidgdke",
                    iFrameString = "<iframe src = \"https://www.desmos.com/calculator/t2beidgdke?embed\" width = \"500\" height = \"500\" style = \"border: 1px solid #ccc\" frameborder = 0 ></iframe>"
                }
            );
            modelBuilder.Entity<Guide>().HasData(
                new Guide
                {
                    ToolId = 2,
                    Uploader = null,
                    Creator = "Josh Allison",
                    Title = "Creating a Virtual Camera/Mic in Obs Studio",
                    Description = "Discord and zoom have made it easy to share video and share screen, with some limitations to both, and they don’t support        webcam-in-display functionality. If they do eventually add it, customization will likely be limited. " +
                        "\n Enter Obs Studio with Obs Virtual Camera and VB Virtual Audio.",
                    ShareURL = "https://docs.google.com/document/d/1DPv0Clvu-Aw7UjwIzMMyUkw8t6_L7jkNB5fyCmj5N_8/edit?usp=sharing",
                    Topic = "Virtual Camera / Virtual Audio",
                }
            );
            modelBuilder.Entity<HelpfulLink>().HasData(
                new HelpfulLink
                {
                    ToolId = 3,
                    Uploader = null,
                    Creator = "Praegressus Limited Group",
                    Title = "Encycolorpedia",
                    Description = "Hex color codes, HTML colors, paint matching, directory and color space conversions.",
                    ShareURL = "https://encycolorpedia.com/",
                    Subject = "Computer Color Codes",
                }
            );
            modelBuilder.Entity<Macro>().HasData(
                new Macro
                {
                    ToolId = 4,
                    Uploader = null,
                    Creator = "Josh Allison",
                    Title = "Valheim Macro",
                    Description = "A small macro designed to make life a little easier in Valheim.",
                    ShareURL = "https://github.com/UBR-JMA/Valheim-Macro",
                    App = "Valheim",
                }
            );
            modelBuilder.Entity<Program>().HasData(
                new Program
                {
                    ToolId = 5,
                    Uploader = null,
                    Creator = "Josh Allison",
                    Title = "Connect-4",
                    Description = "I made this for one of my final projects. It runs just like the tabletop Connect-4 game. (Not really a tool, per se, but still a program I'm proud of)",
                    ShareURL = "https://studio.code.org/projects/applab/KOr2i_IkV1Ajzuigh5zjOng85lpObGzJXJB-7XOjG50",
                    Language = "Studio Code - App Lab (JavaScript)",
                }
            );
        }
        public static async Task CreateAdminUser(IServiceProvider serviceProvider) // add admin account
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();    // create a user-manager object
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>(); // create a role-manager object
            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";
            if (await roleManager.FindByNameAsync(roleName) == null)        // if role doesn't exist, 
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));  // create it
            }
            if (await userManager.FindByNameAsync(username) == null) // if username doesn't exist, 
            {
                User user = new User { UserName = username };   // create a user with the specified username
                var result = await userManager.CreateAsync(user, password); // attach the specified password
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName); // attach the specified role
                }
            }
        }
    }
}