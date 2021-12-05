using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentDataSystem.WebUI.Migrations
{
    public partial class addpasswordColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Personals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Personals");
        }
    }
}
