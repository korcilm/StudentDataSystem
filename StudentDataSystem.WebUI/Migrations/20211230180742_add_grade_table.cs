using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentDataSystem.WebUI.Migrations
{
    public partial class add_grade_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Personals_PersonalId",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Students_StudentId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_PersonalId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_StudentId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Final",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Midterm",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Lesson");

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    Midterm = table.Column<double>(nullable: false),
                    Final = table.Column<double>(nullable: false),
                    PersonalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_Personals_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grade_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_LessonId",
                table: "Grade",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_PersonalId",
                table: "Grade",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId",
                table: "Grade",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.AddColumn<double>(
                name: "Final",
                table: "Lesson",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Midterm",
                table: "Lesson",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_PersonalId",
                table: "Lesson",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_StudentId",
                table: "Lesson",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Personals_PersonalId",
                table: "Lesson",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Students_StudentId",
                table: "Lesson",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
