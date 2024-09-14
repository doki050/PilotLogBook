using Domain.Model.PilotDocuments;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext : DbContext
{
    public DbSet<LogBook> LogBooks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
