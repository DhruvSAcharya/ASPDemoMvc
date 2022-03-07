using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPDemoMvc.Migrations
{
    public partial class M0_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "serviceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userid",
                table: "serviceRequests");
        }
    }
}
