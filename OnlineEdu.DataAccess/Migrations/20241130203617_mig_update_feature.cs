using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_feature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Abouts_AboutID",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_AboutID",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "AboutID",
                table: "Features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AboutID",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Features_AboutID",
                table: "Features",
                column: "AboutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Abouts_AboutID",
                table: "Features",
                column: "AboutID",
                principalTable: "Abouts",
                principalColumn: "AboutID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
