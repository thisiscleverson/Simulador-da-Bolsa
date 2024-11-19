using simulador_de_bolsa_valores_API.Models;

namespace simulador_de_bolsa_valores_API.DAL{
    public interface IOrderRepository{
        void InsertNewOrder(string account, string symbol, bool side, int qty, decimal price);   
        Task<List<Order>> GetAllOrdersByAccount(string account);
        Order GetOrderById(string id);

        Order GetLastAddedItemOrderByAccount(string account);

        void Save();
    }
}