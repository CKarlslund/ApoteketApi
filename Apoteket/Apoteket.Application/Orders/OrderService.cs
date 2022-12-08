using Apoteket.Domain.Orders;

namespace Apoteket.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Order> CreateAsync(string itemName, int quantity)
        {
            var orderToCreate = new Order { ItemName = itemName, Quantity = quantity };

            await _repository.CreateAsync(orderToCreate);

            return orderToCreate;
        }

        public async Task<bool> UpdateAsync(int id, string itemName, int quantity)
        {
            var orderToCreate = new Order { Id = id, ItemName = itemName, Quantity = quantity };
            var updated = await _repository.UpdateAsync(orderToCreate);

            return updated != null;
        }

        public async Task<bool> DeleteAsync()
        {
            var deleted = await _repository.DeleteAsync();

            return deleted!.Any();
        }
    }
}
