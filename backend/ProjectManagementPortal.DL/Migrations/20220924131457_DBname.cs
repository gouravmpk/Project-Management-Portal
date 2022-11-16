using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementPortal.DL.Migrations
{
    public partial class DBname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);    

            migrationBuilder.AddColumn<string>(
                name: "GoalOfProject",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnologiesUsed",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GoalOfProject",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TechnologiesUsed",
                table: "Projects");
        }
    }
}
