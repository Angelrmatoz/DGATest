using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGAPrueba.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixColumna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SaleProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SaleProduct");
        }
    }
}
