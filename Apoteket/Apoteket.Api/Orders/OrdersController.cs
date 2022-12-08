using Apoteket.Application.Orders;
using Apoteket.Contracts.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Apoteket.Api.Orders
{

    [ApiController]
    [Route("[api/controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;

        public OrdersController(ILogger<OrdersController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetOrderResponse>> GetOrders()
        {
            var orderResults = _orderService.Get();

            if (orderResults == null)
            {
                return NotFound();
            }

            //TODO: Map in mapper
            var ordersResponse = orderResults.Select(or => new GetOrderResponse(or.ItemName, or.Quantity));

            return Ok(ordersResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<GetOrderResponse> GetOrder(int id, IOrderService _orderService)
        {
            var orderResult = _orderService.Get(id);

            if (orderResult == null)
            {
                return NotFound();
            }

            //TODO: Map in mapper
            var orderResponse = new GetOrderResponse(orderResult.ItemName, orderResult.Quantity);

            return orderResponse;
        }

        [HttpPost]
        public ActionResult<CreateOrderResponse> PostTodoItem(CreateOrderRequest createOrderRequest, IOrderService _orderService)
        {
            var createdResult = _orderService.Create(createOrderRequest.ItemName, createOrderRequest.Quantity);

            if (createdResult == null)
            {
                return Problem("Could not create.");
            }

            //TODO: Map in mapper
            var createdResponse = new CreateOrderResponse(createdResult.Id, createdResult.ItemName, createdResult.Quantity);

            return CreatedAtAction(nameof(OrdersController), createdResponse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, UpdateOrderRequest updateOrderRequest)
        {
            if (id != updateOrderRequest.Id)
            {
                return BadRequest();
            }

            //I probably want an optional here with error handling etc instead of just a bool
            var updated = _orderService.Update(updateOrderRequest.Id, updateOrderRequest.ItemName, updateOrderRequest.Quantity);

            if (!updated)
            {
                return Problem("Could not update.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            //I probably want an optional here with error handling etc instead of just a bool
            var deleted = _orderService.Delete(id);
            
            if (!deleted) {
                return Problem("Could not delete.");
            }

            return NoContent();
        }
    }

}
