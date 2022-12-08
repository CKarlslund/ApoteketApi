namespace Apoteket.Contracts.Orders;

public record UpdateOrderRequest(int Id, string ItemName, int Quantity);
