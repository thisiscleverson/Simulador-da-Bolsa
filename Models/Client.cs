using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace simulador_de_bolsa_valores_API.Models;

public class Client{
    [Key]
    [MaxLength(10)]
    public string Account { get; private set; } 
    [NotNull]
    [MaxLength(255)]
    public string Name { get; private set;}

    public ICollection<Order> Orders { get; set; }

    public Client(string account, string name){
        Account = account;
        Name = name;
    }
}
