using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Songs.Solution.Migrations
{
    public partial class InitialWithSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Artist = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Artist", "Name", "Year" },
                values: new object[] { 1, "Queen", "Eye of the Tiger", 1980 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Artist", "Name", "Year" },
                values: new object[] { 2, "Bright Eyes", "First Day of My Life", 1999 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Artist", "Name", "Year" },
                values: new object[] { 3, "Queen", "Bohemian Rhapsody", 1978 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
