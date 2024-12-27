using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_blog_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "BlogCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "BlogCategories");
        }
    }
}
