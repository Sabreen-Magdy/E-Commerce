using System.Drawing;

namespace Contract.Product;

public record ColorDto
{
    public int Id { get; set; }
    public Color Code { get; set; }
    public string Name { get; set; } = null!;
}

public record SizeDto
{
    public int Id { get; set; }
    public string Size {  get; set; } = null!;
}