using Apoteket.Domain.Orders;

namespace Apoteket.Application.Orders
{
    public interface IOrderService
    {
        Task<Order> GetAsync(int id);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> CreateAsync(string itemName, int quantity);
        Task<bool> UpdateAsync(int id, string itemName, int quantity);
        Task<bool> DeleteAsync();
    }
}