using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    /// <inheritdoc />
    public partial class VR06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationCodeExpiration",
                table: "User",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCodeExpiration",
                table: "User");
        }
    }
}
