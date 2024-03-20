

namespace Contract.ClientDto;

public record ReviewDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string Review { get; set;} = null!;
    public int Rate { get; set; }
}
