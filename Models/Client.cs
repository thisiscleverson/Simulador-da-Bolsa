
// Esse DataAnnotation é para permitir o uso do atributo [Key].
// O uso do atributo [Key] diz que a propriedade é a chave primaria.
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace simulador_de_bolsa_valores_API.Models;

public class Client{
   [Key]
   public string? Account {get; set; } 
   public string? Name {get; set; }

   public ICollection<Ordens> Orders { get; set; }
}