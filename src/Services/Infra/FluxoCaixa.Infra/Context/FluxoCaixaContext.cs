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

        modelBuilder.Entity<User>().HasData(new User("admin", "123"));
        modelBuilder.Entity<Payment>().HasData(
            new Payment()
            {
                Description = "Salário",
                PaymentDate = DateTime.Parse("2024-07-10"),
                PaymentType = Domain.Entities.Enums.PaymentTypeEnum.Credito, 
                PaymentValue = 2000.0m 
            },
            new Payment()
            {
                Description = "Conta de Luz",
                PaymentDate = DateTime.Parse("2024-07-10"),
                PaymentType = Domain.Entities.Enums.PaymentTypeEnum.Debito,
                PaymentValue = 200.0m
            },
            new Payment()
            {
                Description = "Assinatura streaming",
                PaymentDate = DateTime.Parse("2024-07-10"),
                PaymentType = Domain.Entities.Enums.PaymentTypeEnum.Debito,
                PaymentValue = 20.0m
            },
            new Payment()
            {
                Description = "Restaurante",
                PaymentDate = DateTime.Parse("2024-07-10"),
                PaymentType = Domain.Entities.Enums.PaymentTypeEnum.Debito,
                PaymentValue = 100.0m
            }
        );
    }
}

