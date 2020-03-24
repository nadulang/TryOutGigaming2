using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PaymentService.Migrations
{
    public partial class AddPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALlProducts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    created_at = table.Column<long>(nullable: false),
                    updated_at = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALlProducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AllUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ALOrders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(nullable: false),
                    created_at = table.Column<long>(nullable: false),
                    updated_at = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_ALOrders_AllUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AllUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllOrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_id = table.Column<int>(nullable: false),
                    order_id = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    created_at = table.Column<long>(nullable: false),
                    updated_at = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllOrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_AllOrderDetails_ALOrders_order_id",
                        column: x => x.order_id,
                        principalTable: "ALOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllOrderDetails_ALlProducts_product_id",
                        column: x => x.product_id,
                        principalTable: "ALlProducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllPayments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(nullable: false),
                    transaction_id = table.Column<int>(nullable: false),
                    payment_type = table.Column<string>(nullable: true),
                    gross_amount = table.Column<int>(nullable: false),
                    bank = table.Column<string>(nullable: true),
                    transaction_time = table.Column<DateTime>(nullable: false),
                    transaction_status = table.Column<string>(nullable: true),
                    created_at = table.Column<long>(nullable: false),
                    updated_at = table.Column<long>(nullable: false),
                    ordersid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllPayments", x => x.id);
                    table.ForeignKey(
                        name: "FK_AllPayments_ALOrders_ordersid",
                        column: x => x.ordersid,
                        principalTable: "ALOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllOrderDetails_order_id",
                table: "AllOrderDetails",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_AllOrderDetails_product_id",
                table: "AllOrderDetails",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_AllPayments_ordersid",
                table: "AllPayments",
                column: "ordersid");

            migrationBuilder.CreateIndex(
                name: "IX_ALOrders_user_id",
                table: "ALOrders",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllOrderDetails");

            migrationBuilder.DropTable(
                name: "AllPayments");

            migrationBuilder.DropTable(
                name: "ALlProducts");

            migrationBuilder.DropTable(
                name: "ALOrders");

            migrationBuilder.DropTable(
                name: "AllUsers");
        }
    }
}
