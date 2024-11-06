using Microsoft.EntityFrameworkCore;
using simulador_de_bolsa_valores_API.Models;

namespace simulador_de_bolsa_valores_API;

public class Program{
    public static void Main(string[] args){
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddDbContext<ClientContext>(opt => opt.UseInMemoryDatabase("Client"));
        
        var app = builder.Build();

        app.UseHttpsRedirection();

        app.MapControllers();
        
        app.Run();
    }
}


