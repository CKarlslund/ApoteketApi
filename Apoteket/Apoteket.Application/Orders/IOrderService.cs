using Apoteket.Domain.Orders;

namespace Apoteket.Application.Orders
{
    public interface IOrderService
    {
        Order Get(int id);
        IEnumerable<Order> Get();
        Task<Order> Create(string itemName, int quantity);
        bool Update(int id, string itemName, int quantity);
        bool Delete();
    }
}