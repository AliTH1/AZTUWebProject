using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class studEvalFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentInfoId",
                table: "StudentEvaluationFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluationFiles_StudentInfoId",
                table: "StudentEvaluationFiles",
                column: "StudentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEvaluationFiles_StudentsInfo_StudentInfoId",
                table: "StudentEvaluationFiles",
                column: "StudentInfoId",
                principalTable: "StudentsInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEvaluationFiles_StudentsInfo_StudentInfoId",
                table: "StudentEvaluationFiles");

            migrationBuilder.DropIndex(
                name: "IX_StudentEvaluationFiles_StudentInfoId",
                table: "StudentEvaluationFiles");

            migrationBuilder.DropColumn(
                name: "StudentInfoId",
                table: "StudentEvaluationFiles");
        }
    }
}
