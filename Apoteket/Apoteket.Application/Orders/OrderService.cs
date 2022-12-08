namespace Apoteket.Application.Orders
{
    public class OrderService : IOrderService
    {
        public OrderResult Create(string itemName, int quantity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderResult Get(int id)
        {
            return new OrderResult();
        }

        public IEnumerable<OrderResult> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, string itemName, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
