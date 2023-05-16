using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karmaplusplus.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Volunteerings",
                columns: table => new
                {
                    VolunteeringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VolunteeringName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteerings", x => x.VolunteeringId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Volunteerings",
                columns: new[] { "VolunteeringId", "Date", "Description", "Email", "Location", "Time", "UserId", "VolunteeringName", "ZipCode" },
                values: new object[] { 1, "06/01/2023", "Alki beach cleanup, no tools necessary, dress accordingly", "clean.beaches@gmail.com", "Alki Beach", "10:00 AM - 2 PM", "f9eb9311-a088-4b39-8c27-d92990b37433", "Beach clean up", "98116" });

            migrationBuilder.InsertData(
                table: "Volunteerings",
                columns: new[] { "VolunteeringId", "Date", "Description", "Email", "Location", "Time", "UserId", "VolunteeringName", "ZipCode" },
                values: new object[] { 2, "every Saturday", "Need help with cooking and distributing free hot meals", "free.meals@gmail.com", "9050 16th Avenue SW, Seattle", "11 AM - 3 PM", "f9eb9311-a088-4b39-8c27-d92990b37433", "Free hot meals", "98106" });

            migrationBuilder.InsertData(
                table: "Volunteerings",
                columns: new[] { "VolunteeringId", "Date", "Description", "Email", "Location", "Time", "UserId", "VolunteeringName", "ZipCode" },
                values: new object[] { 3, "every Wednesday and Friday", "Need English language teachers to organize classes for recent immigrants from the Ukraine", "free.english@gmail.com", "Lucky Pen, Redmond", "11 AM - 12:30 PM", "f9eb9311-a088-4b39-8c27-d92990b37433", "English lessons", "98052" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteerings");
        }
    }
}
