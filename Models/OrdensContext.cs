using Microsoft.EntityFrameworkCore;

namespace simulador_de_bolsa_valores_API.Models;

public class OrdensContext : DbContext{
    public OrdensContext(
        DbContextOptions<OrdensContext> options
    ): base(options){
    
    }

    public DbSet<Ordens> Ordens{ get; set; } = null!;
}