using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeriaserver.Migrations
{
    /// <inheritdoc />
    public partial class usingentitiesinsteadofmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaDtoId",
                table: "Toppings");

            migrationBuilder.RenameColumn(
                name: "PizzaDtoId",
                table: "Toppings",
                newName: "PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_PizzaDtoId",
                table: "Toppings",
                newName: "IX_Toppings_PizzaId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Pizzas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Pizzas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_PizzaId",
                table: "Toppings",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaId",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "Toppings",
                newName: "PizzaDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_PizzaId",
                table: "Toppings",
                newName: "IX_Toppings_PizzaDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_PizzaDtoId",
                table: "Toppings",
                column: "PizzaDtoId",
                principalTable: "Pizzas",
                principalColumn: "Id");
        }
    }
}
