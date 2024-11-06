using System.ComponentModel.DataAnnotations;

namespace simulador_de_bolsa_valores_API.Models;


public class Ordens{
   [Key]
   public string? Order_id {get; set; } 
   public string? Account {get; set; }
   public string? Symbol {get; set; }
   public bool Side {get; set; }
   public int Qty {get; set; }
   public double Price {get; set; }
   public DateTime Create_order_at {get; set;}
}