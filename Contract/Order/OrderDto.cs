using Contract.Order;

namespace Contract;

public record OrderDto
{
    //  و هو رايح لل  admin  هيكون خد id
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; } 
    public DateTime OrderDate { get; set; }
    public DateTime? ConfirmDate { get; set; }
    public int State { get; set; }
    public double OrderTotalCost { get; set; }
    public string CustomerAddress { get; set; }
    public List<ProductBToOrderDto> ProductsperOrders { get; set; } = null!;

    //public int Quantity { get; set; }

    //public List<int> ProductvareintId { get; set; } 

    // public List<string> ProductvareinName { get; set; } 
}
