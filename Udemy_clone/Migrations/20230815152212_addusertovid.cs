using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy_clone.Migrations
{
    /// <inheritdoc />
    public partial class addusertovid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Videos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "Price" },
                values: new object[] { "993cdd02-003f-4cbd-93e2-b13d6baeaa57", 120 });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 2,
                columns: new[] { "ApplicationUserId", "Price" },
                values: new object[] { "993cdd02-003f-4cbd-93e2-b13d6baeaa57", 250 });

            migrationBuilder.UpdateData(
                table: "Videos",
                keyColumn: "VideoId",
                keyValue: 3,
                columns: new[] { "ApplicationUserId", "Price" },
                values: new object[] { "993cdd02-003f-4cbd-93e2-b13d6baeaa57", 310 });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ApplicationUserId",
                table: "Videos",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_AspNetUsers_ApplicationUserId",
                table: "Videos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_AspNetUsers_ApplicationUserId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_ApplicationUserId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Videos");
        }
    }
}
