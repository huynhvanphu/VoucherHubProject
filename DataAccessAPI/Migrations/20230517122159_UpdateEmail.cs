using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessAPI.Migrations
{
    public partial class UpdateEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StoreOwner",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "StoreOwner");
        }
    }
}
