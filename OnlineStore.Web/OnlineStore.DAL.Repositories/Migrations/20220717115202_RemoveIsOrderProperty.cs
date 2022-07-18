using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.DAL.Repositories.Migrations
{
    public partial class RemoveIsOrderProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isOrder",
                table: "ShoppingCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isOrder",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
