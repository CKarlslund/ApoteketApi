namespace Apoteket.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(int id);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> CreateAsync(Order order);
        Task<IEnumerable<Order>> DeleteAsync();
        Task<Order> UpdateAsync(Order order);

    }
}
