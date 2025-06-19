using InvennaOpdracht.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InvennaOpdracht.Server.Data;

public class InvennaDbContext : DbContext
{
    public InvennaDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<GeographicalDataItem> GeographicalDataItems => Set<GeographicalDataItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
