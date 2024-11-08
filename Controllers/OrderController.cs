using Microsoft.AspNetCore.Mvc;

namespace simulador_de_bolsa_valores_API.Controllers;

[ApiController]
[Route("api/v1")]
public class OrderController : ControllerBase{

    private readonly IClientService _clientService;

    public OrderController (IClientService clientService){
        _clientService = clientService;
    }


    [HttpGet("getOrder")]
    public async Task<ActionResult> GetOrder([FromQuery] string id){

        try{
            var order = await _clientService.GetOrderById(id);
            return Ok(order);

        }catch (KeyNotFoundException e){
            return NotFound(new {message = "Order not found."});

        }
    }


    [HttpGet("getOrders")]
    public async Task<ActionResult> GetOrders([FromQuery] string account){
        
        if (!await _clientService.CheckIsClientExists(account)){
            return NotFound(new {message = "account not found"});
        }

        var ordens_list = await _clientService.GetAllOrdersByAccount(account);
        return Ok(ordens_list);
    }


    [HttpPost("sendNewOrder")]
    public IActionResult PostOrders(){
        return Ok();
    }
}