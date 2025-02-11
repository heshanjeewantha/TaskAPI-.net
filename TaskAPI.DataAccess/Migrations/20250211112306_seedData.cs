using Microsoft.EntityFrameworkCore.Migrations;
using TaskAPI.Models;

#nullable disable

namespace TaskAPI.DataAccess.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed data into the Todos table
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Title", "Description", "Created", "Due", "Status" },
                values: new object[]
                {
                    1, // Id
                    "First Todo", // Title
                    "This is the first todo", // Description
                    DateTime.Now, // Created
                    DateTime.Now.AddDays(1), // Due
                    (int)TodoStatus.New // Status
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the seeded data
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1
            );
        }
    }
}