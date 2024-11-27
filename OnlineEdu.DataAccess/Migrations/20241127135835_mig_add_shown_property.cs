using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_shown_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Images",
                newName: "IsShown");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Features",
                newName: "IsShown");

            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "Testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "TeacherSocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "TeacherSocialMedias");

            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "Images",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "IsShown",
                table: "Features",
                newName: "Status");

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
