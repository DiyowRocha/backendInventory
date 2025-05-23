using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VinculationFloortoDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Buildings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Buildings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
