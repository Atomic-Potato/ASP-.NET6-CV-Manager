using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Schema_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "CVs",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo",
                table: "CVs");
        }
    }
}
