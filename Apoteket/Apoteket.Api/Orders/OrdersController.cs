using Apoteket.Application.Orders;
using Apoteket.Contracts.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Apoteket.Api.Orders
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<GetOrderResponse>>> Get()
        {
            var orderResults = await _orderService.GetAsync();

            if (orderResults == null)
            {
                return NotFound();
            }

            //TODO: Map in mapper
            var ordersResponse = orderResults.Select(or => new GetOrderResponse(or.ItemName, or.Quantity));

            return Ok(ordersResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderResponse>> Get(int id)
        {
            var orderResult = await _orderService.GetAsync(id);

            if (orderResult == null)
            {
                return NotFound();
            }

            //TODO: Map in mapper
            var orderResponse = new GetOrderResponse(orderResult.ItemName, orderResult.Quantity);

            return orderResponse;
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderResponse>> Post(CreateOrderRequest createOrderRequest)
        {
            var createdResult = await _orderService.CreateAsync(createOrderRequest.ItemName, createOrderRequest.Quantity);

            if (createdResult == null)
            {
                return Problem("Could not create.");
            }

            //TODO: Map in mapper
            var createdResponse = new CreateOrderResponse(createdResult.Id, createdResult.ItemName, createdResult.Quantity);

            return CreatedAtAction(nameof(Get), createdResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderRequest updateOrderRequest)
        {
            if (id != updateOrderRequest.Id)
            {
                return BadRequest("Ids did not match.");
            }

            //I probably want an optional here with error handling etc instead of just a bool
            var updated = await _orderService.UpdateAsync(updateOrderRequest.Id, updateOrderRequest.ItemName, updateOrderRequest.Quantity);

            if (!updated)
            {
                return Problem("Could not update.");
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            //I probably want an optional here with error handling etc instead of just a bool
            var deleted = await _orderService.DeleteAsync();
            
            if (!deleted) {
                return Problem("Could not delete.");
            }

            return NoContent();
        }
    }

}
