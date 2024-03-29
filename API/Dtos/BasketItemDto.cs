﻿using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class BasketItemDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string ProductName { get; set; }
    
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public int Price { get; set; }
    
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }
    
    [Required]
    public string PictureUrl { get; set; }
    
    [Required]
    public string Category { get; set; }
}