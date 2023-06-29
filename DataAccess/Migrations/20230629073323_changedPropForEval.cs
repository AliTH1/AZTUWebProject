using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changedPropForEval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "EvaluationStudent",
                table: "Evaluations",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EvaluationStudent",
                table: "Evaluations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
