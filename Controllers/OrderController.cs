using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using simulador_de_bolsa_valores_API.DAL;
using simulador_de_bolsa_valores_API.Models;

namespace simulador_de_bolsa_valores_API.Controllers;

[ApiController]
[Route("api/v1")]
public class OrderController : ControllerBase{

    private readonly IOrderRepository _orderRepository;

    public OrderController (IOrderRepository orderRepository){
        _orderRepository = orderRepository;
    }


    [HttpGet("getOrder")]
    public IActionResult GetOrder([FromQuery] string id){
        try{
            Order order = _orderRepository.GetOrderById(id);
            return Ok(order);
        
        }catch(KeyNotFoundException err){
            return NotFound(new {message = err.Message});
        
        }catch(Exception err){
            return StatusCode(500, new { message = "Internal server error", error = err.Message});
        
        }
    }


    [HttpGet("getOrders")]
    public async Task<ActionResult> GetOrders([FromQuery] string account){
        try{
            List<Order> order_list = await _orderRepository.GetAllOrdersByAccount(account);
            return Ok(order_list);

        }catch(KeyNotFoundException err){
            return NotFound(new {message = err.Message});

        }catch(Exception err){
            return StatusCode(500, new { message = "Internal server error", error = err.Message});

        }
    }


    [HttpPost("sendNewOrder")]
    public IActionResult PostOrders([FromBody] JsonElement json){
        //TODO: Fazer validacoes para cada key do json
        try{
            string  account  = json.GetProperty("account").ToString();
            string  symbol   = json.GetProperty("symbol").ToString();
            string  side     = json.GetProperty("side").ToString();
            int     qty      = json.GetProperty("quantity").GetInt32();
            decimal price    = json.GetProperty("price").GetDecimal();

            bool boolean_side = side == "BUY"? true: false;

            _orderRepository.InsertNewOrder(account, symbol, boolean_side, qty, price);
            _orderRepository.Save();

            return Ok();
        }catch(Exception err){
            return StatusCode(500, new { message = "Internal server error", error = err.Message});
        }
    }
}