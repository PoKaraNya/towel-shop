﻿using API.Dtos;
using API.Errors;
using API.Helpers;
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
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
        [FromQuery]ProductSpecParams productSpecParams)
    {
        var spec = new ProductsWithCategoriesSpecification(productSpecParams);
        
        var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
        
        var totalItems = await _productRepo.CountAsync(countSpec);
        
        var products = await _productRepo.ListAsync(spec);

        var data = _mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        
        return Ok(new Pagination<ProductToReturnDto>(
            productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, data
            ));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithCategoriesSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
        if (product == null)
        {
            return NotFound(new ApiResponse(404));
        }
        return _mapper.Map<Product ,ProductToReturnDto>(product);
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
    {
        return Ok(await _categoryRepo.ListAllAsync());
    }
}