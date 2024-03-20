

namespace Customer.Contract.ClientDto;

public record OrderDto
{
    public DateTime Date {  get; set; }
    public DateTime ConfirmDate { get; set; }
    public int State { get; set; }
    public double TotalAmount { get; set; }
    public string Address { get; set; } = null!;

    public List<ItemDto> items { get; set; } = null!; 
}
