using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Fılmler_Guncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cinsiyet",
                table: "Kullan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoğumTarihi",
                table: "Kullan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FılmUzunlugu",
                table: "Fılmlers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "İzlenmeSayısı",
                table: "Fılmlers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "Kullan");

            migrationBuilder.DropColumn(
                name: "DoğumTarihi",
                table: "Kullan");

            migrationBuilder.DropColumn(
                name: "FılmUzunlugu",
                table: "Fılmlers");

            migrationBuilder.DropColumn(
                name: "İzlenmeSayısı",
                table: "Fılmlers");
        }
    }
}
