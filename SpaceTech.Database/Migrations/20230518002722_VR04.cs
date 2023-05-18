using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    /// <inheritdoc />
    public partial class VR04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "User",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "",
                comment: "Telephone.")
                .Annotation("MySql:CharSet", "utf8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "User");
        }
    }
}
