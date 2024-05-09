using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructure.BisleriumBloggingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddViewModelAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total_Dislike",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_Like",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total_Dislike",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Total_Like",
                table: "Comments");
        }
    }
}
