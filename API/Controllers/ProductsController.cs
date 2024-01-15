using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.Specifications;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Category> _categoryRepo;
    private readonly IGenericRepository<Product> _productRepo;

    public ProductsController(
        IGenericRepository<Product> productRepo,
        IGenericRepository<Category> categoryRepo)
    {
        _categoryRepo = categoryRepo;
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var spec = new ProductsWithCategoriesSpecification();
        var products = await _productRepo.ListAsync(spec);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var spec =  new ProductsWithCategoriesSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
        return product;
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
    {
        return Ok(await _categoryRepo.ListAllAsync());
    }
}