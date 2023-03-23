using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESISA.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class mig_fix_demand_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "ProductDemands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemands_CategoryId",
                table: "ProductDemands",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDemands_Categories_CategoryId",
                table: "ProductDemands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDemands_Categories_CategoryId",
                table: "ProductDemands");

            migrationBuilder.DropIndex(
                name: "IX_ProductDemands_CategoryId",
                table: "ProductDemands");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductDemands");
        }
    }
}
