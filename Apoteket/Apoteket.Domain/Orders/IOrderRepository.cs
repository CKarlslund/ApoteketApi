namespace Apoteket.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order orderToCreate);
    }
}
