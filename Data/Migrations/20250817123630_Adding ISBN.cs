using Microsoft.EntityFrameworkCore.Migrations;

namespace BookList3._1.Data.Migrations
{
    public partial class AddingISBN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "books");
        }
    }
}
