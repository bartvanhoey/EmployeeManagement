using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class photopath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPat",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SomeProperty",
                table: "Employees",
                newName: "PhotoPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Employees",
                newName: "SomeProperty");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPat",
                table: "Employees",
                nullable: true);
        }
    }
}
