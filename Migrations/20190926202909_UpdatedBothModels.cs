using Microsoft.EntityFrameworkCore.Migrations;

namespace sdgreacttemplate.Migrations
{
    public partial class UpdatedBothModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionsId",
                table: "Answer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionsId",
                table: "Answer",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionsId",
                table: "Answer",
                column: "QuestionsId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionsId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_QuestionsId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "Answer");
        }
    }
}
