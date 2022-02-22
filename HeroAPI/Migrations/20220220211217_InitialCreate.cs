using HeroAPI.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SuperHeroes",
                columns: new[] { "Id", "Name", "FirstName", "LastName", "Place" },
                values: new object[,] 
                { 
                    { 1, "Batman", "Bruce", "Wayne", "Gotham City" },  
                    { 2, "Spider-Man", "Peter", "Parker", "New York City" },
                    { 3, "Aquaman", "Arthur", "Curry", "Atlantis" },
                    { 4, "Captain America", "Stephen", "Rogers", "USA" },
                    { 5, "Wonder Woman", "Diana", "Prince", "Themyscira" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroes");
        }
    }
}
