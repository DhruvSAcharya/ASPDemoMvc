using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPDemoMvc.Migrations
{
    public partial class M0_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "serviceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enquiryPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceRequests");
        }
    }
}
