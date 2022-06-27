using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFT.InWallet.Infra.Migrations
{
    public partial class AlterItensAssetManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetMovement",
                table: "AssetMovement");

            migrationBuilder.RenameColumn(
                name: "Operation",
                table: "AssetMovement",
                newName: "OperationType");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "AssetMovement",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "AssetMovement",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "PriceAsset",
                table: "AssetMovement",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "Fee",
                table: "AssetMovement",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "AssetMovement",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "OperationDate",
                table: "AssetMovement",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationDate",
                table: "AssetMovement");

            migrationBuilder.RenameColumn(
                name: "OperationType",
                table: "AssetMovement",
                newName: "Operation");

            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "AssetMovement",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "AssetMovement",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "AssetMovement",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceAsset",
                table: "AssetMovement",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fee",
                table: "AssetMovement",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetMovement",
                table: "AssetMovement",
                column: "Symbol");
        }
    }
}
