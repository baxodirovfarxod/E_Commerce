using E_Commerce.Bll.Dtos.OrderDTOs;

namespace E_Commerce.Bll.Services.OrderService;
public interface IOrderService
{
    Task<OrderGetDto> GetOrderPreviewAsync(long customerId);
    Task<OrderGetDto> CreateOrderAsync(OrderCreateDto orderCreateDto);
    Task<List<OrderGetDto>> GetOrdersAsync(long customerId);
}

