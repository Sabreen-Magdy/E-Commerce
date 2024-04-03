using Contract.Order;

namespace Contract;

public record OrderDto
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; } 
    public DateTime OrderDate { get; set; }
    public DateTime? ConfirmDate { get; set; }
    public int State { get; set; }
    public double OrderTotalCost { get; set; }
    public string CustomerAddress { get; set; } = null!;
    public string Comment { get; set; } = null!;
    public List<ProductBToOrderDto> ProductsperOrders { get; set; } = null!; 
}
