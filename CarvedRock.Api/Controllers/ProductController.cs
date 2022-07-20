using CarvedRock.Domain;
using CarvedRock.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarvedRock.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductLogic _productLogic;

    public ProductController(ILogger<ProductController> logger, IProductLogic productLogic)
    {
        _logger = logger;
        _productLogic = productLogic;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductModel>> GetAsync(string category = "all")
    {
        _logger.LogInformation("Getting produts in Api for {category}", category);
        return await _productLogic.GetProductsForCategoryAsync(category);
    }
}