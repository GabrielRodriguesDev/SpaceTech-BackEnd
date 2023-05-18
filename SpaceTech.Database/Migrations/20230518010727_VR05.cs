using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    /// <inheritdoc />
    public partial class VR05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "User",
                type: "varchar(11)",
                nullable: false,
                comment: "Telephone.",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldComment: "Telephone.")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "User",
                type: "varchar(5)",
                nullable: true,
                comment: "VerificationCode.")
                .Annotation("MySql:CharSet", "utf8");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "User",
                type: "varchar(10)",
                nullable: false,
                comment: "Telephone.",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldComment: "Telephone.")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8");
        }
    }
}
