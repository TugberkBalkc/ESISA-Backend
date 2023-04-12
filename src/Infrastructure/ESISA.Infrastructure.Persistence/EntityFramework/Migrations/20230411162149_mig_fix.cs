using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESISA.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class mig_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseQuantityDiscounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimumBuyingQuantity = table.Column<int>(type: "int", nullable: false),
                    MaximumBuyingQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCombinable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseQuantityDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpperOrderPriceDiscounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimumOrderPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsCombinable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpperOrderPriceDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertPhotoPaths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertPhotoPaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertPhotoPaths_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BrandPhotoPaths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandPhotoPaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandPhotoPaths_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPhotoPaths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPhotoPaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryPhotoPaths_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOperationClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpperOrderPriceDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    DiscountedTotalPrice = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UpperOrderPriceDiscounts_UpperOrderPriceDiscountId",
                        column: x => x.UpperOrderPriceDiscountId,
                        principalTable: "UpperOrderPriceDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dealers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshTokenCode = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    RefreshTokenExpiration = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnedOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnReasonType = table.Column<int>(type: "int", nullable: false),
                    ReasonDescripton = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnedOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    TaxIdentityNumber = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CompanyType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    NationalIdentity = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualDealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualDealers_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualAdverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Bargain = table.Column<bool>(type: "bit", nullable: false),
                    ProductConditionType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualAdverts_IndividualDealers_IndividualDealerId",
                        column: x => x.IndividualDealerId,
                        principalTable: "IndividualDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualAdverts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerIndividualDealerComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerIndividualDealerComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerIndividualDealerComments_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerIndividualDealerComments_IndividualDealers_IndividualDealerId",
                        column: x => x.IndividualDealerId,
                        principalTable: "IndividualDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerIndividualDealerVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerIndividualDealerVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerIndividualDealerVotes_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerIndividualDealerVotes_IndividualDealers_IndividualDealerId",
                        column: x => x.IndividualDealerId,
                        principalTable: "IndividualDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SwapAdverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductConditionType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwapAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwapAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SwapAdverts_IndividualDealers_IndividualDealerId",
                        column: x => x.IndividualDealerId,
                        principalTable: "IndividualDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SwapAdverts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCenterCompany = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerAddresses_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateDealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    TaxIdentityNumber = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CompanyType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateDealers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateDealers_Categories_SalesCategoryId",
                        column: x => x.SalesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateDealers_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsResidence = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerAddresses_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerIndividualAdvertFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerIndividualAdvertFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerIndividualAdvertFavorites_IndividualAdverts_IndividualAdvertId",
                        column: x => x.IndividualAdvertId,
                        principalTable: "IndividualAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerIndividualAdvertFavorites_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwapAdvertSwapableCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SwapAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwapAdvertSwapableCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwapAdvertSwapableCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SwapAdvertSwapableCategories_SwapAdverts_SwapAdvertId",
                        column: x => x.SwapAdvertId,
                        principalTable: "SwapAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwapAdvertSwapableProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SwapAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwapAdvertSwapableProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwapAdvertSwapableProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SwapAdvertSwapableProducts_SwapAdverts_SwapAdvertId",
                        column: x => x.SwapAdvertId,
                        principalTable: "SwapAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "CorporateAdverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseQuantityDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockAmount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedUnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateAdverts_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateAdverts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateAdverts_PurchaseQuantityDiscounts_PurchaseQuantityDiscountId",
                        column: x => x.PurchaseQuantityDiscountId,
                        principalTable: "PurchaseQuantityDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomerCorporateDealerComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomerCorporateDealerComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerCorporateDealerComments_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerCorporateDealerComments_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomerWholesaleAdvertOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedTotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomerWholesaleAdvertOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertOrders_CorporateCustomerAddresses_CorporateCustomerAddressId",
                        column: x => x.CorporateCustomerAddressId,
                        principalTable: "CorporateCustomerAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertOrders_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertOrders_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_ProductDemands_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDemands_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WholesaleAdverts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseQuantityDiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimumPurchaseAmount = table.Column<int>(type: "int", nullable: false),
                    MaximumPurchaseAmount = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedPricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesaleAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WholesaleAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WholesaleAdverts_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WholesaleAdverts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WholesaleAdverts_PurchaseQuantityDiscounts_PurchaseQuantityDiscountId",
                        column: x => x.PurchaseQuantityDiscountId,
                        principalTable: "PurchaseQuantityDiscounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerCorporateAdvertOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateDealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedTotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerCorporateAdvertOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertOrders_CorporateDealers_CorporateDealerId",
                        column: x => x.CorporateDealerId,
                        principalTable: "CorporateDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertOrders_IndividualCustomerAddresses_IndividualCustomerAddressId",
                        column: x => x.IndividualCustomerAddressId,
                        principalTable: "IndividualCustomerAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertOrders_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerCorporateAdvertComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerCorporateAdvertComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertComments_CorporateAdverts_CorporateAdvertId",
                        column: x => x.CorporateAdvertId,
                        principalTable: "CorporateAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertComments_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerCorporateAdvertFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerCorporateAdvertFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertFavorites_CorporateAdverts_CorporateAdvertId",
                        column: x => x.CorporateAdvertId,
                        principalTable: "CorporateAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertFavorites_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomerCorporateAdvertVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomerCorporateAdvertVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertVotes_CorporateAdverts_CorporateAdvertId",
                        column: x => x.CorporateAdvertId,
                        principalTable: "CorporateAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualCustomerCorporateAdvertVotes_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomerWholesaleAdvertComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WholesaleAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomerWholesaleAdvertComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertComments_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertComments_WholesaleAdverts_WholesaleAdvertId",
                        column: x => x.WholesaleAdvertId,
                        principalTable: "WholesaleAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomerWholesaleAdvertFavorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WholesaleAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomerWholesaleAdvertFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertFavorites_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertFavorites_WholesaleAdverts_WholesaleAdvertId",
                        column: x => x.WholesaleAdvertId,
                        principalTable: "WholesaleAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateCustomerWholesaleAdvertVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WholesaleAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomerWholesaleAdvertVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertVotes_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateCustomerWholesaleAdvertVotes_WholesaleAdverts_WholesaleAdvertId",
                        column: x => x.WholesaleAdvertId,
                        principalTable: "WholesaleAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WholesaleAdvertOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WholesaleAdvertOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WholesaleAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false),
                    ProductUnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedProductUnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WholesaleAdvertOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WholesaleAdvertOrderItems_CorporateCustomerWholesaleAdvertOrders_WholesaleAdvertOrderId",
                        column: x => x.WholesaleAdvertOrderId,
                        principalTable: "CorporateCustomerWholesaleAdvertOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WholesaleAdvertOrderItems_WholesaleAdverts_WholesaleAdvertId",
                        column: x => x.WholesaleAdvertId,
                        principalTable: "WholesaleAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorporateAdvertOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateAdvertOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false),
                    ProductUnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountedProductUnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateAdvertOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateAdvertOrderItems_CorporateAdverts_CorporateAdvertId",
                        column: x => x.CorporateAdvertId,
                        principalTable: "CorporateAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorporateAdvertOrderItems_IndividualCustomerCorporateAdvertOrders_CorporateAdvertOrderId",
                        column: x => x.CorporateAdvertOrderId,
                        principalTable: "IndividualCustomerCorporateAdvertOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertPhotoPaths_AdvertId",
                table: "AdvertPhotoPaths",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandDemands_CorporateDealerId",
                table: "BrandDemands",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandPhotoPaths_BrandId",
                table: "BrandPhotoPaths",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDemands_CorporateDealerId",
                table: "CategoryDemands",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPhotoPaths_CategoryId",
                table: "CategoryPhotoPaths",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedOrders_OrderId",
                table: "CompletedOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAdvertOrderItems_CorporateAdvertId",
                table: "CorporateAdvertOrderItems",
                column: "CorporateAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAdvertOrderItems_CorporateAdvertOrderId",
                table: "CorporateAdvertOrderItems",
                column: "CorporateAdvertOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAdverts_AdvertId",
                table: "CorporateAdverts",
                column: "AdvertId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAdverts_CorporateDealerId",
                table: "CorporateAdverts",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAdverts_ProductId",
                table: "CorporateAdverts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAdverts_PurchaseQuantityDiscountId",
                table: "CorporateAdverts",
                column: "PurchaseQuantityDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerAddresses_AddressId",
                table: "CorporateCustomerAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerAddresses_CorporateCustomerId",
                table: "CorporateCustomerAddresses",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerCorporateDealerComments_CorporateCustomerId",
                table: "CorporateCustomerCorporateDealerComments",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerCorporateDealerComments_CorporateDealerId",
                table: "CorporateCustomerCorporateDealerComments",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertComments_CorporateCustomerId",
                table: "CorporateCustomerWholesaleAdvertComments",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertComments_WholesaleAdvertId",
                table: "CorporateCustomerWholesaleAdvertComments",
                column: "WholesaleAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertFavorites_CorporateCustomerId",
                table: "CorporateCustomerWholesaleAdvertFavorites",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertFavorites_WholesaleAdvertId",
                table: "CorporateCustomerWholesaleAdvertFavorites",
                column: "WholesaleAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertOrders_CorporateCustomerAddressId",
                table: "CorporateCustomerWholesaleAdvertOrders",
                column: "CorporateCustomerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertOrders_CorporateCustomerId",
                table: "CorporateCustomerWholesaleAdvertOrders",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertOrders_CorporateDealerId",
                table: "CorporateCustomerWholesaleAdvertOrders",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertOrders_OrderId",
                table: "CorporateCustomerWholesaleAdvertOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertVotes_CorporateCustomerId",
                table: "CorporateCustomerWholesaleAdvertVotes",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomerWholesaleAdvertVotes_WholesaleAdvertId",
                table: "CorporateCustomerWholesaleAdvertVotes",
                column: "WholesaleAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateDealers_AddressId",
                table: "CorporateDealers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateDealers_DealerId",
                table: "CorporateDealers",
                column: "DealerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateDealers_SalesCategoryId",
                table: "CorporateDealers",
                column: "SalesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_UserId",
                table: "Dealers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualAdverts_AdvertId",
                table: "IndividualAdverts",
                column: "AdvertId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualAdverts_IndividualDealerId",
                table: "IndividualAdverts",
                column: "IndividualDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualAdverts_ProductId",
                table: "IndividualAdverts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerAddresses_AddressId",
                table: "IndividualCustomerAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerAddresses_IndividualCustomerId",
                table: "IndividualCustomerAddresses",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertComments_CorporateAdvertId",
                table: "IndividualCustomerCorporateAdvertComments",
                column: "CorporateAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertComments_IndividualCustomerId",
                table: "IndividualCustomerCorporateAdvertComments",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertFavorites_CorporateAdvertId",
                table: "IndividualCustomerCorporateAdvertFavorites",
                column: "CorporateAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertFavorites_IndividualCustomerId",
                table: "IndividualCustomerCorporateAdvertFavorites",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertOrders_CorporateDealerId",
                table: "IndividualCustomerCorporateAdvertOrders",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertOrders_IndividualCustomerAddressId",
                table: "IndividualCustomerCorporateAdvertOrders",
                column: "IndividualCustomerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertOrders_IndividualCustomerId",
                table: "IndividualCustomerCorporateAdvertOrders",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertOrders_OrderId",
                table: "IndividualCustomerCorporateAdvertOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertVotes_CorporateAdvertId",
                table: "IndividualCustomerCorporateAdvertVotes",
                column: "CorporateAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerCorporateAdvertVotes_IndividualCustomerId",
                table: "IndividualCustomerCorporateAdvertVotes",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerIndividualAdvertFavorites_IndividualAdvertId",
                table: "IndividualCustomerIndividualAdvertFavorites",
                column: "IndividualAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerIndividualAdvertFavorites_IndividualCustomerId",
                table: "IndividualCustomerIndividualAdvertFavorites",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerIndividualDealerComments_IndividualCustomerId",
                table: "IndividualCustomerIndividualDealerComments",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerIndividualDealerComments_IndividualDealerId",
                table: "IndividualCustomerIndividualDealerComments",
                column: "IndividualDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerIndividualDealerVotes_IndividualCustomerId",
                table: "IndividualCustomerIndividualDealerVotes",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomerIndividualDealerVotes_IndividualDealerId",
                table: "IndividualCustomerIndividualDealerVotes",
                column: "IndividualDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDealers_DealerId",
                table: "IndividualDealers",
                column: "DealerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpperOrderPriceDiscountId",
                table: "Orders",
                column: "UpperOrderPriceDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemands_CategoryId",
                table: "ProductDemands",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDemands_CorporateDealerId",
                table: "ProductDemands",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnedOrders_OrderId",
                table: "ReturnedOrders",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperationClaims_OperationClaimId",
                table: "RoleOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperationClaims_RoleId",
                table: "RoleOperationClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdverts_AdvertId",
                table: "SwapAdverts",
                column: "AdvertId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdverts_IndividualDealerId",
                table: "SwapAdverts",
                column: "IndividualDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdverts_ProductId",
                table: "SwapAdverts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdvertSwapableCategories_CategoryId",
                table: "SwapAdvertSwapableCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdvertSwapableCategories_SwapAdvertId",
                table: "SwapAdvertSwapableCategories",
                column: "SwapAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdvertSwapableProducts_ProductId",
                table: "SwapAdvertSwapableProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapAdvertSwapableProducts_SwapAdvertId",
                table: "SwapAdvertSwapableProducts",
                column: "SwapAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleAdvertOrderItems_WholesaleAdvertId",
                table: "WholesaleAdvertOrderItems",
                column: "WholesaleAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleAdvertOrderItems_WholesaleAdvertOrderId",
                table: "WholesaleAdvertOrderItems",
                column: "WholesaleAdvertOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleAdverts_AdvertId",
                table: "WholesaleAdverts",
                column: "AdvertId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleAdverts_CorporateDealerId",
                table: "WholesaleAdverts",
                column: "CorporateDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleAdverts_ProductId",
                table: "WholesaleAdverts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WholesaleAdverts_PurchaseQuantityDiscountId",
                table: "WholesaleAdverts",
                column: "PurchaseQuantityDiscountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertPhotoPaths");

            migrationBuilder.DropTable(
                name: "BrandDemands");

            migrationBuilder.DropTable(
                name: "BrandPhotoPaths");

            migrationBuilder.DropTable(
                name: "CategoryDemands");

            migrationBuilder.DropTable(
                name: "CategoryPhotoPaths");

            migrationBuilder.DropTable(
                name: "CompletedOrders");

            migrationBuilder.DropTable(
                name: "CorporateAdvertOrderItems");

            migrationBuilder.DropTable(
                name: "CorporateCustomerCorporateDealerComments");

            migrationBuilder.DropTable(
                name: "CorporateCustomerWholesaleAdvertComments");

            migrationBuilder.DropTable(
                name: "CorporateCustomerWholesaleAdvertFavorites");

            migrationBuilder.DropTable(
                name: "CorporateCustomerWholesaleAdvertVotes");

            migrationBuilder.DropTable(
                name: "IndividualCustomerCorporateAdvertComments");

            migrationBuilder.DropTable(
                name: "IndividualCustomerCorporateAdvertFavorites");

            migrationBuilder.DropTable(
                name: "IndividualCustomerCorporateAdvertVotes");

            migrationBuilder.DropTable(
                name: "IndividualCustomerIndividualAdvertFavorites");

            migrationBuilder.DropTable(
                name: "IndividualCustomerIndividualDealerComments");

            migrationBuilder.DropTable(
                name: "IndividualCustomerIndividualDealerVotes");

            migrationBuilder.DropTable(
                name: "ProductDemands");

            migrationBuilder.DropTable(
                name: "ReturnedOrders");

            migrationBuilder.DropTable(
                name: "RoleOperationClaims");

            migrationBuilder.DropTable(
                name: "SwapAdvertSwapableCategories");

            migrationBuilder.DropTable(
                name: "SwapAdvertSwapableProducts");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WholesaleAdvertOrderItems");

            migrationBuilder.DropTable(
                name: "IndividualCustomerCorporateAdvertOrders");

            migrationBuilder.DropTable(
                name: "CorporateAdverts");

            migrationBuilder.DropTable(
                name: "IndividualAdverts");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "SwapAdverts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CorporateCustomerWholesaleAdvertOrders");

            migrationBuilder.DropTable(
                name: "WholesaleAdverts");

            migrationBuilder.DropTable(
                name: "IndividualCustomerAddresses");

            migrationBuilder.DropTable(
                name: "IndividualDealers");

            migrationBuilder.DropTable(
                name: "CorporateCustomerAddresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "CorporateDealers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseQuantityDiscounts");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");

            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "UpperOrderPriceDiscounts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
