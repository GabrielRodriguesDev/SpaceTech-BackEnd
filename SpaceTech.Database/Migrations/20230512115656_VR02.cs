using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceTech.Database.Migrations
{
    /// <inheritdoc />
    public partial class VR02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `User` (`Id`, `Name`, `Surname`, `Email`, `Password`, `CreatedAt`, `ChangedAt`, `Telephone`) VALUES (UUID(), 'Administrator', 'System Administrator', 'system@spacetech.com.br', '$2a$11$GFIt4t0wvmnaSKZcE1P7XOZ99ljCs61xMZ9zlrCJ1Z1LJGaA4jrHO', NOW(), NULL, `11963767021`);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
