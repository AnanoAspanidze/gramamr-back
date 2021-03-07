using Microsoft.EntityFrameworkCore.Migrations;

namespace Grammar.Data.Migrations
{
    public partial class _2ndMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Types");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "UsersAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "UsersAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAnswers_CategoryId",
                table: "UsersAnswers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAnswers_SubCategoryId",
                table: "UsersAnswers",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAnswers_Categories_CategoryId",
                table: "UsersAnswers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAnswers_SubCategories_SubCategoryId",
                table: "UsersAnswers",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAnswers_Categories_CategoryId",
                table: "UsersAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAnswers_SubCategories_SubCategoryId",
                table: "UsersAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UsersAnswers_CategoryId",
                table: "UsersAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UsersAnswers_SubCategoryId",
                table: "UsersAnswers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "UsersAnswers");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "UsersAnswers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Types",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
