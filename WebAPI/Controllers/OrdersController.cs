using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private  IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getorders")]
        public IActionResult GetOrders()
        {
            var result = _orderService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getordersbyproduct")]
        public IActionResult GetOrderByProduct(Product product)
        {
            var result = _orderService.GetOrdersByProduct(product);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("getordersbyuser")]
        public IActionResult GetOrdersByUserId(int id)
        {
            var result = _orderService.GetOrdersByUserId(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult OrderAdd(Order order)
        {
            var result = _orderService.Add(order);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult OrderDelete(Order order)
        {
            var result = _orderService.Delete(order);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPatch("update")]
        public IActionResult OrderUpdate(Order order)
        {
            var result = _orderService.Update(order);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
