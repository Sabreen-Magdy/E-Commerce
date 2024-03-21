

namespace Contract.ClientDto;

public record CustomerReviewDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string Review { get; set;} = null!;
    public int Rate { get; set; }
}

public record ProductReviewDto
{
    public int CustomertId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string Review { get; set; } = null!;
    public int Rate { get; set; }
}
