using API.Data;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _rep;
    public ProductsController(IProductRepository rep)
    {
        _rep = rep;
    }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
       var products = await _rep.GetProductsAsync();
       return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _rep.GetProductByIdAsync(id);
        return product;
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
    {
        return Ok(await _rep.GetCategoriesAsync());
    }

}
