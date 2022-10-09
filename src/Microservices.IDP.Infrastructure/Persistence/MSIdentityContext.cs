using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microservices.IDP.Infrastructure.Entities;

namespace Microservices.IDP.Infrastructure.Persistence;

public class MSIdentityContext : IdentityDbContext<User>
{
    public IDbConnection Connection => Database.GetDbConnection();
    public MSIdentityContext(DbContextOptions<MSIdentityContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(MSIdentityContext).Assembly);
        builder.ApplyIdentityConfiguration();
    }
}