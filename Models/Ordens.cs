using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simulador_de_bolsa_valores_API.Models;


public class Ordens{

   [Key]
   [MaxLength(36)]
   public string? Order_id {get; set; }  

   [ForeignKey("Client")]
   public string? Account {get; set; }
   public Client Client {get; set;}


   [MaxLength(10)]
   public string? Symbol {get; set; }
   public bool Side {get; set; }
   public int Qty {get; set; } 
   
   [Precision(6,2)]
   public decimal Price {get; set; }

   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public DateTime Create_order_at {get; set;} = DateTime.Now;

}  