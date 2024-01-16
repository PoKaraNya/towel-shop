using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.Specifications;

namespace API.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Category> _categoryRepo;
    private readonly IGenericRepository<Product> _productRepo;

    public ProductsController(
        IGenericRepository<Product> productRepo,
        IGenericRepository<Category> categoryRepo,
        IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepo = categoryRepo;
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
    {
        var spec = new ProductsWithCategoriesSpecification();
        var products = await _productRepo.ListAsync(spec);
        return Ok(_mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithCategoriesSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
        return _mapper.Map<Product ,ProductToReturnDto>(product);
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
    {
        return Ok(await _categoryRepo.ListAllAsync());
    }
}