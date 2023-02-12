using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeriaserver.Migrations
{
    /// <inheritdoc />
    public partial class removedPricecolumnfromPizzatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
