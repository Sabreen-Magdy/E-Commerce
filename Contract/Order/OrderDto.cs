namespace Contract;

public record OrderDto
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public DateTime? ConfirmDate { get; set; }
    public int State { get; set; }
    public double TotalCost { get; set; }
    public string CustomerAddress { get; set; } 

    public List<int> ProductvareintId { get; set; } 
    public List<string> ProductvareinName { get; set; } 
}
