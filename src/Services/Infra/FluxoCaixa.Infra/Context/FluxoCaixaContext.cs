using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Infra.Context;

public class FluxoCaixaContext : DbContext
{
    public FluxoCaixaContext()
    {
    }

    public FluxoCaixaContext(DbContextOptions<FluxoCaixaContext> options) : base(options)
    {     
    }

    public DbSet<Payment> Payments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach(var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FluxoCaixaContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

