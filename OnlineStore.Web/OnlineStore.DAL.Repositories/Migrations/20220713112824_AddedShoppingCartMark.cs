using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.DAL.Repositories.Migrations
{
    public partial class AddedShoppingCartMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartMark",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCartMark",
                table: "ShoppingCarts");
        }
    }
}
