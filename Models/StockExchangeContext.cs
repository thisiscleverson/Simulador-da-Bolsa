using Microsoft.EntityFrameworkCore;

namespace simulador_de_bolsa_valores_API.Models;

public class StockExchangeContext : DbContext{
    
    public StockExchangeContext(
        DbContextOptions<StockExchangeContext> options
    ): base(options){}

    public StockExchangeContext(){}

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlServer("Server=localhost;Database=stock_exchange_db;User=root;Password=123456;");
    }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Client>()
            .HasKey(c => c.Account);


        modelBuilder.Entity<Order>()
            .HasKey(c => c.Order_id);

        //<Client> 1 <-------> n <Order>
        modelBuilder.Entity<Order>()
            .HasOne(p => p.Client)
            .WithMany(c => c.Orders)
            .HasForeignKey(p => p.Account);


        // inserir alguns usuarios na tabela
        //modelBuilder.Entity<Client>().HasData(
        //    new Client { Account = "0002024" , Name = "Julia"},
        //    new Client { Account = "0002025" , Name = "Pedro"},
        //    new Client { Account = "0002026" , Name = "Vitor"}
        //);
    }

    public virtual DbSet<Order> Orders{ get; set; } = null!;
    public virtual DbSet<Client> Clients{ get; set; } = null!;
}
