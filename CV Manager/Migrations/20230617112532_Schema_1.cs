using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Schema_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "birthDay",
                table: "CVs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthDay",
                table: "CVs");
        }
    }
}
