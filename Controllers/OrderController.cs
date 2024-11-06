using System.Data;
using Microsoft.AspNetCore.Mvc;
using simulador_de_bolsa_valores_API.Models;

namespace simulador_de_bolsa_valores_API.Controllers;

[ApiController]
[Route("api/v1")]
public class OrderController : ControllerBase{
   
   [HttpGet("getOrder")]
    public async Task<ActionResult<Ordens>> GetOrder([FromQuery] string id){
    
    }

    [HttpGet("getOrders")]
    public async Task<ActionResult<Client>> GetOrders([FromQuery] string account){
    
    }

    [HttpPost("sendNewOrder")]
    public async Task<ActionResult<Ordens>> PostOrders(){
    
    }
}









        

