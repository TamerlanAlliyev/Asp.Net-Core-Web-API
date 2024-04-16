using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nest.Domain.Common;
using Nest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IHttpContextAccessor _accessor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor accessor) : base(options)
    {
        _accessor = accessor;
    }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseAuditableEntity>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _accessor.HttpContext.User.Identity?.Name ?? "NewUser";
                    entry.Entity.Created = DateTime.UtcNow.AddHours(4);
                    entry.Entity.IPAddress = _accessor.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedBy = _accessor.HttpContext.User.Identity!.Name!;
                    entry.Entity.Modified = DateTime.UtcNow.AddHours(4);
                    entry.Entity.IPAddress = _accessor.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
                    break;

                default:
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}