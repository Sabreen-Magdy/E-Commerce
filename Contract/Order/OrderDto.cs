using Contract.OrderItem;

namespace Contract.Order;

public record OrderDto
{
    int CustomerId { get; set; }
    string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ConfirmDate { get; set; }
    public int State { get; set; }
    public double TotalCost { get; set; }
    public string CustomerAddress { get; set; } 

    public List<int> ProductId { get; set; } 
    public List<string> ProductName { get; set; } 
}
