using InvennaOpdracht.Server.Data;
using InvennaOpdracht.Server.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvennaOpdracht.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeographicalDataController(InvennaDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GeographicalDataItem>>> GetGeographicalData()
    {
        var geographicalData = await context.GeographicalDataItems.ToListAsync();
        return Ok(geographicalData);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GeographicalDataItem>> GetGeographicalDataById(int id)
    {
        var geographicalDataItem = await context.GeographicalDataItems.FindAsync(id);
        return Ok(geographicalDataItem);
    }

    [HttpPost]
    public async Task<ActionResult<GeographicalDataItem>> CreateGeographicalData([FromBody] GeographicalDataItem geographicalData)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.GeographicalDataItems.Add(geographicalData);
        await context.SaveChangesAsync();

        var geographicalDataItem = await context.GeographicalDataItems.FindAsync(geographicalData.Id);

        return CreatedAtAction(nameof(GetGeographicalDataById), geographicalDataItem);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GeographicalDataItem>> UpdateGeographicalDataById(int id, [FromBody] GeographicalDataItem newGeographicalDataItem)
    {
        var existingGeographicalDataItem = await context.GeographicalDataItems.FindAsync(id);
        if (existingGeographicalDataItem == null)
        {
            return NotFound();
        }

        MapItem(existingGeographicalDataItem, newGeographicalDataItem);

        await context.SaveChangesAsync();

        var updatedGeographicalDataItem = await context.GeographicalDataItems.FindAsync(id);

        return Ok(updatedGeographicalDataItem);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteGeographicalDataById(int id)
    {
        var geographicalDataItem = await context.GeographicalDataItems.FindAsync(id);
        if (geographicalDataItem == null)
        {
            return NotFound();
        }

        context.GeographicalDataItems.Remove(geographicalDataItem);
        await context.SaveChangesAsync();

        var status = await context.GeographicalDataItems.FindAsync(id) == null ? true : false;
        return Ok(status);
    }

    public static void MapItem(GeographicalDataItem target, GeographicalDataItem source)
    {
        target.OpenbareRuimte = source.OpenbareRuimte;
        target.Huisnummer = source.Huisnummer;
        target.HuisLetter = source.HuisLetter;
        target.HuisNummerToevoeging = source.HuisNummerToevoeging;
        target.Postcode = source.Postcode;
        target.Woonplaats = source.Woonplaats;
        target.Gemeente = source.Gemeente;
        target.Provincie = source.Provincie;
        target.NummerAanduiding = source.NummerAanduiding;
        target.VerblijfsobjectGebruiksdoel = source.VerblijfsobjectGebruiksdoel;
        target.OppervlakteVerblijfsobject = source.OppervlakteVerblijfsobject;
        target.VerblijfsobjectStatus = source.VerblijfsobjectStatus;
        target.Object_Id = source.Object_Id;
        target.Object_Type = source.Object_Type;
        target.NevenAdres = source.NevenAdres;
        target.PandId = source.PandId;
        target.PandStatus = source.PandStatus;
        target.PandBouwjaar = source.PandBouwjaar;
        target.X = source.X;
        target.Y = source.Y;
        target.Lon = source.Lon;
        target.Lat = source.Lat;
    }
}
