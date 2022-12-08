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

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            return new Order();
        }

        public IEnumerable<Order> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Create(string itemName, int quantity)
        {
            var orderToCreate = new Order { ItemName = itemName, Quantity = quantity };

            await _repository.Add(orderToCreate);

            return orderToCreate;
        }

        public bool Update(int id, string itemName, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
