using Domain.Model.PilotDocuments;
using Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
{
    public DbSet<LogBook> LogBooks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await SaveChangesAsync(cancellationToken);
    }
}
