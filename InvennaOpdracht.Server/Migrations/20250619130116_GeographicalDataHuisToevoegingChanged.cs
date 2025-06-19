using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvennaOpdracht.Server.Migrations
{
    /// <inheritdoc />
    public partial class GeographicalDataHuisToevoegingChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HuisNummerToevoeging",
                table: "GeographicalDataItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HuisNummerToevoeging",
                table: "GeographicalDataItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
