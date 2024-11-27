using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace simulador_de_bolsa_valores_API.Models;


public class Order{
    [Key]
    [MaxLength(36)]
    [NotNull]
    public string Order_id { get; private set; }
    [ForeignKey("Client")]
    public string Account { get; private set; } 
    public Client Client { get; private set; } 
    [MaxLength(10)]
    public string Symbol { get; private set; }
    [DefaultValue(true)]
    public bool Side { get; private set; }
    public int Qty { get; private set; }
    [Precision(6,2)]
    public decimal Price { get; private set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Create_order_at { get; private set; }


    public Order(string account, string symbol, bool side, int qty, decimal price){
        Order_id = Guid.NewGuid().ToString();
        Account  = account;
        Symbol   = symbol;
        Side     = side;
        Qty      = qty;
        Price    = price;
        Create_order_at = DateTime.Now;
    }
}
