using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy_clone.Migrations
{
    /// <inheritdoc />
    public partial class initandseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "Description", "Duration", "Thumbnail", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "Video 1 Description", 100, "https://via.placeholder.com/150", "Video 1", "https://www.youtube.com/embed/1" },
                    { 2, "Video 2 Description", 200, "https://via.placeholder.com/150", "Video 2", "https://www.youtube.com/embed/2" },
                    { 3, "Video 3 Description", 300, "https://via.placeholder.com/150", "Video 3", "https://www.youtube.com/embed/3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
