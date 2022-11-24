using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPI.Demo.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Group", "Name" },
                values: new object[,]
                {
                    { 1, "A", "Qatar" },
                    { 2, "A", "Ecuador" },
                    { 3, "A", "Netherlands" },
                    { 4, "A", "Senegal" },
                    { 5, "B", "England" },
                    { 6, "B", "USA" },
                    { 7, "B", "Wales" },
                    { 8, "B", "Iran" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
