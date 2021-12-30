using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentDataSystem.WebUI.Migrations
{
    public partial class add_personal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Personals_PersonalId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Grade");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Grade",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Personals_PersonalId",
                table: "Grade",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Personals_PersonalId",
                table: "Grade");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Grade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Grade",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Personals_PersonalId",
                table: "Grade",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
