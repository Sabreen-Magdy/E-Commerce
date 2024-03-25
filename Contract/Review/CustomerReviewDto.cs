

namespace Contract;

public record CustomerReviewDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string? Review { get; set;}
    public int Rate { get; set; }
    public DateTime Date { get; set; }

}


