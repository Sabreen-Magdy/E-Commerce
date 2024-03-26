using System.Drawing;

namespace Contract;

public record ColorDto
{
    public int Id { get; set; }
    public string Code { get; set; } 
    public string Name { get; set; } 
}

public record SizeDto
{
    public int Id { get; set; }
    public string Size {  get; set; }
}
