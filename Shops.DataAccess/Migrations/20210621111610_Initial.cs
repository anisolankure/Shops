using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shops.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ExpiryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shakti" },
                    { 2, "Falcon" },
                    { 3, "AsianStore" },
                    { 4, "Popat" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ExpiryDateTime", "Name", "ShopId", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Methi", 1, "Bhaji" },
                    { 4, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Idli", 1, "ReadyToEat" },
                    { 3, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "ParleG", 2, "Biscuits" },
                    { 2, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "Kulfi", 4, "IceCream" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopId",
                table: "Items",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
