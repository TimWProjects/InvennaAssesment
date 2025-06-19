using System.ComponentModel.DataAnnotations;

namespace InvennaOpdracht.Server.Data.Models;

public class GeographicalDataItem
{
    // huisletter, huisnummer toevoeging, pandid, pandstatus, pandbouwjaar kunnen leeg zijn dus nullable
    [Key]
    public int Id { get; set; }
    public required string OpenbareRuimte { get; set; }
    public int Huisnummer { get; set; }
    public string? HuisLetter { get; set; }
    public string? HuisNummerToevoeging { get; set; } // opdracht zei int maar in het data bestand staan ook letters
    public required string Postcode { get; set; }
    public required string Woonplaats { get; set; }
    public required string Gemeente { get; set; }
    public required string Provincie { get; set; }
    public required string NummerAanduiding { get; set; }
    public required string VerblijfsobjectGebruiksdoel { get; set; }
    public int OppervlakteVerblijfsobject { get; set; }
    public required string VerblijfsobjectStatus { get; set; }
    public required string Object_Id { get; set; }
    public required string Object_Type { get; set; }
    public required string NevenAdres { get; set; }
    public required string PandId { get; set; }
    public required string PandStatus { get; set; }
    public int PandBouwjaar { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public double Lon { get; set; }
    public double Lat { get; set; }
}
