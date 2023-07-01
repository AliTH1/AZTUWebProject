using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class deletedTeacherFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherEvaluationFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TeacherEvaluationFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherEvaluationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherEvaluationFiles_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherEvaluationFiles_EvaluationId",
                table: "TeacherEvaluationFiles",
                column: "EvaluationId",
                unique: true);
        }
    }
}
