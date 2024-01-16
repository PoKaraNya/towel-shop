namespace API.Dtos;

public class ProductToReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string ProductCategory { get; set; }
}