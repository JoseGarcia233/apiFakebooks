using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeRestApiB.Migrations
{
    /// <inheritdoc />
    public partial class pictureBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coverPicture",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coverPicture",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
