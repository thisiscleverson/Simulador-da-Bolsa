using Microsoft.EntityFrameworkCore;

namespace simulador_de_bolsa_valores_API.Models;

public class ClientContext : DbContext{
    public ClientContext(
        DbContextOptions<ClientContext> options
    ): base(options){
    
    }

    public DbSet<Client> Client { get; set; } = null!;
}