using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESISA.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class mig_fix_corporate_advert_discount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountedUnitPrice",
                table: "CorporateAdverts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountedUnitPrice",
                table: "CorporateAdverts",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
