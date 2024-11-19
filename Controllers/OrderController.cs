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
            
            var jsonResponse = new {
                order_id = order.Order_id,
                account  = order.Account,
                symbol   = order.Symbol,
                side     = order.Side ? "BUY":"SELL",
                price    = order.Price,
                quantity = order.Qty
            };

            return StatusCode(200, jsonResponse);

        }catch(KeyNotFoundException err){
            return NotFound(new {message = err.Message});
        
        }catch(Exception err){
            return StatusCode(500, new { message = "Internal server error", error = err.Message});
        
        }
    }


    [HttpGet("getOrders")]
    public async Task<ActionResult> GetOrders([FromQuery] string account){
        try{
            List<Order> orderList = await _orderRepository.GetAllOrdersByAccount(account);

            List<Object> orderFormatted = [];

            foreach(Order order in orderList){
                    var order_body = new {
                        order_id = order.Order_id,
                        account  = order.Account,
                        symbol   = order.Symbol,
                        side     = order.Side ? "BUY":"SELL",
                        price    = order.Price,
                        quantity = order.Qty
                    };

                orderFormatted.Add(order_body);
            }

            return StatusCode(200, orderFormatted);

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

            Order lastAddedItemOrder = _orderRepository.GetLastAddedItemOrderByAccount(account);

            var jsonResponse = new {
                order_id = lastAddedItemOrder.Order_id,
                account  = lastAddedItemOrder.Account,
                symbol   = lastAddedItemOrder.Symbol,
                side     = lastAddedItemOrder.Side ? "BUY":"SELL",
                price    = lastAddedItemOrder.Price,
                quantity = lastAddedItemOrder.Qty
            };

            return StatusCode(200, new { new_order_response = jsonResponse });
        }catch(KeyNotFoundException err){
            return NotFound(new {message = err.Message});
        
        }catch(Exception err){
            return StatusCode(500, new { message = "Internal server error", error = err.Message});
        }
    }
}