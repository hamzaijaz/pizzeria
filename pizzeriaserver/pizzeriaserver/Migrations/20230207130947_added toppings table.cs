using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeriaserver.Migrations
{
    /// <inheritdoc />
    public partial class addedtoppingstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_PizzaDtoId",
                        column: x => x.PizzaDtoId,
                        principalTable: "Pizzas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaDtoId",
                table: "Toppings",
                column: "PizzaDtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
