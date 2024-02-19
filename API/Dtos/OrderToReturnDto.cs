using Core.Entities.OrderAggregate;

namespace API.Dtos;

public class OrderToReturnDto
{
    public int Id { get; set; }
    public string BuyerEmail { get; set; }
    public DateTime OrderDate { get; set; } 
    public Address ShipToAddress { get; set; }
    public string DeliveryMethod { get; set; }
    public int ShippingPrice { get; set; }
    public IReadOnlyList<OrderItemDto> OrderItems { get; set; }
    public int Subtotal { get; set; }
    public int Total { get; set; }
    public string Status { get; set; } 
}