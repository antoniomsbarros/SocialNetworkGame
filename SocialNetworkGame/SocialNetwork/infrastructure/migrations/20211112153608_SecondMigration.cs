using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.infrastructure.migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerOrig_Value",
                table: "Relationship",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerOrig_Value",
                table: "Relationship");
        }
    }
}
