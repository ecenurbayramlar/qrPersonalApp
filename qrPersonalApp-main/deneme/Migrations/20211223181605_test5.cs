using Microsoft.EntityFrameworkCore.Migrations;

namespace deneme.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "perId",
                table: "qrs");

            migrationBuilder.AddColumn<string>(
                name: "perTc",
                table: "qrs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "perTc",
                table: "qrs");

            migrationBuilder.AddColumn<int>(
                name: "perId",
                table: "qrs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
