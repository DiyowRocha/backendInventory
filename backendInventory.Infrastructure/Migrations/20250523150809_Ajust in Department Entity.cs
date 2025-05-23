using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustinDepartmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Departments",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Departments");
        }
    }
}
