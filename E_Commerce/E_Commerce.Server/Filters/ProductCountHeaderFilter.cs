using E_Commerce.Bll.Services.ProductService;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Commerce.Server.Filters;

public class ProductCountHeaderFilter : IAsyncResultFilter
{
    private readonly IProductService productService;

    public ProductCountHeaderFilter(IProductService productService)
    {
        this.productService = productService;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var totalCount = await productService.GetAllProductsCount();

        context.HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());

        await next();
    }
}
