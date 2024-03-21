namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Descroption { get; set; }
    public string? Icon { get; set; }
}
