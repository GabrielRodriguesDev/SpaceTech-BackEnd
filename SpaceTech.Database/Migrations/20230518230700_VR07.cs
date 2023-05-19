using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    /// <inheritdoc />
    public partial class VR07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserConsumption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Record identifier.", collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "User identifier.", collation: "ascii_general_ci"),
                    Url = table.Column<string>(type: "varchar(500)", nullable: false, comment: "Url consumed by API.")
                        .Annotation("MySql:CharSet", "utf8"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Record creation date and time."),
                    ChangedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Date and time of last record change.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConsumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConsumption_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "IX_UserConsumption_UserId",
                table: "UserConsumption",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserConsumption");
        }
    }
}
