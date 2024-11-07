using Microsoft.EntityFrameworkCore;

namespace simulador_de_bolsa_valores_API.Models;

public class StockExchangeContext : DbContext{
    
    public DbSet<Ordens> Ordens{ get; set; } = null!;
    public DbSet<Client> Client{ get; set; } = null!;

    public StockExchangeContext(
        DbContextOptions<StockExchangeContext> options
    ): base(options){
    
    }

    // Isso vai inserir ao criar as tabelas alguns dados para teste.
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // definir os tamanhos de caracteres para cada string
        modelBuilder.Entity<Client>()
            .Property(c => c.Account)
            .HasMaxLength(10);


        modelBuilder.Entity<Ordens>()
            .Property(c => c.Order_id)
            .HasMaxLength(36);


        modelBuilder.Entity<Ordens>()
            .Property(c => c.Symbol)
            .HasMaxLength(10);  

        // Link falando mais sobre como definir uma foreign key: https://learn.microsoft.com/en-us/ef/core/modeling/relationships
        modelBuilder.Entity<Client>()
        .HasMany(e => e.Orders)
        .WithOne(e => e.Client)
        .HasForeignKey(e => e.Account);



        // inserir alguns usuarios na tabela
        //modelBuilder.Entity<Client>().HasData(
        //    new Client { Account = "0002024" , Name = "Julia"},
        //    new Client { Account = "0002025" , Name = "Pedro"},
        //    new Client { Account = "0002026" , Name = "Vitor"}
        //);
    }
}
