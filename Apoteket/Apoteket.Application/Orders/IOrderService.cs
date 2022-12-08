namespace Apoteket.Application.Orders
{
    public interface IOrderService
    {
        OrderResult Get(int id);
        IEnumerable<OrderResult> Get();
        OrderResult Create(string itemName, int quantity);
        bool Update(int id, string itemName, int quantity);
        bool Delete();
    }
}