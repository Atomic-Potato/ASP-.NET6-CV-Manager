using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace CV_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Schema_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    cvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "longtext", nullable: false),
                    lastName = table.Column<string>(type: "longtext", nullable: false),
                    nationality = table.Column<string>(type: "longtext", nullable: false),
                    gender = table.Column<string>(type: "longtext", nullable: false),
                    java = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cs = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    python = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.cvId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVs");
        }
    }
}
