using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    /// <inheritdoc />
    public partial class VR08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConsumedAPI",
                table: "UserConsumption",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumedAPI",
                table: "UserConsumption");
        }
    }
}
