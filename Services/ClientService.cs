using Microsoft.EntityFrameworkCore;
using simulador_de_bolsa_valores_API.Models;


public interface IClientService{
    Task<bool> CheckIsClientExists(string account);
    Task<List<Ordens>> GetAllOrdersByAccount(string account);
    Task<Ordens> GetOrderById(string id);
}


namespace simulador_de_bolsa_valores_API.Services{

    public class ClientService: IClientService{
        
        // readonly, garante que o context só pode ser atribuído uma vez.
        // E não pode ser modificado, sendo so para leitura.
        private readonly StockExchangeContext _context; 
        

        public ClientService(StockExchangeContext context){
            _context = context;
        }


        public async Task<bool> CheckIsClientExists(string account){
            return await _context.Client.AnyAsync(c => c.Account == account);
        }


        public async Task<List<Ordens>> GetAllOrdersByAccount(string account){
            return await _context.Ordens.Where(o => o.Account == account).ToListAsync();
        }


        public async Task<Ordens> GetOrderById(string id){
            var order = await _context.Ordens.FirstOrDefaultAsync(o => o.Order_id == id);
            
            if(order == null){
                throw new KeyNotFoundException("Order not found.");
            }

            return order;
        }
    }
}