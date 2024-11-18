using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp5.Migrations
{
    /// <inheritdoc />
    public partial class CreatedbasketsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketsproducts_baskets_BasketsId",
                table: "basketsproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_baskets",
                table: "baskets");

            migrationBuilder.RenameTable(
                name: "baskets",
                newName: "Baskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_basketsproducts_Baskets_BasketsId",
                table: "basketsproducts",
                column: "BasketsId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basketsproducts_Baskets_BasketsId",
                table: "basketsproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "baskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_baskets",
                table: "baskets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_basketsproducts_baskets_BasketsId",
                table: "basketsproducts",
                column: "BasketsId",
                principalTable: "baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
