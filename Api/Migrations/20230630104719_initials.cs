using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Company = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Project = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Company", "Name", "Project", "Role" },
                values: new object[,]
                {
                    { 1, "IBM", "Ankur", "Payroll", "Software Engineer" },
                    { 2, "IBM", "Akash", "Chat Bot", "Software Engineer" },
                    { 3, "HP", "Priya", "VR Gaming", "Project Manager" },
                    { 4, "Microsoft", "Asha", "Payroll", "Solution Architect" },
                    { 5, "HP", "Nandini", "Payroll", "Software Engineer" },
                    { 6, "Microsoft", "Piyush", "Payroll", "Delivery Manager" },
                    { 7, "HP", "Ankur", "Chat Bot", "Lead Engineer" },
                    { 8, "HP", "Akash", "VR Gaming", "Software Engineer" },
                    { 9, "IBM", "Priya", "Payroll", "Solution Architect" },
                    { 10, "HP", "Asha", "Chat Bot", "Project Manager" },
                    { 11, "HP", "Nandini", "VR Gaming", "Lead Engineer" },
                    { 12, "Microsoft", "Piyush", "Chat Bot", "Delivery Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
