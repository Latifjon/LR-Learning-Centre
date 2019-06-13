using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningCentre.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hometown",
                table: "Student",
                newName: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CountryId",
                table: "Student",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Country_CountryId",
                table: "Student",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Country_CountryId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CountryId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Student",
                newName: "Hometown");
        }
    }
}
