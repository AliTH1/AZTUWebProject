using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addedStudEval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentEvaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    StudentInfoId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEvaluations", x => new { x.EvaluationId, x.StudentInfoId });
                    table.ForeignKey(
                        name: "FK_StudentEvaluations_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEvaluations_StudentsInfo_StudentInfoId",
                        column: x => x.StudentInfoId,
                        principalTable: "StudentsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluations_StudentInfoId",
                table: "StudentEvaluations",
                column: "StudentInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentEvaluations");
        }
    }
}
