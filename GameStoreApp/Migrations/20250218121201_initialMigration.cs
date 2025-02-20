using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStoreApp.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameEntries",
                columns: new[] { "Id", "Created", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "You play as Arthur Morgan, an outlaw back in the 1800's", "Red Dead Redemption 2" },
                    { 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valheim is a brutal exploration and survival game for 1-10 players set in a procedurally-generated world inspired by Norse mythology", "Valheim" },
                    { 3, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "an action-adventure game played from either a third-person or first-person perspective. Players complete missions—linear scenarios with set objectives", "Grand Theft Auto V" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameEntries");
        }
    }
}
