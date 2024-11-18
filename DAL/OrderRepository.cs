using Microsoft.EntityFrameworkCore;
using simulador_de_bolsa_valores_API.Models;


namespace simulador_de_bolsa_valores_API.DAL{
    public class OrderRepository:IOrderRepository{
        private readonly StockExchangeContext _context;

        public OrderRepository(StockExchangeContext context){
            _context = context;
        } 


        public async Task<List<Order>> GetAllOrdersByAccount(string account){
            bool accountExists = CheckIsClientExists(account);

            if(!accountExists){
                throw new KeyNotFoundException($"Account {account} not found.");
            }

            return await _context.Orders.Where(o => o.Account == account).ToListAsync();
            
            // TODO:
            /*return await _context.Orders.Join(
                _context.Clients, 
                client => client.Account,
                order => order.Account,
                (client, order) => new { Client = client, Order = order}
            ).ToListAsync();*/
        }


        public Order GetOrderById(string id){
            var orderById = _context.Orders.Find(id);

            if(orderById == null){
                throw new KeyNotFoundException($"Id {id} not found.");
            }
            
            return orderById;
        }


        public void InsertNewOrder(string account, string symbol, bool side, int qty, decimal price){
            Order newOrder = new Order(account, symbol, side, qty, price);
            _context.Orders.Add(newOrder);
        }


        public void Save(){
            _context.SaveChanges();
        }


        private bool CheckIsClientExists(string account){
            return _context.Clients.Any(c => c.Account == account);
        }


        private bool CheckIsIdExists(string id){
            return _context.Orders.Any(c => c.Order_id == id);
        }
    }
}