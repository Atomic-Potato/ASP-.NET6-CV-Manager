using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Schema_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailConfirm",
                table: "CVs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "emailConfirm",
                table: "CVs",
                type: "longtext",
                nullable: false);
        }
    }
}
