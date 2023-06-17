using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Schema_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "CVs",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "emailConfirm",
                table: "CVs",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "emailConfirm",
                table: "CVs");
        }
    }
}
