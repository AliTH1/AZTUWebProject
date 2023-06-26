using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SubjectsTeacherRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherInfoId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherInfoId",
                table: "Subjects",
                column: "TeacherInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_TeachersInfo_TeacherInfoId",
                table: "Subjects",
                column: "TeacherInfoId",
                principalTable: "TeachersInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_TeachersInfo_TeacherInfoId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherInfoId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TeacherInfoId",
                table: "Subjects");
        }
    }
}
