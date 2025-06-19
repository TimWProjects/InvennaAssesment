using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvennaOpdracht.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeographicalDataItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpenbareRuimte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Huisnummer = table.Column<int>(type: "int", nullable: false),
                    HuisLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HuisNummerToevoeging = table.Column<int>(type: "int", nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NummerAanduiding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerblijfsobjectGebruiksdoel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OppervlakteVerblijfsobject = table.Column<int>(type: "int", nullable: false),
                    VerblijfsobjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Object_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Object_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NevenAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PandId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PandStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PandBouwjaar = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalDataItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeographicalDataItems");
        }
    }
}
