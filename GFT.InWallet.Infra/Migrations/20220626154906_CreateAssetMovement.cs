using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFT.InWallet.Infra.Migrations
{
    public partial class CreateAssetMovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetMovement",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Volume = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceAsset = table.Column<decimal>(type: "numeric", nullable: false),
                    Fee = table.Column<decimal>(type: "numeric", nullable: false),
                    Operation = table.Column<char>(type: "character(1)", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Inclusion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetMovement", x => x.Symbol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetMovement");
        }
    }
}
