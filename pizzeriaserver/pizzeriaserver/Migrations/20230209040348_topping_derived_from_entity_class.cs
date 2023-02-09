using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeriaserver.Migrations
{
    /// <inheritdoc />
    public partial class toppingderivedfromentityclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Toppings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "Toppings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "Toppings");
        }
    }
}
