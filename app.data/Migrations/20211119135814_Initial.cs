using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace app.data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Body",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Body", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MansCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    GendersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MansCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MansCategories_Genders_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WomansCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    GendersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WomansCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WomansCategories_Genders_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MansBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    MansCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    GendersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MansBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MansBrands_Genders_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MansBrands_MansCategories_MansCategoryId",
                        column: x => x.MansCategoryId,
                        principalTable: "MansCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WomansBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    WomansCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    GendersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WomansBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WomansBrands_Genders_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WomansBrands_WomansCategories_WomansCategoryId",
                        column: x => x.WomansCategoryId,
                        principalTable: "WomansCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    MansCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    MansBrandsId = table.Column<int>(type: "INTEGER", nullable: false),
                    GendersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManProducts_Genders_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManProducts_MansBrands_MansBrandsId",
                        column: x => x.MansBrandsId,
                        principalTable: "MansBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManProducts_MansCategories_MansCategoryId",
                        column: x => x.MansCategoryId,
                        principalTable: "MansCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WomanProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    WomansCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    WomansBrandsId = table.Column<int>(type: "INTEGER", nullable: false),
                    GendersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WomanProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WomanProducts_Genders_GendersId",
                        column: x => x.GendersId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WomanProducts_WomansBrands_WomansBrandsId",
                        column: x => x.WomansBrandsId,
                        principalTable: "WomansBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WomanProducts_WomansCategories_WomansCategoryId",
                        column: x => x.WomansCategoryId,
                        principalTable: "WomansCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ManProducts_ManProductId",
                        column: x => x.ManProductId,
                        principalTable: "ManProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManProductBodies",
                columns: table => new
                {
                    ManProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    BodyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManProductBodies", x => new { x.ManProductId, x.BodyId });
                    table.ForeignKey(
                        name: "FK_ManProductBodies_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManProductBodies_ManProducts_ManProductId",
                        column: x => x.ManProductId,
                        principalTable: "ManProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Post = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Like = table.Column<int>(type: "INTEGER", nullable: false),
                    WomanProductId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_ManProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ManProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_WomanProducts_WomanProductId",
                        column: x => x.WomanProductId,
                        principalTable: "WomanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WomanProductBodies",
                columns: table => new
                {
                    BodyId = table.Column<int>(type: "INTEGER", nullable: false),
                    WomanProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WomanProductBodies", x => new { x.WomanProductId, x.BodyId });
                    table.ForeignKey(
                        name: "FK_WomanProductBodies_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WomanProductBodies_WomanProducts_WomanProductId",
                        column: x => x.WomanProductId,
                        principalTable: "WomanProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ManProductId",
                table: "CartItems",
                column: "ManProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_WomanProductId",
                table: "Comment",
                column: "WomanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ManProductBodies_BodyId",
                table: "ManProductBodies",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_ManProducts_GendersId",
                table: "ManProducts",
                column: "GendersId");

            migrationBuilder.CreateIndex(
                name: "IX_ManProducts_MansBrandsId",
                table: "ManProducts",
                column: "MansBrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_ManProducts_MansCategoryId",
                table: "ManProducts",
                column: "MansCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MansBrands_GendersId",
                table: "MansBrands",
                column: "GendersId");

            migrationBuilder.CreateIndex(
                name: "IX_MansBrands_MansCategoryId",
                table: "MansBrands",
                column: "MansCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MansCategories_GendersId",
                table: "MansCategories",
                column: "GendersId");

            migrationBuilder.CreateIndex(
                name: "IX_WomanProductBodies_BodyId",
                table: "WomanProductBodies",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_WomanProducts_GendersId",
                table: "WomanProducts",
                column: "GendersId");

            migrationBuilder.CreateIndex(
                name: "IX_WomanProducts_WomansBrandsId",
                table: "WomanProducts",
                column: "WomansBrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_WomanProducts_WomansCategoryId",
                table: "WomanProducts",
                column: "WomansCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WomansBrands_GendersId",
                table: "WomansBrands",
                column: "GendersId");

            migrationBuilder.CreateIndex(
                name: "IX_WomansBrands_WomansCategoryId",
                table: "WomansBrands",
                column: "WomansCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WomansCategories_GendersId",
                table: "WomansCategories",
                column: "GendersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ManProductBodies");

            migrationBuilder.DropTable(
                name: "WomanProductBodies");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ManProducts");

            migrationBuilder.DropTable(
                name: "Body");

            migrationBuilder.DropTable(
                name: "WomanProducts");

            migrationBuilder.DropTable(
                name: "MansBrands");

            migrationBuilder.DropTable(
                name: "WomansBrands");

            migrationBuilder.DropTable(
                name: "MansCategories");

            migrationBuilder.DropTable(
                name: "WomansCategories");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
