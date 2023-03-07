using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESISA.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class mig_demand_entities_creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandDemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderNote = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandDemands_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderNote = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDemands_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderNote = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDemands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDemands_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandDemands_CorporateDealerId",
                table: "BrandDemands",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDemands_CorporateDealerId",
                table: "CategoryDemands",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemands_CorporateDealerId",
                table: "ProductDemands",
                column: "CorporateDealerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandDemands");

            migrationBuilder.DropTable(
                name: "CategoryDemands");

            migrationBuilder.DropTable(
                name: "ProductDemands");
        }
    }
}
