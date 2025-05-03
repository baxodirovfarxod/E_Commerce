using E_Commerce.Bll.Dtos.OrderDTOs;
using E_Commerce.Bll.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Server.Controller
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        [HttpGet("getPreview")]
        public async Task<OrderGetDto> GetOrderPreviewAsync(long customerId)
        {
            return await OrderService.GetOrderPreviewAsync(customerId);
        }

        [HttpPost("create")]
        public async Task<OrderGetDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            return await OrderService.CreateOrderAsync(orderCreateDto);
        }

        [HttpGet("getAll")]
        public async Task<List<OrderGetDto>> GetOrdersAsync(long customerId)
        {
            return await OrderService.GetOrdersAsync(customerId);
        }
    }
}
