using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeriaserver.Migrations
{
    /// <inheritdoc />
    public partial class addedPizzaLocationstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Pizzas");

            migrationBuilder.CreateTable(
                name: "PizzaLocations",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaLocations", x => new { x.PizzaId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_PizzaLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaLocations_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaLocations_LocationId",
                table: "PizzaLocations",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaLocations");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
